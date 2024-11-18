using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=_QajrabyTJc
//https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Multiplies player speed output")]
    private float speed = 12f;

    [SerializeField]
    [Tooltip("Jump height force")]
    private float jumpForce = 20f;

    [SerializeField]
    [Tooltip("List all available weapons")]
    private WeaponBase[] weapons;

    [SerializeField]
    [Tooltip("World layer for jumping reset")]
    private LayerMask worldLayer;

    private Rigidbody rb;
    private Vector2 movement;

    private WeaponBase activeWeapon;
    private bool jumped;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        activeWeapon = weapons[0];
    }

    public void Melee(InputAction.CallbackContext context)
    {
        Debug.Log("Melee!");
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dasho");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && !jumped)
        {
            jumped = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1, worldLayer))
        {
            jumped = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        move = transform.TransformDirection(move);
        rb.MovePosition(rb.position + new Vector3(move.x, 0, move.z) * speed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void SwitchToWeapon(int WeaponIndex)
    {
        if (activeWeapon != null)
        {
            activeWeapon.Deactivate();
        }
        activeWeapon = weapons[WeaponIndex];
        activeWeapon.Activate();
    }

    public void FireWeapon(InputAction.CallbackContext context)
    {
        if (activeWeapon != null && context.phase == InputActionPhase.Performed)
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

}

