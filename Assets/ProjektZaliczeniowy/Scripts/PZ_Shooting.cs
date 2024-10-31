using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputSystem))]

public class PZ_Shooting : MonoBehaviour
{
    
    public void OnShoot (InputValue value)
    {
        Console.WriteLine("test");
    }
}
