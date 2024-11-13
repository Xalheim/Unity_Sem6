using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCredits : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;
    public void CreditsPanelDeactivate()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
