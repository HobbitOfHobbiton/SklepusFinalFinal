using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class OnPlayerEnterTurnScriptOn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(TurnScriptAndDisablePlayer());
        }
    }
    private IEnumerator TurnScriptAndDisablePlayer()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<PlayerController>().enabled = false;
        FindObjectOfType<SklepusTurnerController>().canMove = true;
    }
}
