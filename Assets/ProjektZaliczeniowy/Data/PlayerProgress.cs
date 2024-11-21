using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "Player Progress")]
public class PlayerProgress : ScriptableObject
{
    public bool hasShotgun;
    public bool hasGrenadeLauncher;
    public bool hasRocketLauncher;
}