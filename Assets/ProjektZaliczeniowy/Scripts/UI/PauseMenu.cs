using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reference to Escape Menu Panel")]
    private GameObject pausePanel;

    public static bool isGamePaused = false;

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
            if (isGamePaused)
            {
                isGamePaused = false;
                pausePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
            else
            {
                isGamePaused = true;
                pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
        }
    }

    public void DisablePausePanel()
    {
        if (isGamePaused)
        {
            isGamePaused = false;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void ChangeScene(int level)
    {
        SceneManager.LoadScene(level);
    }

}
