using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Settings settings;

    private void Start()
    {
        Debug.Log("Current sensitivity: " + settings.sensitivity);
    }

    public void SetSensitivity(float sensitivity)
    {
        settings.sensitivity = sensitivity;
    }
    

}