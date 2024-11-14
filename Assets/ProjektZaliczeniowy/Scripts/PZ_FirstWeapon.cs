using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstWeapon : MonoBehaviour
{
    private Boolean AlternateTrigger;
    [SerializeField]
    [Tooltip("Reference to InputAction responsible for toggling second weapon shooting style")]
    private InputActionReference AlternateFireAction;
    // Start is called before the first frame update
    void Start()
    {
        AlternateTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AlternateFireAction.action.IsPressed())
        {
            AlternateTrigger = true;
        }
        else
        {
            AlternateTrigger = false;
        }
    }

    public void FireWeapon()
    {
        if (AlternateTrigger)
        {
            Debug.Log("big shoot");
        }
        else
        {
            Debug.Log("Shoot");
        }

    }
}
