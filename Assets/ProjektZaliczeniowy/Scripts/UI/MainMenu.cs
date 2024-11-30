using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//https://www.youtube.com/watch?v=JivuXdrIHK0
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to settings")]
    private SettingsManager settings;

    [SerializeField]
    [Tooltip("Reference to main panel")]
    private GameObject mainPanel;

    [SerializeField]
    [Tooltip("Reference to level panel")]
    private GameObject levelPanel;

    [SerializeField]
    [Tooltip("Reference to credits panel")]
    private GameObject creditsPanel;

    //[SerializeField]
    //[Tooltip("Reference to Sensitivity input")]
    //private GameObject sensitivityInputField;

    private GameObject enabledPanel;


    void Start()
    {
        enabledPanel = mainPanel;
        enabledPanel.SetActive(true);
        levelPanel.SetActive(false);
        creditsPanel.SetActive(false);
        //if (sensitivityInputField.TryGetComponent<InputField>(out var component))
        //{
        //    component.text = settings.GetSensitivity().ToString();
        //}
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

    //public void UpdateSensitivity()
    //{
    //    Debug.Log(sensitivityInputField.GetComponent<InputField>().text);
    //    if (sensitivityInputField.TryGetComponent<InputField>(out var component))
    //    {
    //        Debug.Log(component);
    //        Debug.Log((component.text).GetType());
    //        Debug.Log(float.Parse(component.text));
    //        if (float.TryParse(component.text, out float sensitivity))
    //        {
    //            Debug.Log("Got into tryparse");
    //            Mathf.Max(0.1f, sensitivity);
    //            settings.SetSensitivity(sensitivity);
    //        }
    //        else
    //        {
    //            Debug.Log("Didnt");
    //        }
    //    }
    //    else { Debug.Log("TF"); }
    //}
}
