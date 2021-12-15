using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_potion : MonoBehaviour
{
    public int collisionSpeed = 400;
    public GameObject uiBlue;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement Speed = other.gameObject.GetComponent<PlayerMovement>();
            Speed.runSpeed = collisionSpeed;
            uiBlue.SetActive(true);
            Destroy(gameObject);
        }
    }
}
