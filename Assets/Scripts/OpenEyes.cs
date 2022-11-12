using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenEyes : MonoBehaviour
{
    [SerializeField] private float openingEyesSpeed = 1;
    [SerializeField] private Image eyesImage;

    private bool areOpeningEyes = false;
    private bool areClosingEyes = false;

    public void StartOpeningEyes()
    {
        Color col = new Color(0, 0, 0, 1);

        eyesImage.color = col;
        areOpeningEyes = true;
    }

    public void StartClosingEyes()
    {
            areClosingEyes = true;
    }

    public void StartBlinking()
    {
        StartCoroutine(Blink());
    }

    private void Update()
    {
        if (areOpeningEyes)
        {
            Color col = ProceedWithOpeningOrClosing(false);

            if (col.a <= 0)
            {
                col.a = 0;
                eyesImage.color = col;

                areOpeningEyes = false;
            }
        }
        if (areClosingEyes)
        {
            Color col = ProceedWithOpeningOrClosing(true);

            if (col.a >= 1)
            {
                col.a = 1;
                eyesImage.color = col;

                areClosingEyes = false;
            }
        }
    }

    private Color ProceedWithOpeningOrClosing(bool close)
    {
        float eyesAlpha = eyesImage.color.a;
        if(!close)
            eyesAlpha -= Time.deltaTime * openingEyesSpeed;
        else
            eyesAlpha += Time.deltaTime * openingEyesSpeed;

        Color col = eyesImage.color;
        col.a = eyesAlpha;
        eyesImage.color = col;

        return col;
    }

    private IEnumerator Blink()
    {
        StartClosingEyes();
        yield return new WaitForSeconds(1.5f);
        areClosingEyes = false;
        StartOpeningEyes();

        yield return null;
    }


}
