using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : WeaponBase
{
    [SerializeField]
    [Tooltip("Speed of shot projectile")]
    protected int projectileSpeed;

    [SerializeField]
    [Tooltip("Knockback strength of exploding projectile")]
    protected int projectilePushStrength;

    [SerializeField]
    [Tooltip("LayerMask for projectile")]
    protected LayerMask projectileMask;

    protected override void PrimaryFire()
    {
        base.PrimaryFire();

        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(damage, projectileSpeed, range, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.Rocket);
    }

    protected override void SecondaryFire()
    {
        base.SecondaryFire();
        int slowSpeed = projectileSpeed / 3;
        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, slowSpeed, range * 2, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.PlasmaRocket);
    }
}
