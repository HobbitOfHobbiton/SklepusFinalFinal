using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private GameObject notificationScreen;

    private void Awake()
    {
        notificationScreen.SetActive(false);
    }

    private void Start()
    {
        Invoke(nameof(TurnOnScreen),3f);
    }

    private void TurnOnScreen()
    {
        notificationScreen.SetActive(true);
    }
}
