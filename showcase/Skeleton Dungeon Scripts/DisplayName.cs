using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class DisplayName : MonoBehaviour
{
    public Text displayName;
    public Text starCount;
    public Image avatarImage;

    public string[] statStrings;

    void Start()
    {
        if (!SteamManager.Initialized)
        {
            return;
        }

        displayName.text = SteamFriends.GetPersonaName();
    }
}
