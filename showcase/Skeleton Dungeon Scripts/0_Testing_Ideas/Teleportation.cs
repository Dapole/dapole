using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               Teleport();
            } 
        }
    }

    public void Teleport()
    {
        // yield return new WaitForSeconds (0.5f);
        Player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
    }
}
