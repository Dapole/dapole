using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject[] _uiManagerLives;

    public static int lives = 3;
    private Animator _animator;

    private Rigidbody2D rb;

    private void Start()
    {
        UdpateUIDispley();
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void ReduceHealth()
    {
        lives--;
        UdpateUIDispley();
    }

    public void AddHealth()
    {
        lives++;
        UdpateUIDispley();
    }

    private void UdpateUIDispley()
    {
        if (lives == 3)
        {
            _uiManagerLives[2].SetActive(true);
            _uiManagerLives[1].SetActive(true);
            _uiManagerLives[0].SetActive(true);
        }
        if (lives == 2)
        {
            _uiManagerLives[2].SetActive(false);
        }
        if (lives == 1)
        {
            _uiManagerLives[1].SetActive(false);
        }
        if (lives < 1)
        {
            _uiManagerLives[0].SetActive(false);
            Die();
        }
    }

    public void Die()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetTrigger("Die");
        gameOverCanvas.SetActive(true);
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<WeaponScroll>().enabled = false;
    }
}
