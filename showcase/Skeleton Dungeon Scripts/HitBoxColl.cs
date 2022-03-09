using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxColl : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnCollisionStay2D(Collision2D other) {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ReduceHealth(damage);
        }
    }
}
