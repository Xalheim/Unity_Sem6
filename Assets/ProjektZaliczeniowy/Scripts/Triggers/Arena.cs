using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public static Arena activeArena;

    [SerializeField]
    [Tooltip("Create lists of spawner references")]
    private EnemySpawner[] enemySpawners;

    [SerializeField]
    [Tooltip("Next Arena trigger for another wave")]
    private Arena nextArena;

    [SerializeField]
    [Tooltip("Create lists of door references")]
    private DoorController[] doors;

    private bool isActive;
    private bool used;

    private int aliveEnemies;


    void Start()
    {
        aliveEnemies = enemySpawners.Length;
        if (activeArena)
        {
            activeArena.ResetArena();
        }
        activeArena = this;
    }

    void Update()
    {
        if (isActive && !used)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].LockDoor();
            }
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].SpawnEnemy();
            }
            used = true;
        }

        if (used && aliveEnemies <= 0)
        {
            if (nextArena)
            {
                nextArena.ActivateArena();
            }
            else
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    doors[i].UnlockDoor();
                }
            }
            used = false;
            isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    public void ActivateArena()
    {
        isActive = true;
    }

    private void ResetArena()
    {
        used = false;
        isActive = false;
    }

    public void EnemyKilled()
    {
        aliveEnemies--;
    }

}
