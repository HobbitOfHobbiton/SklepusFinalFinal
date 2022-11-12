using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSklepusFaceController : MonoBehaviour
{
    [SerializeField] private Material darkFace;


    private void Start()
    {
       InvokeRepeating(nameof(CreepOut),0,5f);
    }

    private void CreepOut()
    {
        LeanTween.value(gameObject, new Vector2(1, 1), new Vector2(1, 15),2f).setOnUpdate((Vector2 value) =>
        {
            darkFace.mainTextureScale = value;
            
        }).setEaseOutSine().setLoopPingPong(1);
        
        
        LeanTween.value(gameObject, new Vector2(0, 0), new Vector2(10, 0),2f).setOnUpdate((Vector2 value) =>
        {
            darkFace.mainTextureOffset = value;
            
        }).setEaseOutSine().setLoopPingPong(1);

    }
}
