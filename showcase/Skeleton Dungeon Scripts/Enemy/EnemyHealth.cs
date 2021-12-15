using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ReduceHealth(float damage)
    {
        health -= damage;
        //_animation.SetTrigger("Take damage"); - получение урона
        if (health <=0f)
        {
        //    _animator.SetTrigger("Die");
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
