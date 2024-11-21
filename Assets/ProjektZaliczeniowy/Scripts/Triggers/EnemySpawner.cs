using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to enemy prefab for spawning")]
    private GameObject enemy;
    public void SpawnEnemy()
    {
        enemy = Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
