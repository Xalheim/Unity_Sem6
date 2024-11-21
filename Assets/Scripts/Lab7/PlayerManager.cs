using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to playerData")]
    private PlayerData playerData;


    private void Start()
    {
        Debug.Log("Player Name: " + playerData.playerName);
        Debug.Log("Player Score: " + playerData.playerScore);
        Debug.Log("Player Health: " + playerData.playerHealth);
    }

    public void IncreaseScore(int amount)
    {
        playerData.playerScore += amount;
        Debug.Log("Nowy wynik gracza: " + playerData.playerScore);
    }
}