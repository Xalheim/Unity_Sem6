using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=JivuXdrIHK0
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to main panel")]
    private GameObject mainPanel;
    
    [SerializeField]
    [Tooltip("Reference to level panel")]
    private GameObject levelPanel;
    
    [SerializeField]
    [Tooltip("Reference to credits panel")]
    private GameObject creditsPanel;

    private GameObject enabledPanel;


    void Start()
    {
        enabledPanel = mainPanel;
        enabledPanel.SetActive(true);
        levelPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void EnableMainPanel()
    {
        enabledPanel.SetActive(false);
        enabledPanel = mainPanel.gameObject;
        enabledPanel.SetActive(true);
    }

    public void EnableLevelSelect()
    {
        enabledPanel.SetActive(false);
        enabledPanel = levelPanel.gameObject;
        enabledPanel.SetActive(true);
    }

    public void EnableCreditsPanel()
    {
        enabledPanel.SetActive(false);
        enabledPanel = creditsPanel.gameObject;
        enabledPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Recieved call to quit game.");
    }
}
