using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScroll : MonoBehaviour
{
   [SerializeField] private GameObject Weapon1, Weapon2, Weapon3;
   private int MaxWeapon = 3;

   private int ScrolInt;

   private void Update()
   {
       if (ScrolInt == 0)
       {
           Weapon1.SetActive(true);
           Weapon2.SetActive(false);
           GetComponent<PlayerCombat>().enabled = false;
           Weapon3.SetActive(false);
           GetComponent<WeaponBow>().enabled = false;
        }
        if (ScrolInt == 1)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            GetComponent<PlayerCombat>().enabled = true;
            Weapon3.SetActive(false);
            GetComponent<WeaponBow>().enabled = false;
        }
        if (ScrolInt ==2)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            GetComponent<PlayerCombat>().enabled = false;
            Weapon3.SetActive(true);
            GetComponent<WeaponBow>().enabled = true;
        }
        if (ScrolInt >= MaxWeapon)
        {
            ScrolInt = 0;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScrolInt += 1;
        }
    }
}
