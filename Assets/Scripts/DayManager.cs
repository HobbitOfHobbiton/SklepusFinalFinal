using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    private int currentDay;
    [SerializeField] private int maxDay = 3;
    [SerializeField] OpenEyes openEyes;
    [SerializeField] Sklepus sklepus;
    [SerializeField] QuestsManager questsManager;
    [SerializeField] TMP_Text currentDayText;
    [SerializeField] private bool isRoomScene = false;

    public const Single DAY_TIME = 20f;

    private const string  dayTextPrefix = "Dzieñ ";

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
        StartCoroutine(DisplayTextStartDay());
    }

    private IEnumerator DisplayTextStartDay()
    {
        if (isRoomScene) yield return null;

        currentDayText.text = dayTextPrefix + (currentDay+1);

        currentDayText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMallAmbient();
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMallMusic();
        yield return new WaitForSeconds(1f);


        currentDayText.gameObject.SetActive(false);


        yield return null;
    }

    private void InitiateSubsequentDay()
    {
        currentDay++;
        PlayerPrefs.SetInt("currentDay", currentDay);
    }

    public void FinishDay(bool sklepusBusted)
    {
        openEyes.StartClosingEyes();
        PlayerPrefs.SetInt(RoomSetup.ROOM_ENTERING_FLAVOR_KEY, 0);

        if (sklepusBusted)
        {
            InitiateSubsequentDay();
            PlayerPrefs.SetInt("sklepusBusted", 1);

        }
        else
        {
            PlayerPrefs.SetInt("sklepusBusted", 0);

        }
        //Load Room scene

    }

    private void WakeUpInRoom()
    {
    } 

}
