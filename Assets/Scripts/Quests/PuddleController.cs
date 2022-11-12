using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour, IInteractable, IQuestiable
{
    public event Action<bool> OnFinishQuest = delegate { };

    [SerializeField] private int numberOfPuddleLevels = 3;
    private int currentPuddleLevel = 0;

    public void Interact()
    {
        transform.GetChild(currentPuddleLevel).gameObject.SetActive(false);
        currentPuddleLevel++;
        if(currentPuddleLevel<= numberOfPuddleLevels - 1)
        {
            transform.GetChild(currentPuddleLevel).gameObject.SetActive(true);
        }
        else
        {
            OnFinishQuest(true);
        }
    }


}
