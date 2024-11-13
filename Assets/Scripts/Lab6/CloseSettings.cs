using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettings : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    public void SettingsPanelDeactivate()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
