using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : WeaponBase
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
        projectile.Initialize(damage, projectileSpeed, range, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
    }

    protected override void SecondaryFire()
    {
        base.SecondaryFire();
        StartCoroutine(FireRocketBurst());
    }

    private IEnumerator FireRocketBurst()
    {
        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
        
        yield return new WaitForSeconds(0.1f);

        projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
        yield return new WaitForSeconds(0.1f);

        projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);

        yield return new WaitForSeconds(secondaryDelay);
    }
}
