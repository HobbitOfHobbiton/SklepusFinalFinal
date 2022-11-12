using Controllers;
using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetup : MonoBehaviour
{
    public const String ROOM_ENTERING_FLAVOR_KEY = "ROOM_ENTERING_FLAVOR_KEY";

    public OpenEyes objEyes;

    public GameObject objWakeUpCam;

    public GameObject objPlayer;
    public StudioEventEmitter doorSound;
    public StudioEventEmitter wakeUpSound;

    // Start is called before the first frame update
    void Start()
    {
        Int32 flavor = PlayerPrefs.GetInt(ROOM_ENTERING_FLAVOR_KEY, 0);
        flavor = 0;

        if (flavor == 0)//return from job
        {
            print("Door");
            LeanTween.delayedCall(0.420f, doorSound.Play);
            objWakeUpCam.SetActive(false);
            objEyes.StartOpeningEyes();
        }
        else if (flavor == 1)//nightmare wakeup
        {
            print("Nightmare");
            objEyes.StartOpeningEyes();
            LeanTween.delayedCall(0.01f, wakeUpSound.Play);
            objWakeUpCam.SetActive(true);
            objPlayer.GetComponent<PlayerController>().IsLocked = true;
            LeanTween.delayedCall(0.25f, () =>
            {
                objPlayer.transform.position = new Vector3(-4.39f, 1.536f, 3.078f);
                LeanTween.delayedCall(0.2f, () =>
                {
                    objPlayer.GetComponent<PlayerController>().IsLocked = false;
                });

            });
            //objPlayer.transform.forward = new Vector3(-4.39f, 1.536f, 3.078f);
            LeanTween.rotateAroundLocal(objWakeUpCam, Vector3.right, 90, 1.2f)
                .setEaseOutSine();
            LeanTween.delayedCall(1.5f, () => Destroy(objWakeUpCam));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
