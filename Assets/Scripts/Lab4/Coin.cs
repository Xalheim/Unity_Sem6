using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.Rotate(1, 0, 0);
    }

}
