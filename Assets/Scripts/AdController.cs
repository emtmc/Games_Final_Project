using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Monetization;


public class AdController : MonoBehaviour
{
    private string gameId ="3120315";
    
    private string video_ad = "video";
    private string reward_video_ad = "rewardedVideo";
   // private string banner_ad = "Banner";
    

   
    
    //Singleton pattern is used to obtain the different methods in this class
    public static AdController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(gameId,false);
        
    }

    //calls the singleton function as soon as the controller is used
    private void Awake()
    {
        Singleton();
    }

    //Checks if the controller has an ad
    void Singleton()
    {
        if (controller != null)
        {
            Destroy(gameObject);
        }
        else
        {
            controller = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    //unity banner - doesnt work
   /* public void bannerAd()
    {
        //is the banner ready
        if (Monetization.IsReady(banner_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }*/

    public void videoAd()
    {
        //is the video ready
        if (Monetization.IsReady(video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }


    public void rewardVideoAd()
    {
        //is the reward video ready
        if (Monetization.IsReady(reward_video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(reward_video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    //handles the results of the ads
    public void handleShowResult(ShowResult result)
    {
        //PlayerPrefs is used to get the lives from the DeathScript
        int lives = PlayerPrefs.GetInt("lives");
        
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad finished");
                lives=1;
                //PlayerPrefs used to save the new value for lives, which can be used in the DeathScript
                PlayerPrefs.SetInt("lives",lives);
                PlayerPrefs.Save();
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad Skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad Failed to show");
                break;
        }
    }
}
