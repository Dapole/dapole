using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamLicenseChecker : MonoBehaviour
{
    
    void Start()
    {
        CheckLicense();
    }

    private void CheckLicense()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("Steam License OK");
        }
        else
        {
            // Возможно стоит выдать окно ой что-то не так
            Debug.Log("You Pirate!!!");
        }
    }

    
}
