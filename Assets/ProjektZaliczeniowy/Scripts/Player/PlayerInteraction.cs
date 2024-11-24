using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Multiplies player speed output")]
    private float speed = 12f;

    [SerializeField]
    [Tooltip("Jump height force")]
    private float jumpForce = 5f;

    [SerializeField]
    [Tooltip("How far the dash launches the player")]
    private float dashStrength = 10f;

    [SerializeField]
    [Tooltip("How much damage is dealt by melee")]
    private int meleeDamage = 25;

    [SerializeField]
    [Tooltip("World mask for jumping reset")]
    private LayerMask worldMask;

    [SerializeField]
    [Tooltip("Enemy mask for melee damage")]
    private LayerMask enemyMask;

    [SerializeField]
    [Tooltip("List all available weapons")]
    private WeaponBase[] weapons;

    [SerializeField]
    [Tooltip("Reference for weapon unlock verification")]
    private PlayerProgressManager playerProgressManager;

    private Rigidbody rb;
    private Vector2 movement;

    private WeaponBase activeWeapon;
    private bool grounded;
    public bool dashed;
    private Vector3 move;

    public static PlayerInteraction instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        activeWeapon = weapons[0];
    }
    private void Update()
    {
        grounded = isGrounded();
        if (transform.position.y < -50)
        {
            transform.position = new Vector3(0, 1, 0);
            Debug.Log("Fell out of Bounds!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = new Vector3(movement.x, 0.0f, movement.y);
        move = transform.TransformDirection(move);
        rb.MovePosition(rb.position + new Vector3(move.x, 0, move.z) * speed * Time.fixedDeltaTime);
    }
    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, worldMask);
    }


    public void Melee(InputAction.CallbackContext context)
    {
        Debug.Log("Melee!");
        RaycastHit hit;
        Vector3 position = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;

        if (Physics.Raycast(position, forward, out hit, 2.5f, enemyMask) && hit.collider.TryGetComponent<HealthManager>(out var hpManager))
        {
            Debug.Log("Hit enemy for " + meleeDamage + " melee damage");
            Debug.DrawRay(position, forward * 2.5f, Color.white, 5f);

            if (hpManager != null)
            {
                hpManager.ApplyDamage(meleeDamage);
            }
        }
        else
        {
            Debug.Log("No enemy hit.");
            Debug.DrawRay(position, forward * 2.5f, Color.red, 5f);
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !dashed && !PauseMenu.isGamePaused)
        {
            StartCoroutine(DashActivation());
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && grounded && !PauseMenu.isGamePaused)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void SwitchToWeapon(int weaponIndex)
    {
        if (!PauseMenu.isGamePaused && VerifyWeaponPossession(weaponIndex))
        {
            if (activeWeapon != null)
            {
                activeWeapon.Deactivate();
            }
            activeWeapon = weapons[weaponIndex];
            activeWeapon.Activate();
        }
    }

    public void FireWeapon(InputAction.CallbackContext context)
    {
        if (activeWeapon != null && context.phase == InputActionPhase.Performed && !PauseMenu.isGamePaused)
        {
            activeWeapon.Shoot();
        }
    }

    public void AlternateFire(InputAction.CallbackContext context)
    {
        if (activeWeapon == null)
        {
            return;
        }
        if (context.phase == InputActionPhase.Started)
        {
            activeWeapon.ChangeFireType(true);
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            activeWeapon.ChangeFireType(false);
        }
    }
    private IEnumerator DashActivation()
    {
        rb.AddForce(new Vector3(move.x * dashStrength, 0, move.z * dashStrength));
        dashed = true;
        yield return new WaitForSeconds(.2f);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(.8f);
        dashed = false;
    }

    public void StopRigidbodyVelocity()
    {
        rb.velocity = Vector3.zero;
    }

    private bool VerifyWeaponPossession(int weaponIndex)
    {
        switch (weaponIndex)
        {
            case 0:
                return playerProgressManager.playerProgress.hasRevolver;
            case 1:
                return playerProgressManager.playerProgress.hasShotgun;
            case 2:
                return playerProgressManager.playerProgress.hasGrenadeLauncher;
            case 3:
                return playerProgressManager.playerProgress.hasRocketLauncher;
            default:
                return false;
        }
    }

}

