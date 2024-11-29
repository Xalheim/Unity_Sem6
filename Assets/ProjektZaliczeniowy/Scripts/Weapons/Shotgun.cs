using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shotgun : WeaponBase
{
    [SerializeField]
    [Tooltip("Spread of bullets")]
    private float spread = 1.2f;

    private int chargeDamage;
    private float chargeSpread;

    [SerializeField]
    [Tooltip("Reference to sound of racking shotgun")]
    protected AudioSource shotgunRackSFX;

    private Vector3 forwardOffset;

    override protected void Start()
    {
        base.Start();
        chargeDamage = damage;
        chargeSpread = spread;
    }

    void FixedUpdate()
    {
        if (secondaryFire && chargeDamage <= damage)
        {
            chargeDamage += 1;
            chargeSpread += 0.05f;
        }
        if (!secondaryFire && chargeDamage >= damage)
        {
            chargeDamage -= 1;
            chargeSpread -= -0.05f;
        }
    }

    protected override void PrimaryFire()
    {
        base.PrimaryFire();

        RaycastHit hit;

        Vector3 position = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        for (int i = 0; i < 10; i++)
        {
            forwardOffset = (forward + Random.insideUnitSphere * spread * 0.1f).normalized;
            if (Physics.Raycast(position, forwardOffset, out hit, range) && hit.collider.TryGetComponent<HealthManager>(out var hpManager))
            {
                Debug.Log("Hit enemy with ray number " + i + "for damage: " + damage);
                Debug.DrawRay(position, forwardOffset * range, Color.white, 1f);

                hpManager.ApplyDamage(damage);
            }
            else
            {
                Debug.DrawRay(position, forwardOffset * range, Color.red, 1f);
            }
        }
    }

    protected override void SecondaryFire()
    {
        base.SecondaryFire();

        RaycastHit hit;

        Vector3 position = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        for (int i = 0; i < 10; i++)
        {
            forwardOffset = (forward + Random.insideUnitSphere * chargeSpread * 0.1f).normalized;
            if (Physics.Raycast(position, forwardOffset, out hit, range) && hit.collider.TryGetComponent<HealthManager>(out var hpManager))
            {
                Debug.Log("Hit enemy with ray number " + i + "for damage: " + chargeDamage);
                Debug.DrawRay(position, forwardOffset * range, Color.white, 1f);

                hpManager.ApplyDamage(chargeDamage);
            }
            else
            {
                Debug.DrawRay(position, forwardOffset * range, Color.red, 1f);
            }
        }
    }
    public void PlayShotgunRack()
    {
        shotgunRackSFX.Play();
    }
}
