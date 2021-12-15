using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;

    private Lever lever;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        EnemyHealthB enemy = hitInfo.GetComponent<EnemyHealthB>();
        Lever lever = FindObjectOfType<Lever>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);            
        }
        if (lever != null)
        {
            lever.ActivateLever();
        }
        Destroy(gameObject);
    }
}
