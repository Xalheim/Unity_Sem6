using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//https://www.youtube.com/watch?v=_QajrabyTJc

public class PZ_PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to own Character Controller")]
    private CharacterController controller;

    [SerializeField]
    [Tooltip("Multiplies player speed output")]
    private float speed = 12f;

    private Rigidbody rb;
    private float gravityValue = -9.81f;
    private Boolean groundedPlayer = true;
    private Boolean jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Melee()
    {
        Debug.Log("Melee!");
    }

    public void Dash()
    {
        Debug.Log("Dasho");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!jumped)
            {
                Debug.Log("Jumped");
                jumped = true;
                rb.AddForce(new Vector3(0, 300, 0), ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (controller.isGrounded)
        {
            jumped = false;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * speed + transform.forward * z * speed;
        move.y += gravityValue;
        //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

        controller.Move(move * Time.deltaTime);

    }
}
