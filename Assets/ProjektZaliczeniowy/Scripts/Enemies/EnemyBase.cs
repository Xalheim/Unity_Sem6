using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Distance before attacking")]
    private float attackDistance = 10f;

    private bool killed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = PlayerInteraction.instance.transform.position;
        if (Vector3.Distance(playerPosition, transform.position) > attackDistance)
        {
            MoveToPlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    public void EnemyKilled()
    {
        if (!killed)
        {
            killed = true;
            Arena.activeArena.EnemyKilled();
        }
    }

    protected void AttackPlayer()
    {

    }

    protected void MoveToPlayer()
    {

    }

}
