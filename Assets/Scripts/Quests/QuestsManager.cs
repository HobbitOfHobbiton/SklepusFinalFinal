using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [Space]
    [SerializeField] string day0Text = "Przenie� s�oiki na p�k� sklepow�.";
    [SerializeField] string day1Text = "Posprz�taj na dziale z nabia�em.";
    [SerializeField] string day2Text = "Wyczy�� rega� z makaronami.";
    [SerializeField] string day3Text = "Sklepu� ma problem sprz�towy - pom� mu.";

    [Space]
    [Header("Day0 quest variables")]
    [SerializeField] private FoodstackController foodStack;
    [SerializeField] private ShelfFoodPutter shelfFoodPutter;
    [SerializeField] private OpenEyes openEyes;
    [SerializeField] private IQuestiable day0IQuestiable;




    public void DisplayQuestFromDay(int day)
    {
        switch (day)
        {
            case 0:
                {
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
        foodStack.gameObject.SetActive(true);
        foodStack.InititializeFoodstack();
        shelfFoodPutter.gameObject.SetActive(true);
        day0IQuestiable.OnFinishQuest += FinishDay1;
    }

    private void FinishDay1()
    {
        openEyes.StartClosingEyes();
        text.text = "";
    }

    private void QuestDay1Initialize()
    {
        foodStack.gameObject.SetActive(false);
        shelfFoodPutter.gameObject.SetActive(false);
    }
}


