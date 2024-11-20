using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBox : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reference to door that will be unlocked")]
    private DoorController doorController;
    
    [SerializeField]
    [Tooltip("List of breaker box bars")]
    private GameObject[] bars;

    [SerializeField]
    [Tooltip("Material for disabled breaker box")]
    public Material disabledBreakerBox;

    private HealthManager hpManager;

    // Start is called before the first frame update
    void Start()
    {
        hpManager = gameObject.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpManager.GetIsHit())
        {
            doorController.UnlockDoor();
            for (int i = 0; i < bars.Length; i++)
            {
                bars[i].GetComponent<MeshRenderer>().material = disabledBreakerBox;
            }
            enabled = false;
        }
    }
}
