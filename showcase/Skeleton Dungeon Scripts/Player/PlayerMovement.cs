using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private AudioSource _jumpSound, _hurtSound;
    [SerializeField] private AudioClip _jumpCpil, _hurtClip;
    [SerializeField] public float runSpeed = 40f; // Скрипт Blue_potion обращается к переменной, нужно исправить этот косяк
    
    public CharacterController2D controller;

    private float horizontaMove = 0f;

    private bool isFinish = false;
    private bool isLever = false;
    private bool isDoor = false;
    private bool jump = false;

    private Animator animator;
    private Rigidbody2D rb;
    private Finish finish;
    private Lever lever;

    
    void Start()
    {
      finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
      lever = FindObjectOfType<Lever>();
      _jumpSound = GetComponent<AudioSource>();
      rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator = GetComponentInChildren<Animator>();
        horizontaMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("VelocityY", rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontaMove));
        animator.SetBool("IsJumping", jump);
        if (Input.GetButtonDown("Jump"))
        {
          Jump();
        }  
        if (Input.GetKeyDown(KeyCode.E))
        {
          Use();          
        }
    }

    public void ResetSpeed()
    {
      runSpeed = 40f;
    }

    public void Jump()
    {
      jump = true;
      _jumpSound.Play();
    }

    public void Use()
    {
      if(isFinish)
      {
        finish.FinishLever();
      }
      if(isDoor)
      {
        // teleportation.Teleport();
      }
      if (isLever)
      {
        lever.ActivateLever();
      }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    
    void FixedUpdate ()
    {
        controller.Move(horizontaMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnTriggerEnter2D (Collider2D other) //Проверяем в Collider объекта и ищем тэг, в тех случаях когда используем "Is Trigger" в свойствах Collider
    {
        Lever LeverTemp = other.GetComponent<Lever>();
        if (other.CompareTag("Finish")) 
        {
           Debug.Log("Worked");
           isFinish = true; 
        }
        if (other.CompareTag("Door")) 
        {
           Debug.Log("Door is Worked");
           isDoor = true;
        }
        if (LeverTemp != null)
        {
            isLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Lever LeverTemp = other.GetComponent<Lever>();
        if (other.CompareTag("Finish"))
        {
           Debug.Log("Not Worked");
           isFinish = false;
        }
        if (other.CompareTag("Door")) 
        {
           Debug.Log("Door is Not Worked");
           isDoor = false;
        }
        if (LeverTemp != null)
        {
            isLever = false;
        } 
    }
}