using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
