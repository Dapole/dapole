using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    
    private Animator _animator;

    public float attackRate = 2f;
    float nextAttackTime = 0f;



    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
                nextAttackTime = Time.time + 1F / attackRate;
            }
        }
    }

    public void Shoot ()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("attack");
        StartCoroutine(WaitAndGo(1.07F));            
    }

    public IEnumerator WaitAndGo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
