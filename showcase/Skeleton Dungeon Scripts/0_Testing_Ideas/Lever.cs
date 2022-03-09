using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public ActivateAct actObject;
    
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        if (actObject != null)
        {
            actObject.GetComponent<ActivateAct>();
        }
    }

    public void ActivateLever()
    {
        if (actObject != null)
        {
            actObject.Activate();
            animator.SetTrigger("activate");
        }
        else
        {
            Debug.Log("Not work" + gameObject.name + "actObject = NULL");
        }
        
    }
}
