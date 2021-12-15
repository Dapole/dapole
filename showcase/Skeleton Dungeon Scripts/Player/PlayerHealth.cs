using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float maxHealth = 100;

    private Animator _animator;
    private float currentHealth;

    private void Start() {
        currentHealth = maxHealth;
        InitHealth();
    }

    private void Update()
    {
        InitHealth();
    }
    
    public void ReduceHealth(float damage)
    {
        currentHealth -= damage;
        InitHealth();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void AddHealth(int heal)
    {
        currentHealth += heal;
        InitHealth();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void InitHealth()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("Die");
        gameOverCanvas.SetActive(true);
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<WeaponScroll>().enabled = false;
    }
}
