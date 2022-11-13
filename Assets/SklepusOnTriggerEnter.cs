using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class SklepusOnTriggerEnter : MonoBehaviour
{
    private PlayerController _player;
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < 3f)
        {
            FindObjectOfType<PlayerController>().gameObject.transform.position = FindObjectOfType<SpawnPointExploder>().transform.position;
            FindObjectOfType<PlayerController>().gameObject.transform.rotation = FindObjectOfType<SpawnPointExploder>().transform.rotation;
            FindObjectOfType<PlayerController>().enabled = false;
            FindObjectOfType<ChaseStateController>().DisableSklepusys();
            FindObjectOfType<SpawnPointExploder>().Activate();
        }
    }
}
