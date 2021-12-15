using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;

    private Animator animator;
    private IDoor door;
    private float timer;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                door.CloseDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            door.OpenDoor();
            animator.SetBool("Active", true);
            timer = 3f;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            timer = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Active", false);
    }

}
