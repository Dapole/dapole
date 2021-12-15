using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBowStay : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    private Animator _animator;

    void Update()
    {
        _animator = GetComponentInChildren<Animator>();
        bool down = Input.GetButtonDown("Fire1");
        bool hold = Input.GetButton("Fire1");
        bool up = Input.GetButtonUp("Fire1");

        if (down)
        {
            _animator.SetTrigger("BowDown"); // Анимация натягивания тетевы
        }
        else if(hold)
        {
            _animator.SetBool("BowHold", true); // Анимация ожидания выстрела
        }
        else if(up)
        {
            _animator.SetBool("BowHold", false);
            _animator.SetTrigger("BowUp"); // Выстрел
            Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
