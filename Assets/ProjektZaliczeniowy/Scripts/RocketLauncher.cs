using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : WeaponBase
{
    [SerializeField]
    [Tooltip("Speed of shot projectile")]
    private int projectileSpeed;

    [SerializeField]
    [Tooltip("LayerMask for projectile")]
    protected LayerMask projectileMask;

    protected override void PrimaryFire()
    {
        base.PrimaryFire();

        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, Quaternion.identity);
        projectile.Initialize(damage, projectileSpeed, range, projectileMask, Camera.main.transform.forward);
    }
}
