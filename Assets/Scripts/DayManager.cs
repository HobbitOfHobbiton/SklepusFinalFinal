using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private int currentDay;
    [SerializeField] private int maxDay = 3;
    [SerializeField] OpenEyes openEyes;
    [SerializeField] QuestsManager questsManager;

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
        currentDay++;
        PlayerPrefs.SetInt("currentDay", currentDay);

        questsManager.DisplayQuestFromDay(currentDay);
    }


    private void FinishDay(bool sklepusBusted)
    {
        openEyes.StartClosingEyes();
        //Load Room scene

    }

    private void WakeUpInRoom()
    {
    } 

}
