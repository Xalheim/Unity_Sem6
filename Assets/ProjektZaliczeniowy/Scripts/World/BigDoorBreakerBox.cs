using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorBreakerBox : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to Breaker Box Manager")]
    private BigDoorBreakerBoxManager boxManager;

    [SerializeField]
    [Tooltip("Reference to light")]
    private GameObject doorLight;

    [SerializeField]
    [Tooltip("List of breaker box bars")]
    private GameObject[] bars;

    [SerializeField]
    [Tooltip("Material for disabled breaker box")]
    public Material disabledBreakerBox;

    [SerializeField]
    [Tooltip("Material for light toggle")]
    public Material lightToggle;

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
            boxManager.LockDestroyed();
            for (int i = 0; i < bars.Length; i++)
            {
                bars[i].GetComponent<MeshRenderer>().material = disabledBreakerBox;
            }
            doorLight.GetComponent<MeshRenderer>().material = lightToggle;
            GetComponent<ActivateArena>().CallArenaActivation();
            enabled = false;
        }
    }
}
