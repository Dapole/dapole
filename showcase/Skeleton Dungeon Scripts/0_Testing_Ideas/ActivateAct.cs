using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAct : MonoBehaviour
{
    private Animator animator;
    private bool isActivated = false;

    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        if (isActivated)
        {
           animator.SetTrigger("activate");
           isActivated = false;
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
