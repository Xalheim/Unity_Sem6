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

    private bool subarena;

    private bool isActive;
    private bool completed;

    private int aliveEnemies;

    private void Start()
    {
        if (nextArena != null)
        {
            nextArena.SetSubArena();
        }
    }

    void Update()
    {
        if (isActive && aliveEnemies <= 0 && !completed)
        {
            completed = true;
            isActive = false;
            if (nextArena != null)
            {
                StartCoroutine(ActivateSubarena());
            }
            else
            {
                StartCoroutine(UnlockArenaDoors());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!completed && !subarena && !isActive && other.CompareTag("Player"))
        {
            ActivateArena();
        }
    }

    public void ActivateArena()
    {
        activeArena = this;
        isActive = true;
        aliveEnemies = enemySpawners.Length;
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].LockDoor();
        }
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].SpawnEnemy();
        }
    }

    public void EnemyKilled()
    {
        aliveEnemies--;
        //Debug.Log("ENEMY KILLED, current amount: " + aliveEnemies);
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
