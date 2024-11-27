using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArena : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to arena")]
    private Arena arena;


    public void CallArenaActivation()
    {
        arena.ActivateArena();
    }
}
