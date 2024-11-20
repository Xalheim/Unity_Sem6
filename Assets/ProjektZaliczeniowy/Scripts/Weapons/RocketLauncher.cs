using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : WeaponBase
{
    [SerializeField]
    [Tooltip("Speed of shot projectile")]
    protected int projectileSpeed;

    [SerializeField]
    [Tooltip("LayerMask for projectile")]
    protected LayerMask projectileMask;

    protected override void PrimaryFire()
    {
        base.PrimaryFire();

        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(damage, projectileSpeed, range, projectileMask, Camera.main.transform.forward, ProjectileType.Rocket);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(projectile.transform.forward * 10);
    }

    protected override void SecondaryFire()
    {
        base.SecondaryFire();
        int slowSpeed = projectileSpeed / 3;
        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, slowSpeed, range * 2, projectileMask, Camera.main.transform.forward, ProjectileType.PlasmaRocket);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(projectile.transform.forward * 10);
    }
}
