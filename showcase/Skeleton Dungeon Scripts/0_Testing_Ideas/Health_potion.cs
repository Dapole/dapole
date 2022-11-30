using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.AddHealth();
            Destroy(gameObject);
        }
    }
}
