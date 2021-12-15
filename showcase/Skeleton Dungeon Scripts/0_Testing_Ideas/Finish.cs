using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteCanvas;

    private bool isActivated = false;

    public void Activate()
    {
        isActivated = true;
    }

    public void FinishLever()
    {
       if (isActivated)
       {
           levelCompleteCanvas.SetActive(true);
           gameObject.SetActive(false);
       }
    }
}
