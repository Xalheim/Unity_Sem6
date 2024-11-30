using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Teleport Vector")]
    private Vector3 teleportVector;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportVector;
            if (other.TryGetComponent<HealthManager>(out var healthManager))
            {
                healthManager.ApplyDamage(10);
            }
        }
    }
}
