using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCredits : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;
    public void CreditsPanelActivate()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
