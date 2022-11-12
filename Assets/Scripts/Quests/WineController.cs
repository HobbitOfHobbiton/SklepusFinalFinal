using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineController : MonoBehaviour, IInteractable, IQuestiable
{
    public event Action<bool> OnFinishQuest = delegate { };
    [SerializeField] private GameObject bottle;

    public void Interact()
    {
        bottle.SetActive(false);
        OnFinishQuest(true);
    }


}
