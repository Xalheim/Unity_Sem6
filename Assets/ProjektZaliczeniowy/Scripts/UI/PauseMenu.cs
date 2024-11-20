using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reference to Escape Menu Panel")]
    private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePausePanel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(!pausePanel.activeSelf);
                Time.timeScale = 1;
            }
            else
            {
                pausePanel.SetActive(pausePanel.activeSelf);
                Time.timeScale = 0;
            }
        }
    }

}
