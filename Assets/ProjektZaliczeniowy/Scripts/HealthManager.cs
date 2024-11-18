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

    private int health;

    private void Start()
    {
        health = maximumHealth;
    }

    public void ApplyDamage(int damage)
    {
        if (!isKillable)
        {
            return;
        }
        if (health < damage)
        {
            Destroy(gameObject);
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
}
