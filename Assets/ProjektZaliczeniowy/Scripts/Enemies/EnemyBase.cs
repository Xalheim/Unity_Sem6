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
    protected Vector3 gunPosition;


    protected virtual void FixedUpdate()
    {
        if (transform.position.y <= 100)
        {
            HealthManager hpManager = GetComponent<HealthManager>();
            hpManager.ApplyDamage(9999);
            EnemyKilled();
        }
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
