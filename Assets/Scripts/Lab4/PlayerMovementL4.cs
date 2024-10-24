using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerControllerL4 : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    [SerializeField]
    [Range(1, 10)]
    [Tooltip("Multiplies the player speed by set amount")]
    private float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue movementValue)
    {
        rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddTorque(movement * speed);
    }
}