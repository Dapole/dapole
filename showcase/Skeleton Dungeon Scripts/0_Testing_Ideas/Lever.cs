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
        // actObject.GetComponent<ActivateAct>();
    }

    public void ActivateLever()
    {
        actObject.Activate();
        animator.SetTrigger("activate");
    }
}
