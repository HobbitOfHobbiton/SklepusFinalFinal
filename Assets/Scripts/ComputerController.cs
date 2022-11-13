using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationScreen;
    [SerializeField] private Image image;
    [SerializeField] private Email goodInfoEmail;
    [SerializeField] private List<Email> emailsByDays = new List<Email>();
    [SerializeField] private List<TMP_Text> texts = new List<TMP_Text>();
    [SerializeField] private DoorInRoomController doorInRoomController;

    [Space]
    [SerializeField] private string sceneSceneName = "Wobloblo";
    [SerializeField] private string roomSceneName = "Room";

    int sklepusBusted;
    bool isMailTurnedOn = false;
    public void Interact()
    {
        if (isMailTurnedOn) return;

        int currentDay = PlayerPrefs.GetInt("currentDay", 0);

        sklepusBusted = PlayerPrefs.GetInt("sklepusBusted");
        if (sklepusBusted == 0)
        {
            PlayerPrefs.SetInt(RoomSetup.ROOM_ENTERING_FLAVOR_KEY, 1);

            DisplayBadEmail(currentDay);
        }
        else
        {

            DisplayGoodEmail();
        }

        image.gameObject.SetActive(true);
        StartCoroutine(CooldownForGoingToNextLevel());
        isMailTurnedOn = true;
    }

    private void DisplayBadEmail(int currentDay)
    {
        texts[0].text = emailsByDays[currentDay].fromByDay;
        texts[1].text = emailsByDays[currentDay].topicByDay;
        texts[2].text = emailsByDays[currentDay].textByDay;
    }
    private void DisplayGoodEmail()
    {
        texts[0].text = goodInfoEmail.fromByDay;
        texts[1].text = goodInfoEmail.topicByDay;
        texts[2].text = goodInfoEmail.textByDay;
    }

    private void Awake()
    {
        notificationScreen.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(RoomSetup.ROOM_ENTERING_FLAVOR_KEY, 1) == 1)
        {
            doorInRoomController.gameObject.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
        Invoke(nameof(TurnOnScreen),0.1f);
    }

    private void TurnOnScreen()
    {
        notificationScreen.SetActive(true);
    }

    private bool canBeSkippedToNextLevel = false;
    private void Update()
    {
        if (canBeSkippedToNextLevel)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (sklepusBusted == 0)
                {
                    SceneManager.LoadScene(roomSceneName, LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene(sceneSceneName, LoadSceneMode.Single);
                }
            }
        }
    }

    IEnumerator CooldownForGoingToNextLevel()
    {
        yield return new WaitForSeconds(2);
        canBeSkippedToNextLevel = true;
        yield return null;
    }

}

[Serializable]
public class Email
{
    public string textByDay = "";
    public string topicByDay = "";
    public string fromByDay = "";
}