using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class OnTriggerEnterAndFinishGame : MonoBehaviour
{
    [SerializeField] private OpenEyes openEyes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            openEyes.StartClosingEyes();
        }
    }
}
