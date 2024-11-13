using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneChange : MonoBehaviour
{
    [SerializeField]
    private int SceneID;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SceneChangeTrigger")
        {
            Debug.Log("Touched Scene Change Trigger, going to level ID: " + SceneID);
            SceneManager.LoadScene(SceneID);
        }
    }
}
