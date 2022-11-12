using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfFoodPutter : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> targetObjects = new List<GameObject>();
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Transform handTransform;
    [SerializeField] private HandHolder handHolder;

    int currentProduct = 0;

    public void Interact()
    {
        PutProductOnShelf();
    }

    private void PutProductOnShelf()
    {
        if (currentProduct >= targetObjects.Count) return;
        if (handHolder.HandOccupied == false) return;

        targetObjects[currentProduct].GetComponent<MeshRenderer>().material = targetMaterial;
        Destroy(handTransform.GetChild(0).gameObject);
        currentProduct++;
        handHolder.HandOccupied = false;


        //if (currentProduct >= targetObjects.Count - 1) FinishDay1;
    }
}
