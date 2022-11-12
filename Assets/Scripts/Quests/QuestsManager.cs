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

    [Space]
    [Header("Day 0 quest variables")]
    [SerializeField] private FoodstackController foodStack;
    [SerializeField] private ShelfFoodPutter shelfFoodPutter;

    [Space]
    [Header("Day 1 quest variables")]
    [SerializeField] private BoxController boxController;



    public void DisplayQuestFromDay(int day)
    {
        Debug.Log("init " + day);

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
        shelfFoodPutter.OnFinishQuest += FinishDay0;
    }

    private void FinishDay0()
    {
        openEyes.StartClosingEyes();
        text.text = "";
        shelfFoodPutter.OnFinishQuest -= FinishDay0;
        StartCoroutine(GoToBedroomInTime(2));
    }

    private void QuestDay1Initialize()
    {
        foodStack.gameObject.SetActive(false);
        shelfFoodPutter.gameObject.SetActive(false);

        boxController.gameObject.SetActive(true);
        shelfFoodPutter.OnFinishQuest += FinishDay1;

    }

    private void FinishDay1()
    {
        openEyes.StartClosingEyes();
        text.text = "";
        boxController.OnFinishQuest -= FinishDay1;
        StartCoroutine(GoToBedroomInTime(2));
    }

    private IEnumerator GoToBedroomInTime(float timeToGoThrough)
    {
        yield return new WaitForSeconds(timeToGoThrough);
        SceneManager.LoadScene("Room", LoadSceneMode.Single);
        yield return null;
    }
}


