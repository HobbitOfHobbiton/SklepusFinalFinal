using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodstackController : MonoBehaviour, IInteractable
{
    private int currentNumberOfProducts;
    [SerializeField] private List<GameObject> foodObjects = new List<GameObject>();
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private HandHolder handHolder;


    public void InititializeFoodstack()
    {
        //currentNumberOfProducts = foodObjects.Count;
    }

    private void Start()
    {
        currentNumberOfProducts = foodObjects.Count;

    }

    public void Interact()
    {
        if (handHolder.HandOccupied == true)
        {
            Debug.Log("handHolder.HandOccupied");
            return;
        }
        if (currentNumberOfProducts <= 0)
        {
            Debug.Log("currentNumberOfProducts <= 0");
            return;
        }
        handHolder.HandOccupied = true;
        foodObjects[currentNumberOfProducts - 1].transform.parent = playerHandTransform;
        foodObjects[currentNumberOfProducts - 1].transform.localPosition = new Vector3(0, 0, 0);
        currentNumberOfProducts--;

    }

}