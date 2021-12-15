using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthB : MonoBehaviour
{
    // public Animator animator;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject canvas;
    
    private float currentHealth;

    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        InitHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        InitHealth();
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void InitHealth()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyVision>().enabled = false;
        GetComponent<EnemyController>().enabled = false;
        canvas.gameObject.SetActive(false);
        this.enabled = false;
    }

    void Update()
    {
        
    }
}
