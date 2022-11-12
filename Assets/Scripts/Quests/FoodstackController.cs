using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodstackController : MonoBehaviour
{
    [SerializeField] private int totalNumberOfProducts;
    private int currentNumberOfProducts;

    private void InititializeFoodstack()
    {
        currentNumberOfProducts = totalNumberOfProducts;
    }
}
