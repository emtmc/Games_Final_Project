using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour
{
    public Text friendsText;
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if(FB.IsInitialized)
                    FB.ActivateApp();
                else
                {
                    Debug.LogError("Couldn't initialize");
                }
            },
                isGameShown =>
                {
                    if (!isGameShown)
                        Time.timeScale = 0;
                    else
                    {
                        Time.timeScale = 1;
                    }
                });
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void ShowShare()
    {
        
    }
    #region Login / Logout

    public void FacebookLogin()
    {
        var permissions = new List<string>() {"public_profile", "email", "user_friends"};
        FB.LogInWithReadPermissions(permissions);
    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://www.facebook.com/ITTralee/"));
    }
    #endregion
    
    #region Inviting

    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title:"2D Ball Game");
    }

    public void FacebookInvite()
    {
        FB.Mobile.AppInvite(new System.Uri(""));
    }

    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
            var friendsList = (List<object>) dictionary["data"];
            friendsText.text = string.Empty;
            foreach (var dict in friendsList)
                friendsText.text += ((Dictionary<string, object>)dict)["name"];
        });
    }
    #endregion
}
