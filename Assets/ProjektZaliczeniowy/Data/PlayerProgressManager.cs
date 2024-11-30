using UnityEngine;

public class PlayerProgressManager : MonoBehaviour
{
    public PlayerProgress playerProgress;

    private void Start()
    {
        Debug.Log("Is Revolver unlocked: " + playerProgress.hasRevolver);
        Debug.Log("Is Shotgun unlocked: " + playerProgress.hasShotgun);
        Debug.Log("Is Grenade Launcher unlocked: " + playerProgress.hasGrenadeLauncher);
        Debug.Log("Is Rocket Launcher unlocked: " + playerProgress.hasRocketLauncher);
    }


    public void UnlockRevolver()
    {
        playerProgress.hasRevolver = true;
    }
    public void UnlockShotgun()
    {
        playerProgress.hasShotgun = true;
    }
    public void UnlockGrenadeLauncher()
    {
        playerProgress.hasGrenadeLauncher = true;
    }
    public void UnlockRocketLauncher()
    {
        playerProgress.hasRocketLauncher = true;
    }

    public void LockRevolver()
    {
        playerProgress.hasRevolver = false;
    }

    public void LockShotgun()
    {
        playerProgress.hasShotgun = false;
    }
    public void LockGrenadeLauncher()
    {
        playerProgress.hasGrenadeLauncher = false;
    }
    public void LockRocketLauncher()
    {
        playerProgress.hasRocketLauncher = false;
    }

}