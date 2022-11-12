using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI txtTimer;

    private Single _currentTime = 20;

    public static event Action OnTimerEnded;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Counting());

    }

    public void StartTimer()
    {
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        txtTimer.gameObject.transform.localScale = Vector3.one;

        if(_currentTime <= 0)
        {
            OnTimerEnded?.Invoke();
            print("timer ended");
            LeanTween.scale(gameObject, Vector3.zero, 0.5f)
                .setEaseInSine();

            yield break;
        }

        yield return new WaitForSeconds(1f);
        _currentTime--;
        txtTimer.text = ((Int32)_currentTime).ToString();
        LeanTween.scale(txtTimer.gameObject, new Vector3(0.85f, 0.85f, 0.85f), 0.85f);

        StartCoroutine(Counting());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
