using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationScreen;
    [SerializeField] private Image image;
    [SerializeField] private Email goodInfoEmail;
    [SerializeField] private List<Email> emailsByDays = new List<Email>();
    [SerializeField] private List<TMP_Text> texts = new List<TMP_Text>();
    public void Interact()
    {
        int currentDay = PlayerPrefs.GetInt("currentDay", 0);
        texts[0].text = emailsByDays[0].fromByDay;
        texts[1].text = emailsByDays[0].topicByDay;
        texts[2].text = emailsByDays[0].textByDay;
        image.gameObject.SetActive(true);
    }

    private void Awake()
    {
        notificationScreen.SetActive(false);
    }

    private void Start()
    {
        Invoke(nameof(TurnOnScreen),0.1f);
    }

    private void TurnOnScreen()
    {
        notificationScreen.SetActive(true);
    }
}

[Serializable]
public class Email
{
    public string textByDay = "";
    public string topicByDay = "";
    public string fromByDay = "";
}