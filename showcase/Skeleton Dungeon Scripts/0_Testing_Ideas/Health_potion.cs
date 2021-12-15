using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_potion : MonoBehaviour
{
    public int collisionHeal = 5;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.AddHealth(collisionHeal);
            Destroy(gameObject);
        }
    }
}
