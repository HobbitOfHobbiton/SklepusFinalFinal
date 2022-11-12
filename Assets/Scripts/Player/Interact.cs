using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionString;
    private string interactString = "Interakcja";

    private IInteractable currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IInteractable>()!= null)
        {
            interactionString.gameObject.SetActive(true);
            interactionString.text = interactString;
            currentInteractable = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            interactionString.gameObject.SetActive(false);
            currentInteractable = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}
