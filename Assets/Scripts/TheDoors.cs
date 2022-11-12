using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TheDoors : MonoBehaviour
{
   [SerializeField] private GameObject doorOne;
   [SerializeField] private GameObject doorTwo;
   [SerializeField] private float openDistance = 1.48f;
   
   private Vector3 _closePositionOne;
   private Vector3 _closePositionTwo;
   private bool _open;
   private bool _duringAnimation;
   private void Awake()
   {
      _closePositionOne = doorOne.transform.position;
      _closePositionTwo = doorTwo.transform.position;
   }
   private void OnTriggerEnter(Collider other)
   {
      StartCoroutine(Open());
   }
   private IEnumerator Open()
   {
      yield return new WaitUntil(() => !_open);
      LeanTween.value(doorOne, doorOne.transform.position,  doorOne.transform.position+ doorOne.transform.right* openDistance,1f).setOnUpdate((value,_) =>
         {
            doorOne.transform.position = value;
         }).setOnComplete(() =>
         {
            _open = true;
         });

         LeanTween.value(doorTwo, doorTwo.transform.position, doorTwo.transform.position + -doorTwo.transform.right * openDistance, 1f).setOnUpdate((value, _) =>
         {
            doorTwo.transform.position = value;
         }).setOnComplete(() =>
         {
            _open = true;
         });

   }

   private void OnTriggerExit(Collider other)
   {
      StartCoroutine(Close());
   }
   private IEnumerator Close()
   {
      yield return new WaitUntil(() => _open);
         LeanTween.value(doorOne, doorOne.transform.position,  _closePositionOne,1f).setOnUpdate((value,_) =>
         {
            doorOne.transform.position = value;
         }).setOnComplete(() =>
         {
            _open = false;
         });
      
         LeanTween.value(doorTwo, doorTwo.transform.position, _closePositionTwo,1f).setOnUpdate((value,_) =>
         {
            doorTwo.transform.position = value;
         }).setOnComplete(() =>
         {
            _open = false;
         });
      
      
   }

}
