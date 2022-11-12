using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBlinker : MonoBehaviour
{
    [SerializeField] private GameObject imageToBlink;
    private void OnEnable()
    {
        InvokeRepeating(nameof(SwitchVisibility),0,1.5f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SwitchVisibility));
    }

    private void SwitchVisibility()
    {
        imageToBlink.SetActive(!imageToBlink.activeSelf);
    }
}
