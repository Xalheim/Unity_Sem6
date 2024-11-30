using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyBase
{
    private Vector3 position;
    private Vector3 enemyToPlayerVector;
    private Quaternion gunRotation;
    private Quaternion rotation;

    [SerializeField]
    [Tooltip("Speed of shot projectile")]
    protected int projectileSpeed;

    [SerializeField]
    [Tooltip("Knockback strength of exploding projectile")]
    protected int projectilePushStrength;

    [SerializeField]
    [Tooltip("Radius of explosion in units")]
    protected int range;

    [SerializeField]
    [Tooltip("LayerMask for projectile")]
    protected LayerMask projectileMask;

    [SerializeField]
    [Tooltip("Gun Reference")]
    protected GameObject gun;

    [SerializeField]
    [Tooltip("Shot SFX Reference")]
    protected AudioSource shootSFX;

    private PlayerInteraction playerInt;
    private RaycastHit hit;
    
    
    protected override void FixedUpdate()
    {
        playerPosition = PlayerInteraction.instance.transform.position;
        gunPosition = gun.transform.position;
        enemyToPlayerVector = (playerPosition - gunPosition).normalized;

        gunRotation = Quaternion.LookRotation(new Vector3(enemyToPlayerVector.x, enemyToPlayerVector.y, enemyToPlayerVector.z));
        gun.transform.rotation = gunRotation;

        rotation = Quaternion.LookRotation(new Vector3(enemyToPlayerVector.x, 0, enemyToPlayerVector.z));
        transform.rotation = rotation;

        if (!isAttacking && Physics.Raycast(gunPosition, enemyToPlayerVector, out hit, 100f) && hit.collider.TryGetComponent<PlayerInteraction>(out playerInt))
        {
            AttackPlayer();
        }
        if (Vector3.Distance(playerPosition, gunPosition) < attackDistance)
        {
            Move();
        }
    }

    protected override void Move()
    {
        base.Move();
        rb.MovePosition(rb.position - new Vector3(enemyToPlayerVector.x, 0, enemyToPlayerVector.z) * speed * Time.fixedDeltaTime);
    }

    protected override void AttackPlayer()
    {
        base.AttackPlayer();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);

        //Debug.Log("Fired projectile");
        //Debug.DrawRay(gunPosition, enemyToPlayerVector * 100f, Color.white, 1f);

        var projectile = Instantiate(WorldManager.instance.projectile, gun.transform.position, gun.transform.rotation);
        projectile.Initialize(damage, projectileSpeed, range, projectilePushStrength, projectileMask, gun.transform.forward, ProjectileType.EnemyBullet);

        //shootSFX.Play();

        isAttacking = false;
    }
}
