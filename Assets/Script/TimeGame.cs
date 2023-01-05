using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class TimeGame : MonoBehaviour
{
    [Header("TimeGame UI references :")] [SerializeField]
    private Text TimePlay;
    public int Duration { get; private set; }
    public int remainingDuration;
    public GameObject gameOverScreen;
    public GameObject gameVictory;

    
    public bool IsGameStarted { get; set; }
    //private bool _stoptime;
    private void Awake()
    {
        ResetTime();
        
    }
    

    public void ResetTime()
    {
        TimePlay.text = "00:00";
        Duration = remainingDuration = 0 ;
        
    }

    public TimeGame SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTime());
      
    }

    public IEnumerator UpdateTime()
    {
     
        while (remainingDuration > 0)
        {
            remainingDuration--;
            yield return new WaitForSeconds(1f);
            UpdateUI(remainingDuration);

        }
        if (remainingDuration == 0)
        {
            gameOverScreen.SetActive(true);
       
            audioManager.instance.SetSound(4,false);
            BallsManager.Instance.ResetBalls();
            
            //BallsManager.Instance.InitBall();
            IsGameStarted = false;
            
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        TimePlay.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
    }
    
    public void End()
    {
        ResetTime();
        gameObject.SetActive(false);
    }
    
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
