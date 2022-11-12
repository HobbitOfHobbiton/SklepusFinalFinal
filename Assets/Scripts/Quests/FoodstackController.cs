using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodstackController : MonoBehaviour, IInteractable, IQuestiable
{
    private int currentNumberOfProducts;
    [SerializeField] private List<GameObject> foodObjects = new List<GameObject>();
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private HandHolder handHolder;

    public event Action OnFinishQuest = delegate { };

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
        foodObjects[currentNumberOfProducts - 1].transform.parent = playerHandTransform;
        foodObjects[currentNumberOfProducts - 1].transform.localPosition = new Vector3(0, 0, 0);
        currentNumberOfProducts--;
        handHolder.HandOccupied = true;
        if (currentNumberOfProducts >= foodObjects.Count - 1)
        {
            Debug.Log("OnFinishQuest");

            OnFinishQuest();
        }
    }

}