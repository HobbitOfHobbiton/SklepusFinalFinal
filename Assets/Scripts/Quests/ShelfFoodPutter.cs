using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfFoodPutter : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> targetObjects = new List<GameObject>();
    [SerializeField] private Material targetMaterial;
    int currentProduct = 0;

    public void Interact()
    {
        PutProductOnShelf();
    }

    private void PutProductOnShelf()
    {
        if (currentProduct >= targetObjects.Count) return;

        targetObjects[currentProduct].GetComponent<MeshRenderer>().material = targetMaterial;
        currentProduct++;
    }
}
