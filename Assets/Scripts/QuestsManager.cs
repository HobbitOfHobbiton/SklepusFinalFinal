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


    public void DisplayQuestFromDay(int day)
    {
        switch (day)
        {
            case 0:
                {
                    text.text = day0Text;
                    break;
                }
            case 1:
                {
                    text.text = day1Text;

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
    
}


