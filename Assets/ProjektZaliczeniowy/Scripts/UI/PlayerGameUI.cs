using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerGameUI : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to player")]
    private GameObject player;

    [SerializeField]
    [Tooltip("Reference to Health text")]
    private TextMeshProUGUI healthTMP;

    [SerializeField]
    [Tooltip("Reference to Dash text")]
    private TextMeshProUGUI dashTMP;

    private HealthManager hpManager;
    private PlayerInteraction playerInteraction;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        hpManager = player.GetComponent<HealthManager>();
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        health = hpManager.GetHealth();
        healthTMP.text = "Health: " + health;
        if (playerInteraction.dashed)
        {
            dashTMP.text = "Dash Cooldown";
        }   
        else
        {
            dashTMP.text = "Dash Ready";
        }
        
    }
}
