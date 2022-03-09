using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerWall : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Rigidbody2D rb;
    private bool forward;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        Vector2 velo = Vector2.right;
 
        if (!forward)
        {
            velo = Vector2.left;
        }
        
        rb.velocity = velo * Speed;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            forward = !forward;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }
}
