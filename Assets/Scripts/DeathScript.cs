using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class DeathScript : MonoBehaviour
{

    private int lives;
    public Text livesText=null;
    private Scene scene;
    
    
    void Start()
    {
        LoadData();
        livesText.text = "Lives: " + lives.ToString();
        scene = SceneManager.GetActiveScene();
    }

    //The player triggers this method when it falls 
    void OnTriggerEnter2D(Collider2D trigger)
    {

        Debug.Log("OnTriggerEnter()");

        //checking if the object has the death tag
        if (trigger.gameObject.tag == ("Death"))
        {
           Debug.Log("Destroy Object");
           Destroy(trigger.gameObject);
        }
      
        if (lives == 3)
        {
           lives = 2;
           livesText.text = "Lives: " + lives.ToString();
           AdController.controller.videoAd();
         //  AdMob.admob.HideAdMobBanner();
           SaveData();
        }
        else if (lives == 2)
        {
           lives = 1;
           livesText.text = "Lives: " + lives.ToString();
           AdController.controller.videoAd();
           //  AdMob.admob.HideAdMobBanner();
           SaveData();
        }
        else if (lives <= 1)
        {
           lives = 0;
           livesText.text = "Lives: " + lives.ToString();
           Debug.Log("Game Over");
           AdController.controller.rewardVideoAd();
           UIScript.Instance.UnlockGameOver();
//           AdMob.admob.HideAdMobBanner();
           lives = 3;
           SaveData();
           SceneManager.LoadScene(0);
        }
        else
        {
            SaveData();
        }
    }

    void SaveData()
     {
         PlayerPrefs.SetInt("lives",lives);  
         PlayerPrefs.Save();
         RestartScene();
     }
     
     void LoadData()
     {
         if (lives < 0)
         {
             Debug.Log("Game Over");
             AdController.controller.rewardVideoAd();
             SceneManager.LoadScene(0);
         }
         else
         {
             if(lives <= 2)
             {
                 lives = PlayerPrefs.GetInt("lives");
             }
             else
             {
                 lives = 3;
             }
         }
     }
     
     void RestartScene()
     {
         SceneManager.LoadScene(1);
     }
    }

