using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private WeaponBow weaponBow;
    [SerializeField] private PlayerMovement playerMovement;
    
    public GameObject AttackBtn;
    public GameObject ShootBtn;
    
    private int MaxWeapon = 3;
    private int ScrolInt;
    
    private void Update()
   {
       if (ScrolInt == 0)
       {
           AttackBtn.SetActive(false);
           ShootBtn.SetActive(false);
        }
        if (ScrolInt == 1)
        {
            AttackBtn.SetActive(true);
            ShootBtn.SetActive(false);
        }
        if (ScrolInt ==2)
        {
            AttackBtn.SetActive(false);
            ShootBtn.SetActive(true);
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

    public void Attack()
    {
        playerCombat.Attack();
    }

    public void Shoot()
    {
        weaponBow.Shoot();
    }

    public void Jump()
    {
        playerMovement.Jump();
    }

    public void Use()
    {
        playerMovement.Use();        
    }
}
