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

    [SerializeField]
    [Tooltip("Reference to weapon number 1")]
    private GameObject weapon_1;

    [SerializeField]
    [Tooltip("Reference to weapon number 2")]
    private GameObject weapon_2;

    [SerializeField]
    [Tooltip("Reference to weapon number 3")]
    private GameObject weapon_3;

    [SerializeField]
    [Tooltip("Reference to weapon number 4")]
    private GameObject weapon_4;

    private Rigidbody rb;
    private float gravityValue = -9.81f;
    private Boolean groundedPlayer = true;
    private Boolean jumped = false;

    private List<GameObject> WeaponList;
    private GameObject ActiveWeapon;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (weapon_1 == null || weapon_2 == null || weapon_3 == null || weapon_4 == null)
        {
            throw new Exception("All 4 weapons have not been assigned to script PZ_PlayerInteraction");
        }
        WeaponList = new List<GameObject>();
        WeaponList.Add(weapon_1);
        WeaponList.Add(weapon_2);
        WeaponList.Add(weapon_3);
        WeaponList.Add(weapon_4);
        ActiveWeapon = weapon_1;
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
        //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

        controller.Move(move * Time.deltaTime);

    }

    public void SwitchToWeapon(int WeaponNumber)
    {
        if (weapon_1 == null || weapon_2 == null || weapon_3 == null || weapon_4 == null)
        {
            return;
        }

        switch (WeaponNumber)
        {
            case 1:
                if (ActiveWeapon != WeaponList[0])
                {
                    ActiveWeapon.SetActive(false);
                    ActiveWeapon = weapon_1;
                    weapon_1.SetActive(true);
                }
                break;
            case 2:
                if (ActiveWeapon != WeaponList[1])
                {
                    ActiveWeapon.SetActive(false);
                    ActiveWeapon = weapon_2;
                    weapon_2.SetActive(true);
                }
                break;
            case 3:
                if (ActiveWeapon != WeaponList[2])
                {
                    ActiveWeapon.SetActive(false);
                    ActiveWeapon = weapon_3;
                    weapon_3.SetActive(true);
                }
                break;
            case 4:
                if (ActiveWeapon != WeaponList[3])
                {
                    ActiveWeapon.SetActive(false);
                    ActiveWeapon = weapon_4;
                    weapon_4.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
// TODO Fix cooldown breaking when switching weapons during a Coroutine
}

