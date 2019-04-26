using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static UIScript Instance { get; private set; } 
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    [SerializeField]
    private Text pointsTxt;

    public void GetPoint()
    {
        ManagerScript.Instance.IncrementCounter();
    }

    public void Restart()
    {
        ManagerScript.Instance.RestartGame();
    }

    public void UnlockGameOver()
    {
        GPlayGames.UnlockAchievement(GPGSIds.achievement_game_over);
    }

    public void UnlockFullScore()
    {
        GPlayGames.UnlockAchievement(GPGSIds.achievement_full_score);
    }

    public void ShowAchievements()
    {
      GPlayGames.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        GPlayGames.ShowLeaderboardUI();
    }

    public void UpdatePointsText()
    {
        pointsTxt.text = ManagerScript.Counter.ToString();
    }
}
