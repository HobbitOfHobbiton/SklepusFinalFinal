using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodstackController : MonoBehaviour, IInteractable
{
    [SerializeField] private int totalNumberOfProducts;
    private int currentNumberOfProducts;
    private List<GameObject> foodObjects = new List<GameObject>();
    [SerializeField] private Transform playerHandTransform;
    public void InititializeFoodstack()
    {
        currentNumberOfProducts = totalNumberOfProducts;
    }

    public void Interact()
    {

        foodObjects[currentNumberOfProducts].transform.parent = playerHandTransform;
        foodObjects[currentNumberOfProducts].transform.position = new Vector3(0, 0, 0);
    }


}