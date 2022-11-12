using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image imgFace;

    public GameObject objSmiley;
    public GameObject objAngry;

    public Color AngryColor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AngrySmile());   
    }

    Boolean isSmile = true;
    public IEnumerator AngrySmile()
    {
        yield return null;

        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 2.5f));

        if(isSmile)
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

    public void ShowIntro()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
