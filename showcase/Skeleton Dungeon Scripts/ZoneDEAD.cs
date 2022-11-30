using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDEAD : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Die();
        }
    }
}
