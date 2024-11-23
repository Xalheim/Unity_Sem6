using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "Player Progress")]
public class PlayerProgress : ScriptableObject
{
    public bool hasRevolver;
    public bool hasShotgun;
    public bool hasGrenadeLauncher;
    public bool hasRocketLauncher;
}