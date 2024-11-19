using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject levelPanel;
    public void LevelPanelActivate()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void LevelPanelDeactivate()
    {
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
