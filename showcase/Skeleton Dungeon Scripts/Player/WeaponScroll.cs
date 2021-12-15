using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScroll : MonoBehaviour
{
   public GameObject Weapon1;
   public GameObject Weapon2;
   public GameObject Weapon3;
   public int MaxWeapon = 3;

   private int ScrolInt;

   private void Update()
   {
       if (ScrolInt == 0)
       {
           Weapon1.SetActive(true);
           Weapon2.SetActive(false);
           Weapon3.SetActive(false);
        }
        if (ScrolInt == 1)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
        }
        if (ScrolInt ==2)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
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
