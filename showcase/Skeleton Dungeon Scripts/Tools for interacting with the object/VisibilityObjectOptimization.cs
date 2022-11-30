using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityObjectOptimization : MonoBehaviour
{
    [SerializeField] private GameObject _activeGameObject;

    private void Start()
    {
        _activeGameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(30, 1, 1));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _activeGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _activeGameObject.SetActive(false);
        }
    }
}
