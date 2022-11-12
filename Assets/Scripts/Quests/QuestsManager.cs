using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [Space]
    [SerializeField] string day0Text = "Przenieœ s³oiki na pó³kê sklepow¹.";
    [SerializeField] string day1Text = "Posprz¹taj na dziale z nabia³em.";
    [SerializeField] string day2Text = "Wyczyœæ rega³ z makaronami.";
    [SerializeField] string day3Text = "Sklepuœ ma problem sprzêtowy - pomó¿ mu.";

    [Space]
    [Header("Day0 quest variables")]
    [SerializeField] private FoodstackController foodStack;
    [SerializeField] private ShelfFoodPutter shelfFoodPutter;
    [SerializeField] private OpenEyes openEyes;




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
        shelfFoodPutter.OnFinishQuest += FinishDay1;
    }

    private void FinishDay1()
    {
        openEyes.StartClosingEyes();
        text.text = "";
        shelfFoodPutter.OnFinishQuest -= FinishDay1;

    }

    private void QuestDay1Initialize()
    {
        foodStack.gameObject.SetActive(false);
        shelfFoodPutter.gameObject.SetActive(false);
    }
}


