using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreepyLightController : MonoBehaviour
{
   [SerializeField] private List<Light> lights;

   private void Start()
   {
      InvokeRepeating(nameof(BlinkRandomly),0,2f);
   }

   private void BlinkRandomly()
   {
      foreach (var l in lights)
      {
         l.gameObject.SetActive(Random.value>0.5f);
      }
   }
}
