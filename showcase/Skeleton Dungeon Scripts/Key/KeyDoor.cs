using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    private Animator animator;
    private bool isOpen = false;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
        Drop drop = this.GetComponent<Drop>();
        if (drop != null)
        {
            drop.DropOn();
            //drop.DropOnPosition();
        }
    }

    public void PlayOpenFailAnim()
    {
        animator.SetTrigger("OpenFail");
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}
