using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour, IInteractable, IQuestiable
{
    public event Action OnFinishQuest = delegate { };

    [SerializeField] private GameObject puddleObject;

    [SerializeField] private int numberOfPuddleLevels = 4;
    private int currentPuddleLevel = 0;

    public void Interact()
    {
        currentPuddleLevel++;
        Vector3 size = puddleObject.transform.localScale;
        size.z *= 0.5f;
        size.x *= 0.5f;
        puddleObject.transform.localScale = size;
        
        if (currentPuddleLevel >= numberOfPuddleLevels - 1)
            OnFinishQuest();

    }


}
