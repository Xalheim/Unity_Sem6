using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Recieved call to quit game.");
    }
}
