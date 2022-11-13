using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChaseStateController : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private GameObject lights;
    [SerializeField] private DarkSklepusFaceController sklepusSmall;
    [SerializeField] private DarkSklepusFaceController sklepusBig;
    private ColorAdjustments colorAdjustments;
    
    private void Start()
    {
        FindObjectOfType<PlayerController>().enabled = false;

        StartCoroutine(TeleportSklepus());
    }
    private IEnumerator TeleportSklepus()
    {
        yield return new WaitForSeconds(3);
        sklepusSmall.gameObject.SetActive(false);
        lights.SetActive(true);
        FindObjectOfType<PlayerController>().enabled = true;
        yield return new WaitForSeconds(5f);
        sklepusBig.gameObject.SetActive(true);
    }

}
