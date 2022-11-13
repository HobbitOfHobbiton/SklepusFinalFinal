using Controllers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestsManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [Space]
    [SerializeField] string day0Text = "Przenieœ s³oiki na pó³kê sklepow¹.";
    [SerializeField] string day1Text = "Posprz¹taj na dziale z nabia³em.";
    [SerializeField] string day2Text = "Wyczyœæ rega³ z makaronami.";
    [SerializeField] string day3Text = "Sklepuœ ma problem sprzêtowy - pomó¿ mu.";

    [Space]
    [SerializeField] private OpenEyes openEyes;
    [SerializeField] private DayManager dayManager;
    [SerializeField] private bool isRoom = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Sklepus sklepus;

    [Space]
    [SerializeField] private string roomSceneName = "Room";

    [Space]
    [Header("Day 0 quest variables")]
    [SerializeField] private FoodstackController foodStack;
    [SerializeField] private ShelfFoodPutter shelfFoodPutter;
    [SerializeField] private PuddleController puddleController;

    [Space]
    [Header("Day 1 quest variables")]
    [SerializeField] private BoxController boxController;
    [SerializeField] private WineController wineController;
    [SerializeField] private Transform placeOfSpawnPlayer;
    [SerializeField] private Transform placeOfSpawnSklepus;



    public void DisplayQuestFromDay(int day)
    {
        if (isRoom)
        {
            text.text = "";
            return;
        }
        switch (day)
        {
            case 0:
                {
                    Debug.Log("init " + day);
                    text.text = day0Text;
                    QuestDay0Initialize();
                    break;
                }
            case 1:
                {
                    text.text = day1Text;
                    QuestDay1Initialize();

                    break;
                }
            case 2:
                {
                    text.text = day2Text;
                    QuestDay2Initialize();
                    break;
                }
            case 3:
                {
                    text.text = day3Text;
                    break;
                }
        }

    }
    private void QuestDay0Initialize()
    {
        Debug.Log("QuestDay0Initialize");
        foodStack.gameObject.SetActive(true);
        foodStack.InititializeFoodstack();
        shelfFoodPutter.gameObject.SetActive(true);
        puddleController.gameObject.SetActive(true);
        shelfFoodPutter.OnFinishQuest += FinishDay0;
        puddleController.OnFinishQuest += FinishDay0;
        Timer.OnTimerEnded += () => FinishDay0(false);

    }

    private void FinishDay0(bool sklepusBusted)
    {
        dayManager.FinishDay(sklepusBusted);
        openEyes.StartClosingEyes();
        text.text = "";
        shelfFoodPutter.OnFinishQuest -= FinishDay0;
        puddleController.OnFinishQuest -= FinishDay0;
        Timer.OnTimerEnded -= () => FinishDay0(false);

        StartCoroutine(GoToBedroomInTime(2));
    }

    private void QuestDay1Initialize()
    {
        Timer.OnTimerEnded += () => FinishDay0(false);

        player.GetComponent<PlayerController>().IsLocked = true;
        LeanTween.delayedCall(0.01f, () =>
        {
            player.transform.position = placeOfSpawnPlayer.position;
            LeanTween.delayedCall(0.2f, () =>
            {
                player.GetComponent<PlayerController>().IsLocked = false;
            });

        });
        sklepus.transform.position = placeOfSpawnSklepus.position;

        foodStack.gameObject.SetActive(false);
        shelfFoodPutter.gameObject.SetActive(false);
        puddleController.gameObject.SetActive(false);

        boxController.gameObject.SetActive(true);
        wineController.gameObject.SetActive(true);
        boxController.OnFinishQuest += FinishDay1;

    }

    private void FinishDay1(bool sklepusBusted)
    {
        dayManager.FinishDay(sklepusBusted);
        openEyes.StartClosingEyes();
        text.text = "";
        boxController.OnFinishQuest -= FinishDay1;
        Timer.OnTimerEnded -= () => FinishDay1(false);

        StartCoroutine(GoToBedroomInTime(2));
    }

    private void QuestDay2Initialize()
    {
        Timer.OnTimerEnded += () => FinishDay0(false);

        boxController.gameObject.SetActive(false);
        wineController.gameObject.SetActive(false);



        //superKerfus.OnFinishQuest += FinishDay2;
        //exit.OnFinishQuest += FinishDay2;

    }

    private void FinishDay2(bool sklepusBusted)
    {

        dayManager.FinishDay(sklepusBusted);
        Timer.OnTimerEnded -= () => FinishDay2(false);

        openEyes.StartClosingEyes();
        text.text = "";
        boxController.OnFinishQuest -= FinishDay2;

    }


    private IEnumerator GoToBedroomInTime(float timeToGoThrough)
    {
        yield return new WaitForSeconds(timeToGoThrough);
        SceneManager.LoadScene(roomSceneName, LoadSceneMode.Single);
        yield return null;
    }
}


