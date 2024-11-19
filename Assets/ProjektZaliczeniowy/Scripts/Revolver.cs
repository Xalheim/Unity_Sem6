using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Revolver : WeaponBase
{
    protected override void PrimaryFire()
    {
        base.PrimaryFire();

        RaycastHit hit;
        Vector3 position = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        if (Physics.Raycast(position, forward, out hit, range, enemyMask) && hit.collider.TryGetComponent<HealthManager>(out var hpManager))
        {
            Debug.Log("Hit enemy for " + damage + "damage");
            Debug.DrawRay(position, forward * range, Color.white);

            if (hpManager != null)
            {
                hpManager.ApplyDamage(damage);
            }
        }
        else
        {
            Debug.Log("No enemy hit.");
            Debug.DrawRay(position, forward * range, Color.red);
        }
    }
}
