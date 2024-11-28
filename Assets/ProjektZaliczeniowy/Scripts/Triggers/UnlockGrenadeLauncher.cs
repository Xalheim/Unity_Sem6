using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGrenadeLauncher : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to Progress Manager")]
    private PlayerProgressManager progressManager;

    [SerializeField]
    [Tooltip("Reference to Parent")]
    private GameObject parent;

    [SerializeField]
    [Tooltip("Reference to Arena")]
    private Arena arena;

    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            PlayerInteraction playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();
            if (!playerInteraction.VerifyWeaponPossession(2))
            {
                progressManager.UnlockGrenadeLauncher();
                playerInteraction.SwitchToWeapon(2);
            }
            triggered = true;
            arena.ActivateArena();
            Destroy(parent);
            Destroy(gameObject);
        }
    }
}
