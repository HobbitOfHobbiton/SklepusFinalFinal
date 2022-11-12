using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour, IInteractable, IQuestiable
{
    public event Action<bool> OnFinishQuest = delegate { };

    private int numberOfPuddleLevels = 3;
    private int currentPuddleLevel = 0;
    bool cleaned = false;

    private void Awake()
    {
        currentPuddleLevel = 0;
        numberOfPuddleLevels = transform.childCount;
    }
    public void Interact()
    {
        if (cleaned) return;
        transform.GetChild(currentPuddleLevel).gameObject.SetActive(false);
        currentPuddleLevel++;
        if(currentPuddleLevel >= numberOfPuddleLevels)
        {
            cleaned = true;
            OnFinishQuest(true);
            gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(currentPuddleLevel).gameObject.SetActive(true);
        }
    }


}
