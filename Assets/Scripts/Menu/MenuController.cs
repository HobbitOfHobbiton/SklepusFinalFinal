using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject objIntro;

    public Image imgFace;

    public GameObject objSmiley;
    public GameObject objAngry;

    public Color AngryColor;

    [SerializeField] private StudioEventEmitter _emitter;
    [SerializeField] private StudioEventEmitter _amogus;

    // Start is called before the first frame update
    void Start()
    {
        objIntro.SetActive(false);
        objIntro.GetComponent<Image>().color = new Color(24f / 255f, 24f / 255f, 24f / 255f, 0f);
        StartCoroutine(AngrySmile());
    }

    public void startgame()
    {
        SceneManager.LoadScene("MallFinalFinal", LoadSceneMode.Single);
    }

    Boolean isSmile = true;
    public IEnumerator AngrySmile()
    {
        yield return null;

        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 2.5f));

        if (isSmile)
        {
            isSmile = false;
            objAngry.SetActive(true);
            objSmiley.SetActive(false);
            imgFace.color = AngryColor;
        }
        else
        {
            objAngry.SetActive(false);
            objSmiley.SetActive(true);
            isSmile = true;
            imgFace.color = Color.white;
        }

        StartCoroutine(AngrySmile());
    }

    public GameObject objFirstNews;
    public GameObject objSecondNews;
    public TextMeshProUGUI txtAreYouSure;
    public void ShowIntro()
    {
        print("Intro");

        objIntro.SetActive(true);
        //objFirstNews.SetActive(false);
        //objSecondNews.SetActive(false);
        txtAreYouSure.gameObject.SetActive(false);

        LeanTween.value(0f, 1f, 0.4f)
            .setOnUpdate((Single val) =>
            {
                objIntro.GetComponent<Image>().color = new Color(24f / 255f, 24f / 255f, 24f / 255f, val);
            });

        LeanTween.delayedCall(1.8f, () =>
        {
            _emitter.Play();
            LeanTween.moveLocal(objFirstNews, new Vector3(0, -211), 1f)
                .setEaseOutSine()
                .setOnComplete(() =>
                {
                    LeanTween.delayedCall(3f, () =>
                    {
                        LeanTween.moveLocal(objFirstNews, new Vector3(0, -1200), 1f)
                            .setEaseInSine()
                            .setOnComplete(() =>
                            {
                                LeanTween.delayedCall(1.1f, () =>
                                {

                                    _emitter.Play();
                                    
                                    LeanTween.moveLocal(objSecondNews, new Vector3(0, -211), 1f)
                                        .setEaseOutSine()
                                        .setOnComplete(() =>
                                        {
                                            LeanTween.delayedCall(2.5f, () =>
                                            {
                                                LeanTween.moveLocal(objSecondNews, new Vector3(0, -1200), 1f)
                                                    .setEaseInSine()
                                                    .setOnComplete(() =>
                                                    {
                                                        txtAreYouSure.color = new Color(txtAreYouSure.color.r, txtAreYouSure.color.g, txtAreYouSure.color.b, 0);
                                                        txtAreYouSure.gameObject.SetActive(true);

                                                        LeanTween.delayedCall(1.1f, () =>
                                                        {
                                                            _amogus.Play();
                                                            LeanTween.value(0f, 1f, 2f)
                                                                .setOnUpdate((Single val) =>
                                                                {
                                                                    txtAreYouSure.color = new Color(txtAreYouSure.color.r,
                                                                        txtAreYouSure.color.g,
                                                                        txtAreYouSure.color.b, val);
                                                                })
                                                                .setOnComplete(() =>
                                                                {
                                                                    LeanTween.delayedCall(3f, () =>
                                                                    {
                                                                        objIntro.SetActive(false);
                                                                        txtAreYouSure.gameObject.SetActive(false);
                                                                    });
                                                                });

                                                        });

                                                    });

                                            });

                                        });

                                });

                            });

                    });

                });
        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
