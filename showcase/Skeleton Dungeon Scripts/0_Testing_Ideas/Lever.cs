using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject actObject;

    private IDoor door;
    private ActivateAct activateAct;
    
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        if (actObject != null)
        {
            if (actObject.tag == "Door")
            {
                door = actObject.GetComponent<IDoor>();
            }
            if (actObject.tag == "ActActive")
            {
                activateAct = actObject.GetComponent<ActivateAct>();
            }
        }
        else
        {
            Destroy(this);
        }
    }

    public void ActivateLever()
    {
        if (actObject != null)
        {
            if (actObject.tag == "Door")
            {
                door.ToggleDoor();
            }
            if (actObject.tag == "ActActive")
            {
                activateAct.Activate();
            }
            if (animator != null)
            {
                animator.SetTrigger("activate");
            }
        }
        else
        {
            Debug.Log("Not work" + gameObject.name + "actObject = NULL");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (actObject != null)
            {

            }
            else
            {
            Debug.Log("Not work" + gameObject.name + "actObject = NULL");
            }
        }
        if (other.gameObject.tag == "Arrow")
        {
            ActivateLever();
            Arrow arrow = other.GetComponent<Arrow>();
            Destroy(arrow);
        }
    }
}
