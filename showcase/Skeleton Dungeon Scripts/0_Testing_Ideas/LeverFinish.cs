using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFinish : MonoBehaviour
{
    private Finish finish;
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    public void ActivateLever()
    {
        finish.Activate();
        animator.SetTrigger("activate");
    }
}
