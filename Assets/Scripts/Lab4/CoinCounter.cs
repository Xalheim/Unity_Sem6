using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int counter = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            counter += 1;
            Debug.Log("Coin collected, total coins collected: " + counter);
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if (counter == 5)
        {
            Debug.Log("You got all the coins, game won!");
            SceneManager.LoadScene(5);
        }
    }
}
