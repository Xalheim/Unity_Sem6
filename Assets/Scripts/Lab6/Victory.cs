using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(VictoryScreenTimer());
    }
    IEnumerator VictoryScreenTimer()
    {
        Debug.Log("Victory screen timer of 5 seconds active.");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(3);
    }
}
