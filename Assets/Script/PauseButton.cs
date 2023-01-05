using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;
   
    public int CurrentKey
    {
        get => PlayerPrefs.GetInt("GameManager_currentkey");
        set => PlayerPrefs.SetInt("GameManager_currentkey", value);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        audioManager.instance.SetSound(3, false);


    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    
        audioManager.instance.SetSound(3, false);
    }
    public void Home()
    {
        SceneManager.LoadScene("Global");
        BallsManager.Instance.ResetBalls();
        Time.timeScale = 1f;
        CurrentKey = 0;
        
        audioManager.instance.SetSound(3, false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        BallsManager.Instance.ResetBalls();
        Time.timeScale = 1;
       
        audioManager.instance.SetSound(3, false);
    }
    
}