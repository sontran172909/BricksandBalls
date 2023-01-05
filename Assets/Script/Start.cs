using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DunnGSunn;
using UnityEngine.UI;


public class Start : MonoBehaviour
{
   
    

    public void startLevel()
    {
        //var star = PlayerPrefs.GetInt("level_" + level, 0);
        SceneManager.LoadScene("Level1");
        //TestStatic.Instance.CurrentLevelPlaying = level;
        //BallsManager.Instance.ResetBalls();
        audioManager.instance.SetSound(3, false);;
        int getLvAt = PlayerPrefs.GetInt("levelUnlocked");
        if (getLvAt == 0)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (getLvAt == 101)
        {
            SceneManager.LoadScene("Level100");
        }
        else
        {
            SceneManager.LoadScene("Level" + getLvAt);
        }

    }

    
    public void MoreLevel()
    {
        SceneManager.LoadScene("MenuLevel");
        audioManager.instance.SetSound(3, false);
    }
    //
    // public void Store()
    // {
    //     SceneManager.LoadScene("Gem Store");
    //     audioManager.instance.SetSound(3, false);
    // }    
    //
    // public void DailyBonus()
    // {
    //     SceneManager.LoadScene("Daily Bonus");
    //     audioManager.instance.SetSound(3, false);
    // }
    // public void Spin()
    // {
    //     SceneManager.LoadScene("spin");
    //     audioManager.instance.SetSound(3, false);
    // }
    // public void Task()
    // {
    //   
    //     SceneManager.LoadScene("Task");
    //     audioManager.instance.SetSound(3, false);
    // }
    //
    // public void SkinStore()
    // {
    //     SceneManager.LoadScene("Skin Shop");
    //     audioManager.instance.SetSound(3, false);
    // }
    // public void Wall()
    // {
    //     audioManager.instance.SetSound(3, false);
    //     SceneManager.LoadScene("Wall Store");
    // }
}