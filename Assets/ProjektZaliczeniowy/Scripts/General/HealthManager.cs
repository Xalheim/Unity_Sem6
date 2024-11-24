using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Maximum health amount of enemy")]
    private int maximumHealth = 100;

    [SerializeField]
    [Tooltip("Decide of object is destroyed upon being killed")]
    private bool isKillable = true;

    [SerializeField]
    [Tooltip("Player use only bool")]
    private bool isPlayer = false;

    private bool isHit;

    private int health;

    private void Start()
    {
        health = maximumHealth;
    }

    public void ApplyDamage(int damage)
    {
        if (!isPlayer)
        {
            DamageEnemy(damage);
        }
        else
        {
            DamagePlayer(damage);
        }
    }

    public void DamageEnemy(int damage)
    {
        if (!isKillable)
        {
            isHit = true;
            return;
        }
        if (health <= damage)
        {
            if (gameObject.TryGetComponent<EnemyBase>(out var enemy))
            {
                enemy.EnemyKilled();
            }
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }

    public void DamagePlayer(int damage)
    {
        PlayerInteraction.instance.StopRigidbodyVelocity();
        if (health <= damage)
        {
            Debug.Log("PLAYER DIED, DO GAME OVER THING :)");
            health = maximumHealth;
        }
        else
        {
            health -= damage;
        }
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maximumHealth);
    }

    public int GetHealth()
    {
        return health;
    }

    public bool GetIsHit()
    {
        return isHit;
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

}
