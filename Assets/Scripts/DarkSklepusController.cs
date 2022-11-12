using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.AI;

public class DarkSklepusController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMesh;
    private PlayerController player;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        navMesh.SetDestination(player.transform.position);
    }

}
