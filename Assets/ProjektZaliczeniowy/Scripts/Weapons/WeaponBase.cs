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
    [Tooltip("Reference to Primary Muzzle Flash")]
    protected GameObject muzzleFlashPrimary;

    [SerializeField]
    [Tooltip("Reference to Secondary Muzzle Flash")]
    protected GameObject muzzleFlashSecondary;

    [SerializeField]
    [Tooltip("Reference to weapon shooting sound")]
    protected AudioSource shootSFX;

    protected bool secondaryFire;
    private bool isShooting;

    protected Animator animator;


    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StopWeaponFiring()
    {
        animator.SetBool("triggerPulled", false);
    }

    public void StartUnholster()
    {
        animator.SetBool("readyToFire", false);
    }

    public void StopUnholster()
    {
        animator.SetBool("readyToFire", true);
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
        if (animator.GetBool("readyToFire"))
        {
            shootSFX.Play();
            animator.SetBool("triggerPulled", true);
            StartCoroutine(WeaponDelay(primaryDelay));
            StartCoroutine(MuzzleFlashPrimary());
        }
    }

    protected virtual void SecondaryFire()
    {
        if (animator.GetBool("readyToFire"))
        {
            shootSFX.Play();
            animator.SetBool("triggerPulled", true);
            StartCoroutine(WeaponDelay(secondaryDelay));
            StartCoroutine(MuzzleFlashSecondary());
        }
    }

    IEnumerator WeaponDelay(float delay)
    {
        isShooting = true;
        yield return new WaitForSeconds(delay);
        isShooting = false;
    }

    IEnumerator MuzzleFlashPrimary()
    {
        muzzleFlashPrimary.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        muzzleFlashPrimary.SetActive(false);
    }

    IEnumerator MuzzleFlashSecondary()
    {
        muzzleFlashSecondary.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlashSecondary.SetActive(false);
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
        StopWeaponFiring();
        muzzleFlashPrimary.SetActive(false);
        muzzleFlashSecondary.SetActive(false);
        animator.SetBool("readyToFire", false);
        gameObject.SetActive(false);
    }

    public bool IsShooting()
    {
        return isShooting;
    }
}
