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


