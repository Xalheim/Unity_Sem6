using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public enum ProjectileType
{
    Rocket, PlasmaRocket, Grenade, EnemyBullet
};

public class Projectile : MonoBehaviour
{
    private int damage;
    private int speed;
    private float range;
    private float pushStrength;
    private Vector3 direction;
    private Rigidbody rb;
    private bool isRocket;

    private ProjectileType projType;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetupProjectileByType();
        if (projType == ProjectileType.PlasmaRocket)
        {
            StartCoroutine(PrimeExplosive(4f));
        }
        else if (projType == ProjectileType.Grenade)
        {
            StartCoroutine(PrimeExplosive(3f));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (projType == ProjectileType.Rocket || projType == ProjectileType.PlasmaRocket || projType == ProjectileType.EnemyBullet)
        {
            rb.velocity = (direction * speed * Time.fixedDeltaTime);
        }
    }

    public void Initialize(int damage, int speed, int range, float pushStrength, LayerMask layerMask, Vector3 direction, ProjectileType projType)
    {
        this.damage = damage;
        this.speed = speed;
        this.range = range;
        this.pushStrength = pushStrength;
        this.direction = direction;
        this.projType = projType;
        gameObject.layer = LayerMask.GetMask(layerMask.ToString());
        transform.GetChild(0).gameObject.layer = LayerMask.GetMask(layerMask.ToString());

        Invoke(nameof(AoeDamage), 20f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.GetType());
        if (collision.gameObject.GetComponent<Projectile>())
        {
            return;
        }

        if (projType == ProjectileType.Rocket)
        {
            if (collision.gameObject.TryGetComponent<HealthManager>(out var hpManager) && !hpManager.IsPlayer())
            {
                //Debug.Log("Direct hit");
                hpManager.ApplyDamage(damage);
            }
            AoeDamage();
        }

        if (projType == ProjectileType.Grenade)
        {
            if (collision.gameObject.TryGetComponent<HealthManager>(out var hpManager) && !hpManager.IsPlayer())
            {
                //Debug.Log("Direct hit");
                hpManager.ApplyDamage(damage);
                AoeDamage();
            }
        }

        if (projType == ProjectileType.PlasmaRocket)
        {
            Destroy(gameObject);
        }

        if (projType == ProjectileType.EnemyBullet)
        {
            if (collision.gameObject.TryGetComponent<HealthManager>(out var hpManager) && hpManager.IsPlayer())
            {
                //Debug.Log("Enemy hit player with a bullet for " + damage + " damage");
                hpManager.ApplyDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void AoeDamage()
    {
        if (range <= 0)
        {
            Destroy(gameObject);
            return;
        }
        var colliders = Physics.OverlapSphere(transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            var current = colliders[i];
            if (current.TryGetComponent<HealthManager>(out var hpManager))
            {
                if (!hpManager.IsPlayer())
                {
                    hpManager.ApplyDamage(damage);
                }
                else
                {
                    hpManager.ApplyDamage(damage / 2);
                }
                if (current.TryGetComponent<Rigidbody>(out var rb))
                {
                    Vector3 pushVector = (current.transform.position - transform.position).normalized * pushStrength;
                    rb.AddForce(pushVector);
                    //Debug.Log(pushVector);
                }

            }
        }

        Destroy(gameObject);
    }

    private void SetupProjectileByType()
    {
        if (projType == ProjectileType.Rocket || projType == ProjectileType.PlasmaRocket || projType == ProjectileType.EnemyBullet)
        {
            rb.useGravity = false;
        }
        else if (projType == ProjectileType.Grenade)
        {
            rb.useGravity = true;
            rb.AddRelativeForce(new Vector3(0, speed / 8, speed));
        }
    }

    private IEnumerator PrimeExplosive(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        AoeDamage();
    }

}
