using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=_QajrabyTJc

public class PZ_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to own Character Controller")]
    private CharacterController controller;

    [SerializeField]
    [Tooltip("Multiplies player speed output")]
    private float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
