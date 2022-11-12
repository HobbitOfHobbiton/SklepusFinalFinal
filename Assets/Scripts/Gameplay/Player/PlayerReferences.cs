using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;

public class PlayerReferences : MonoBehaviour
{
    public static PlayerReferences Instance;

    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public PlayerController PlayerController { get; private set; }
    [field: SerializeField] public Camera MainCamera { get; private set; }


    private void Awake()
    {
        Instance = this;
        GetReferences();
    }

    [EasyButtons.Button]
    private void GetReferences()
    {
        CharacterController = GetComponent<CharacterController>();

        MainCamera = Camera.main;

        PlayerController = GetComponent<PlayerController>();
    }
}
