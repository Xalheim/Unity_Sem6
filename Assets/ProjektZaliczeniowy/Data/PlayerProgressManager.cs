using UnityEngine;

public class PlayerProgressManager : MonoBehaviour
{
    public PlayerProgress playerProgress; // Przypisz `PlayerDataInstance` przez Inspektor w Unity

    private void Start()
    {
        Debug.Log("Shotgun unlocked: " + playerProgress.hasShotgun);
        Debug.Log("Grenade Launcher unlocked: " + playerProgress.hasGrenadeLauncher);
        Debug.Log("Rocket Launcher unlocked: " + playerProgress.hasRocketLauncher);
    }

    public void UnlockShotgun()
    {
        playerProgress.hasShotgun = true;
    }
    public void UnlockGrenadeLauncher()
    {
        playerProgress.hasShotgun = true;
    }
    public void UnlockRocketLauncher()
    {
        playerProgress.hasShotgun = true;
    }

    public void LockShotgun()
    {
        playerProgress.hasShotgun = false;
    }
    public void LockGrenadeLauncher()
    {
        playerProgress.hasShotgun = false;
    }
    public void LockRocketLauncher()
    {
        playerProgress.hasShotgun = false;
    }

}