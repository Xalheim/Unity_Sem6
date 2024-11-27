using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    private Vector3 position;
    private Vector3 enemyToPlayerVector;

    // Start is called before the first frame update
    protected override void FixedUpdate()
    {
        playerPosition = PlayerInteraction.instance.transform.position;
        gunPosition = transform.position;
        enemyToPlayerVector = (playerPosition - gunPosition).normalized;
        if (!isAttacking && Vector3.Distance(playerPosition, gunPosition) < attackDistance)
        {
            AttackPlayer();
        }
        Move();
    }

    protected override void Move()
    {
        base.Move();
        rb.MovePosition(rb.position + enemyToPlayerVector * speed * Time.fixedDeltaTime);
    }

    protected override void AttackPlayer()
    {
        base.AttackPlayer();
        StartCoroutine(Melee());
    }

    private IEnumerator Melee()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);

        RaycastHit hit;

        if (Physics.Raycast(gunPosition, enemyToPlayerVector, out hit, 4.5f) && hit.collider.TryGetComponent<HealthManager>(out var hpManager) && hpManager.IsPlayer())
        {
            Debug.Log("Hit player for " + damage + "damage");
            Debug.DrawRay(gunPosition, enemyToPlayerVector * 4.5f, Color.white, 1f);

            hpManager.ApplyDamage(damage);

        }
        else
        {
            Debug.Log("Enemy attack missed.");
            Debug.DrawRay(gunPosition, enemyToPlayerVector * 4.5f, Color.red, 1f);
        }
        isAttacking = false;
    }
}
