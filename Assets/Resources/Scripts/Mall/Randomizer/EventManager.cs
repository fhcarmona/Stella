using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{    
    [SerializeField] private GameObject[] eventsObject;
    [SerializeField] private GameObject[] monitors;
    [SerializeField] private TextMeshProUGUI eventText;

    private int delay;    
    private const string eventDescription = "Evento Atual";
    private const string playerTag = "Player";

    public static Event current;
    public static bool isPlayerInSecurityRoom;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);

        StartCoroutine(TimerEvent());
    }

    public IEnumerator TimerEvent()
    {
        int chance = Random.Range(0, 100);
        int monitorRNG = Random.Range(0, monitors.Length);

        eventText.text = null;

        switch (chance)
        {
            case >= 98: // 98-99 : 2
                if (!current.Equals(Event.UFO) && isPlayerInSecurityRoom)
                {
                    Instantiate(eventsObject[0]);
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 92: // 92-97 : 6
                if (!current.Equals(Event.SHADOW) && isPlayerInSecurityRoom)
                {
                    Instantiate(eventsObject[1]);
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 80: // 80-91 : 12
                if (monitors[monitorRNG].GetComponent<MovementEvent>() == null && !current.Equals(Event.MOVEMENT))
                {
                    monitors[monitorRNG].AddComponent<MovementEvent>();
                    eventText.text = $"{eventDescription} -> {current}";
                }
                break;
            case >= 62: // 62-79 : 18

                if (monitors[monitorRNG].GetComponent<CameraEvent>() == null && !current.Equals(Event.CAMERA))
                {
                    monitors[monitorRNG].AddComponent<CameraEvent>();
                    eventText.text = $"{eventDescription} -> {current}";
                }

                break;
            case >= 0:  // 0-61 : 62
                current = Event.NONE;
                break;            
        }

        delay = Random.Range(2, 6); // 0.25min to 1.0min

        Debug.Log($"Current: {current}, Delay: {delay}");

        if(eventText.text != null)
            eventText.gameObject.SetActive(true);

        yield return new WaitUntil(() => current == Event.NONE);

        eventText.gameObject.SetActive(false);

        yield return new WaitForSeconds(delay);

        StartCoroutine(TimerEvent());
    }

    public IEnumerator TriggerEvent()
    {
        yield return null;
    }

    public IEnumerator UniqueEvent()
    {
        yield return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            isPlayerInSecurityRoom = true;
            Debug.Log($"1. Esta na sala de seguranša [{isPlayerInSecurityRoom}");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            isPlayerInSecurityRoom = false;
            Debug.Log($"2. Esta na sala de seguranša [{isPlayerInSecurityRoom}");
        }
    }
}
