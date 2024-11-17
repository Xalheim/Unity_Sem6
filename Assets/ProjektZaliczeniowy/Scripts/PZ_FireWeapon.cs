using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_FireWeapon : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Reference to first Weapon")]
    private GameObject weapon_1;

    [SerializeField]
    [Tooltip("Reference to second Weapon")]
    private GameObject weapon_2;
    
    [SerializeField]
    [Tooltip("Reference to third Weapon")]
    private GameObject weapon_3;

    [SerializeField]
    [Tooltip("Reference to fourth Weapon")]
    private GameObject weapon_4;

    public void ShootActiveWeapon()
    {
        if (weapon_1 == null || weapon_2 == null || weapon_3 == null || weapon_4 == null)
        { 
            return; 
        }
        if (weapon_1.activeSelf == true)
        {
            PZ_FirstWeapon FirstWeaponFireScript = weapon_1.GetComponent<PZ_FirstWeapon>();
            if (FirstWeaponFireScript != null)
            {
                FirstWeaponFireScript.FireWeapon();
            }
        }
        else if (weapon_2.activeSelf == true)
        {
            PZ_SecondWeapon SecondWeaponFireScript = weapon_2.GetComponent<PZ_SecondWeapon>();
            if (SecondWeaponFireScript != null)
            {
                SecondWeaponFireScript.FireWeapon();
            }
        }
        else if (weapon_3.activeSelf == true)
        {
            PZ_ThirdWeapon ThirdWeaponFireScript = weapon_3.GetComponent<PZ_ThirdWeapon>();
            if (ThirdWeaponFireScript != null)
            {
                ThirdWeaponFireScript.FireWeapon();
            }
        }
        else if (weapon_4.activeSelf == true)
        {
            PZ_FourthWeapon FourthWeaponFireScript = weapon_4.GetComponent<PZ_FourthWeapon>();
            if (FourthWeaponFireScript != null)
            {
                FourthWeaponFireScript.FireWeapon();
            }
        }
    }
}
