using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = System.Random;

public class SklepusTurnerController : MonoBehaviour
{
    [SerializeField] private DarkSklepusFaceController sklepus;
    [SerializeField] private bool canMove;
    [SerializeField] private float speed = 10f;
    [SerializeField] private FlickeringLightController flickeringLightController;
    private GameObject _player;

    private void Awake()
    {
        if (flickeringLightController)
        {
            flickeringLightController.enabled = false;
        }

        _player = FindObjectOfType<PlayerController>().gameObject;
    }
    private void Update()
    {
        if (canMove)
        {
            var position = _player.transform.position;
            sklepus.transform.rotation = Quaternion.RotateTowards(sklepus.transform.rotation, Quaternion.LookRotation(new Vector3(position.x,0,position.z)), Time.deltaTime * speed);
            
            

            print($"Dot: {Vector3.Dot((_player.transform.position - sklepus.transform.position).normalized, sklepus.transform.forward)}");
            if(Vector3.Dot((_player.transform.position-sklepus.transform.position).normalized,sklepus.transform.forward)>0.9f)
            {
                sklepus.SwitchFaces(!sklepus.isInDarkMode);
                if (flickeringLightController != null)
                {
                    flickeringLightController.enabled = true;
                    
                }
            }
            else
            {
                sklepus.SwitchFaces(false);
                flickeringLightController.enabled = false;
            }
            
        }

        
    }
}
