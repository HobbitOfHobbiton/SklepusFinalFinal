using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DarkSklepusFaceController : MonoBehaviour
{
    [SerializeField] private Material darkFace;
    [SerializeField] private Material normalFace;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool isInDarkMode;
    private Material[] _materials;


    private void Start()
    {
        _materials = meshRenderer.materials;
       InvokeRepeating(nameof(CreepOut),0,5f);
    }

    private void Update()
    {
        if (isInDarkMode)
        {
            _materials[3] = darkFace;
            
        }else
        {
            _materials[3] = normalFace;
        }
        
        meshRenderer.materials = _materials;
    }

    private void CreepOut()
    {
        LeanTween.value(gameObject, new Vector2(1, 1), new Vector2(1, Random.Range(-15,15)),2f).setOnUpdate((Vector2 value) => 
        {
                darkFace.mainTextureScale = value;
            
            }).setEaseOutSine().setLoopPingPong(1);
        
            LeanTween.value(gameObject, new Vector2(0, 0), new Vector2(Random.Range(-10,10), 0),2f).setOnUpdate((Vector2 value) =>
            {
                darkFace.mainTextureOffset = value;
            
            }).setEaseOutSine().setLoopPingPong(1);
    
        
        
    }
}
