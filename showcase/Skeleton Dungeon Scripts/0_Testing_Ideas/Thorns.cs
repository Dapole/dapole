using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == collisionTag)
        {
            PlayerHealth health = coll.gameObject.GetComponent<PlayerHealth>();
            health.ReduceHealth();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == collisionTag)
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.ReduceHealth();
        }
    }
}
