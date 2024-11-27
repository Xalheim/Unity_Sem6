using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorBreakerBoxManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reference to door that will be unlocked")]
    private DoorController doorController;

    [SerializeField]
    [Tooltip("Amount of locks required to be broken")]
    private int locks;

    private int count = 0;


    // Update is called once per frame
    void Update()
    {
        if (count >= locks)
        {
            doorController.UnlockDoor();
            enabled = false;
        }
    }

    public void LockDestroyed()
    {
        count += 1;
    }
}
