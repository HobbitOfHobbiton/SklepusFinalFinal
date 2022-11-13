using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class OnPlayerEnterTurnScriptOn : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;
    private AsyncOperation asyncLoad;
    private AsyncOperation asyncUnload;

    private void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
        StartCoroutine(LoadScene());
        
    }
    private IEnumerator LoadScene()
    {
        yield return null;
        asyncLoad = SceneManager.LoadSceneAsync("MallFinalFinalDark");
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            print($"LoadingScene: {asyncLoad.progress}");
            yield return null;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(TurnScriptAndDisablePlayer());
        }
    }
    private IEnumerator TurnScriptAndDisablePlayer()
    {
        yield return new WaitForSeconds(0.25f);
        FindObjectOfType<PlayerController>().enabled = false;
        FindObjectOfType<SklepusTurnerController>().canMove = true;
        yield return new WaitForSeconds(5f);
        TurnOfLights();
    }
    private void TurnOfLights()
    {
        LeanTween.value(this.gameObject, 0, 1f, 4f).setOnUpdate(value =>
        {
            colorAdjustments.colorFilter.Interp(colorAdjustments.colorFilter.value,Color.black, value);
        }).setOnComplete(()=>asyncLoad.allowSceneActivation=true);
        
    }
}
