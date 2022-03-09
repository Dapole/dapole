using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedX = 1f;
    
    const float speedXMultiplier = 50f;
    
    private float Horizontal = 0f;
    private bool isGround = false;
    private bool isJump = false;

    private Rigidbody2D rb;

    void Start() 
    {
       rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        Horizontal = Input.GetAxis("Horizontal"); // -1 : 1
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            isJump = true;
        }
    }
    
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(Horizontal * speedX * speedXMultiplier * Time.fixedDeltaTime, rb.velocity.y);

        if (isJump) 
        {
            rb.AddForce(new Vector2(0f, 500f));
            isGround = false;
            isJump = false;
        }
    }
    void OnCollisionEnter2D (Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground")) 
        {
            isGround = true;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
           Debug.Log("Worked");
        }

    }
}