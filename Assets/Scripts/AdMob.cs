/*using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{
    
    private string appID = "ca-app-pub-2074963649486507~4157892506";
    
    private BannerView bannerView;
    private RewardBasedVideoAd rewardVideoAd;
    private InterstitialAd interstitialAd;
    

    //singleton
    public static AdMob admob;
    
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(appID);
        AdMobInterstitialAd();
        RequestAdMobBanner();
        AdMobVideoAd();
    }
    
    public void RequestAdMobBanner()
    {
        string bannerID = "ca-app-pub-3940256099942544/6300978111";
     
        bannerView = new BannerView(bannerID, AdSize.SmartBanner, AdPosition.Bottom);

        //For real App
        //AdRequest request = new AdRequest.Builder().Build();
        
        //For Testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("3940256099942544/6300978111").Build();
        
        bannerView.LoadAd(request);
    }
    
    public void AdMobInterstitialAd()
    {
        string interstitialAdID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitialAdID);
        
        //For real App
        //AdRequest request = new AdRequest.Builder().Build();
        
        //For Testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("3940256099942544/6300978111").Build();
        
        interstitialAd.LoadAd(request);
        
    }
    
    public void AdMobVideoAd()
    {
        string rewardVideoID = "ca-app-pub-3940256099942544/5224354917";
        rewardVideoAd = RewardBasedVideoAd.Instance;
        
        //For real App
        //AdRequest request = new AdRequest.Builder().Build();
        
        //For Testing
        AdRequest request = new AdRequest.Builder().AddTestDevice("3940256099942544/6300978111").Build();
        
        rewardVideoAd.LoadAd(request,rewardVideoID);
        
    }

    public void DisplayAdMobBanner()
    {
        bannerView.Show();
    }

    public void HideAdMobBanner()
    {
        bannerView.Hide();
    }

    public void DisplayInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    public void DisplayVideoAd()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }
    
    //Handle Events
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        DisplayAdMobBanner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerView.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerView.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerView.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerView.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerView.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerView.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerView.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerView.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

    void onEnable()
    {
        HandleBannerADEvents(true);
    }

    void onDisable()
    {
        HandleBannerADEvents(false);
    }
}*/
