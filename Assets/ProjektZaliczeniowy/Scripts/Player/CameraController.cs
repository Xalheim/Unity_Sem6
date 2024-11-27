using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Modify camera movement sensitivity")]
    private float mouseSensitivity = 20f;

    [SerializeField]
    [Tooltip("Reference to player character")]
    private Transform playerBody;

    [SerializeField]
    [Tooltip("SettingsManager for sensitivity")]
    private SettingsManager settingsManager;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Vector2 mouseInput;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = settingsManager.settings.sensitivity;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = mouseInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.position = playerBody.position + new Vector3 (0, 0.5f, 0);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
}
