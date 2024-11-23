using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : WeaponBase
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
        projectile.Initialize(damage, projectileSpeed, range, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
    }

    protected override void SecondaryFire()
    {
        base.SecondaryFire();
        StartCoroutine(FireGrenadeBurst());
    }

    private IEnumerator FireGrenadeBurst()
    {
        var projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
        
        yield return new WaitForSeconds(0.1f);

        projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);
        yield return new WaitForSeconds(0.1f);

        projectile = Instantiate(WorldManager.instance.projectile, transform.position, transform.rotation);
        projectile.Initialize(secondaryDamage, projectileSpeed, range, projectilePushStrength, projectileMask, Camera.main.transform.forward, ProjectileType.Grenade);

        yield return new WaitForSeconds(secondaryDelay);
    }
}
