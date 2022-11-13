using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class OnTriggerEnterAndFinishGame : MonoBehaviour
{
    [SerializeField] private OpenEyes openEyes;
    [SerializeField] private GameObject finalText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            openEyes.StartClosingEyes();
            finalText.gameObject.SetActive(true);

        }
    }
}
