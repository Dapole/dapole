using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIhints : MonoBehaviour
{
    [SerializeField] private GameObject messageUI;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            messageUI.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other) 
    {
        messageUI.SetActive(false);        
    }
}
