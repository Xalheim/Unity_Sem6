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

    [SerializeField]
    [Tooltip("Reference to Game Over Menu Panel")]
    private GameObject deathPanel;

    public static bool isGamePaused = false;
    public static bool playerDied = false;
    public static bool restartGame = false;

    private void Update()
    {
        if (restartGame)
        {
            restartGame = false;
            playerDied = false;
            pausePanel.SetActive(false);
            isGamePaused = false;

            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            deathPanel.SetActive(false);
        }
        if (playerDied && !deathPanel.activeSelf)
        {
            DeathScreenEnable();
        }
    }
    public void TogglePausePanel(InputAction.CallbackContext context)
    {
        if (!playerDied && context.phase == InputActionPhase.Performed)
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
        isGamePaused = false;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void DeathScreenEnable()
    {
        playerDied = true;
        pausePanel.SetActive(false);
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void ChangeScene(int level)
    {
        if (isGamePaused)
        {
            isGamePaused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(level);
    }

}
