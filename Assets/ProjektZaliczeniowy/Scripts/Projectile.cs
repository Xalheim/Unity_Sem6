using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage;
    private int speed;
    private float range;
    private Vector3 direction;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }

    public void Initialize(int damage, int speed, int range, LayerMask layerMask, Vector3 direction)
    {
        this.damage = damage;
        this.speed = speed;
        this.range = range;
        this.direction = direction;
        gameObject.layer = LayerMask.GetMask(layerMask.ToString());
        transform.GetChild(0).gameObject.layer = LayerMask.GetMask(layerMask.ToString());

        Invoke(nameof(AoeDamage), 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<HealthManager>(out var hpManager))
        {
            hpManager.ApplyDamage(damage);
        }

        AoeDamage();
    }

    private void AoeDamage()
    {
        var colliders = Physics.OverlapSphere(transform.position, range, 7);
        for (int i = 0; i < colliders.Length; i++)
        {
            var current = colliders[i];
            if (current.TryGetComponent<HealthManager>(out var hpManager))
            {
                hpManager.ApplyDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
