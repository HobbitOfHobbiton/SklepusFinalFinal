using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private int currentDay;
    [SerializeField] private int maxDay = 3;
    [SerializeField] OpenEyes openEyes;
    [SerializeField] Sklepus sklepus;
    [SerializeField] QuestsManager questsManager;

    public const Single DAY_TIME = 20f;

    private void Awake()
    {
        currentDay = PlayerPrefs.GetInt("currentDay", 0);
    }

    private void Start()
    {
        StartDay();
    }


    private void StartDay()
    {
        Debug.Log("Current day: " + currentDay);
        openEyes.StartOpeningEyes();
        sklepus.PlayDaySequence(currentDay);
        questsManager.DisplayQuestFromDay(currentDay);
    }

    private void InitiateSubsequentDay()
    {
        currentDay++;
        PlayerPrefs.SetInt("currentDay", currentDay);

    }

    public void FinishDay(bool sklepusBusted)
    {
        openEyes.StartClosingEyes();
        if (sklepusBusted)
        {
            InitiateSubsequentDay();
            PlayerPrefs.SetInt("sklepusBusted", 1);
        }
        else
            PlayerPrefs.SetInt("sklepusBusted", 0);

        //Load Room scene

    }

    private void WakeUpInRoom()
    {
    } 

}
