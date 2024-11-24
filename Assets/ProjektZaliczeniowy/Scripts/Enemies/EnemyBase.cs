using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Distance before attacking")]
    protected float attackDistance = 3f;

    [SerializeField]
    [Tooltip("Amount of damage dealt by enemy")]
    protected int damage = 15;

    [SerializeField]
    [Tooltip("Enemy movement speed")]
    protected int speed = 7;

    [SerializeField]
    protected Rigidbody rb;
    protected bool isAttacking = false;
    protected bool isKilled = false;

    protected Vector3 playerPosition;
    protected Vector3 enemyPosition;


    protected virtual void FixedUpdate()
    {
        
    }

    public void EnemyKilled()
    {
        if (!isKilled)
        {
            isKilled = true;
            if (Arena.activeArena != null)
            {
                Arena.activeArena.EnemyKilled();
            }
        }
    }

    protected virtual void AttackPlayer()
    {

    }

    protected virtual void Move()
    {

    }

}
