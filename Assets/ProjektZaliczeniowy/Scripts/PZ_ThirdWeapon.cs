using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PZ_ThirdWeapon : MonoBehaviour
{
    private Boolean AlternateTrigger;
    [SerializeField]
    [Tooltip("Reference to InputAction responsible for toggling second weapon shooting style")]
    private InputActionReference AlternateFireAction;

    [SerializeField]
    [Tooltip("Reference to player for raycast")]
    private GameObject CameraObjectReference;

    [SerializeField]
    [Tooltip("Range of weapon in units")]
    private int Range;

    [SerializeField]
    [Tooltip("Damage of weapon")]
    private int Damage;

    [SerializeField]
    [Tooltip("Multiplies damage during alternate fire by amount")]
    private int PowerMultiplier;

    private int AppliedDamage;
    private bool IsShooting;

    // Start is called before the first frame update
    void Start()
    {
        AlternateTrigger = false;
        IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AlternateFireAction.action.IsPressed())
        {
            AlternateTrigger = true;
        }
        else
        {
            AlternateTrigger = false;
        }
    }

    public void FireWeapon()
    {
        if (!IsShooting)
        {
            StartCoroutine(WeaponDelay());
            Debug.Log("FIRED WEAPON NUMBER   3");
            if (AlternateTrigger)
            {
                Debug.Log("big shoot");

                AppliedDamage = Damage * PowerMultiplier;
            }
            else
            {
                Debug.Log("basic shot");
                AppliedDamage = Damage;
            }

            RaycastHit hit;
            Vector3 forward = CameraObjectReference.transform.forward;
            Vector3 position = CameraObjectReference.transform.position;
            if (Physics.Raycast(position, forward, out hit, Range) && hit.transform.tag == "Enemy")
            {
                Debug.Log("Hit enemy!");
                Debug.DrawRay(position, forward * Range, Color.white);

                PZ_HealthManager HealthScript = hit.collider.GetComponent<PZ_HealthManager>();

                if (HealthScript != null)
                {
                    HealthScript.ApplyDamage(AppliedDamage);
                }
            }
            else
            {
                Debug.Log("No enemy hit.");
                Debug.DrawRay(position, forward * Range, Color.red);
            }

        }
    }

    IEnumerator WeaponDelay()
    {
        IsShooting = true;
        yield return new WaitForSeconds(0.3f);
        IsShooting = false;
    }

    // TODO Fix cooldown breaking when switching weapons during a Coroutine
    public void WeaponResetCooldown()
    {
        IsShooting = false;
    }
}
