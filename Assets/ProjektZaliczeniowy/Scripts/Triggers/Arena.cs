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
    private bool completed;

    private int aliveEnemies;
    private bool subarena;


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

        if (used && aliveEnemies <= 0 && !completed)
        {
            if (nextArena)
            {
                isActive = false;
                StartCoroutine(ActivateSubarena());
            }
            else
            {
                StartCoroutine(UnlockArenaDoors());
            }
            isActive = false;
            completed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive && !subarena && other.CompareTag("Player"))
        {
            ActivateArena();
        }
    }

    public void ActivateArena()
    {
        activeArena = this;
        if (nextArena)
        {
            nextArena.SetSubArena();
        }
        isActive = true;
        aliveEnemies = enemySpawners.Length;
    }

    private void ResetArena()
    {
        used = false;
        isActive = false;
    }

    public void EnemyKilled()
    {
        aliveEnemies--;
        Debug.Log("ENEMY KILLED, current amount: " + aliveEnemies);
    }

    public void SetSubArena()
    {
        subarena = true;
    }

    private IEnumerator ActivateSubarena()
    {
        yield return new WaitForSeconds(1f);
        nextArena.ActivateArena();
    }

    private IEnumerator UnlockArenaDoors()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].UnlockDoor();
        }
        activeArena = null;
    }

}
