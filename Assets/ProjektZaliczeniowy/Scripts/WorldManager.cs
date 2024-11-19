using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;

    public Projectile projectile;

    public void Awake()
    {
        instance = this;
    }
}
