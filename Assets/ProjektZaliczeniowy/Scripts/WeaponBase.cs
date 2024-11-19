using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponBase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Range of weapon in units")]
    protected int range;

    [SerializeField]
    [Tooltip("Damage of weapon")]
    protected int damage;

    [SerializeField]
    [Tooltip("Multiplies damage during alternate fire by amount")]
    protected int secondaryDamage;

    [SerializeField]
    [Tooltip("Amount of delay between primary shots")]
    protected float primaryDelay;

    [SerializeField]
    [Tooltip("Amount of delay between secondary shots")]
    protected float secondaryDelay;

    [SerializeField]
    [Tooltip("LayerMask for raycast enemy detection")]
    protected LayerMask enemyMask;

    private bool secondaryFire;
    private bool isShooting;

    

    public void ChangeFireType(bool isSecondaryFire)
    {
        secondaryFire = isSecondaryFire;
    }

    public void Shoot()
    {
        if (isShooting)
        {
            return;
        }

        if (secondaryFire)
        {
            SecondaryFire();
        }
        else
        {
            PrimaryFire();
        }
    }

    protected virtual void PrimaryFire()
    {
        Debug.Log("P");
        StartCoroutine(WeaponDelay(primaryDelay));
    }

    protected virtual void SecondaryFire()
    {
        Debug.Log("S");
        StartCoroutine(WeaponDelay(secondaryDelay));
    }

    IEnumerator WeaponDelay(float delay)
    {
        isShooting = true;
        yield return new WaitForSeconds(delay);
        isShooting = false;
    }

    // TODO Fix cooldown breaking when switching weapons during a Coroutine
    public void WeaponResetCooldown()
    {
        isShooting = false;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        isShooting = false;
        secondaryFire = false;
        gameObject.SetActive(false);
    }
}
