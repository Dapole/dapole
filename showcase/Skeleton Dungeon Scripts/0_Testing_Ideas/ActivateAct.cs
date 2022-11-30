using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAct : MonoBehaviour
{
    [SerializeField] private GameObject _activetGO;
    [SerializeField] private GameObject _hideGO;
    private bool isActivated = false;

    public void Activate()
    {
        isActivated = true;
        if (_activetGO != null)
        {
            _activetGO.SetActive(true);
        }
        if (_hideGO != null)
        {
            _hideGO.SetActive(false);
        }
        
        
    }
}
