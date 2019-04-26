﻿using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    
    public static ManagerScript Instance { get; private set; }
    public static int Counter { get; private set; }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }


    public void IncrementCounter()
    {
        Counter++;
        UIScript.Instance.UpdatePointsText();
    }

    public void RestartGame()
    {
        GPlayGames.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboard, Counter);
        Counter = 0;
        UIScript.Instance.UpdatePointsText();
    }
}
