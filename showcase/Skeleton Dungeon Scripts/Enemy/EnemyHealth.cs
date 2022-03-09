using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 4f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        _animator.SetTrigger("Hurt");
        if (health <=0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        _animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyVision>().enabled = false;
        GetComponent<EnemyController>().enabled = false;
        this.enabled = false;
    }
}
