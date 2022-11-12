using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHolder : MonoBehaviour
{
    private bool handOccupied = false;
    public bool HandOccupied { get; set; }
    public static event Action<bool> OnHandOccupyChanged;

}
