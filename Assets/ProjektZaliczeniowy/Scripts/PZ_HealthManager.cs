using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_HealthManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Maximum health amount of enemy")]
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        if (health < damage)
        {
            Destroy(gameObject);
        }
        else
        {
            health -= damage;
        }
    }
}
