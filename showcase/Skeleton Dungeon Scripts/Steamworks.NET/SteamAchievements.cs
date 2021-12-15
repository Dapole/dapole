using System;
using UnityEngine;
using Steamworks;

public class SteamAchievements : MonoBehaviour
{
    bool _isStatsRecieved;
    bool _isAchievementCleared;
    bool _isAchievementStatusUpdated;
    bool _isStatsStored;

    // private string _achievementName = "ACH_OPEN_CHEST"

    private void Start() {
        
    }

    private void Update() {
        if (!SteamManager.Initialized)
        {
            return;
        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        //SteamUserStats.SetAchievement("ACH_OPEN_CHEST");
    }


}
