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

    [SerializeField]
    [Tooltip("Reference to Muzzle Flash")]
    protected GameObject muzzleFlash;

    protected bool secondaryFire;
    private bool isShooting;
    protected Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StopWeaponFiring()
    {
        animator.SetBool("triggerPulled", false);
    }
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

        if (secondaryFire && !PauseMenu.isGamePaused)
        {
            SecondaryFire();
        }
        else if (!PauseMenu.isGamePaused)
        {
            PrimaryFire();
        }
    }

    protected virtual void PrimaryFire()
    {
        animator.SetBool("triggerPulled", true);
        Debug.Log("P");
        StartCoroutine(WeaponDelay(primaryDelay));
    }

    protected virtual void SecondaryFire()
    {
        animator.SetBool("triggerPulled", true);
        Debug.Log("S");
        StartCoroutine(WeaponDelay(secondaryDelay));
    }

    IEnumerator WeaponDelay(float delay)
    {
        isShooting = true;
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(delay);
        muzzleFlash.SetActive(false);
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
        StopAllCoroutines();
        muzzleFlash.SetActive(false);
        gameObject.SetActive(false);
    }
}
