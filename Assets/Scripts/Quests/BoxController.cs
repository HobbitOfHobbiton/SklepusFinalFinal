using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour, IInteractable, IQuestiable
{
    public event Action<bool> OnFinishQuest = delegate { };

    [SerializeField] private int numberOfBoxLevels = 4;
    [SerializeField] private GameObject closedBox;
    [SerializeField] private GameObject openBox;
    private int currentPuddleLevel = 0;

    public void Interact()
    {
        currentPuddleLevel++;

        if (currentPuddleLevel >= numberOfBoxLevels - 1)
        {
            closedBox.SetActive(true);
            openBox.SetActive(false);
            OnFinishQuest(false);
        }
    }
}
