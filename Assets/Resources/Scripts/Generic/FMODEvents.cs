using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Alien")]
    [field: SerializeField] public EventReference ufo { get; private set; }
    [field: SerializeField] public EventReference whiteNoise { get; private set; }
    [field: SerializeField] public EventReference strangeLanguage { get; private set; }

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference cityBackgroundAmbience { get; private set; }
    [field: SerializeField] public EventReference buttonAmbience { get; private set; }

    [field: Header("Door")]
    [field: SerializeField] public EventReference commonDoor { get; private set; }
    [field: SerializeField] public EventReference glassDoor { get; private set; }
    [field: SerializeField] public EventReference metalDoor { get; private set; }
    [field: SerializeField] public EventReference metalDoorLocked { get; private set; }
    [field: SerializeField] public EventReference steelDoor { get; private set; }

    [field: Header("Player")]
    [field: SerializeField] public EventReference walkingPlayer { get; private set; }

    [field: Header("Theme")]
    [field: SerializeField] public EventReference mainMenuTheme { get; private set; }
    
    [field: Header("UI")]
    [field: SerializeField] public EventReference clickUI { get; private set; }
    [field: SerializeField] public EventReference selectUI { get; private set; }

    [field: Header("Other")]
    [field: SerializeField] public EventReference beep { get; private set; }

    [field: Header("Universe")]
    [field: SerializeField] public EventReference blackhole { get; private set; }

    [field: Header("Inventory")]
    [field: SerializeField] public EventReference walkieTalkie { get; private set; }

    public static FMODEvents instance { get; private set; }

    public void Awake()
    {
        if (instance != null)
            Debug.LogError("Duplicated FMODEvents");

        instance = this;
    }
}
