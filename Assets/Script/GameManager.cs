using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Spine.Unity;

using DunnGSunn;


public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            //LoadInAwake();
        }

        
        // Application.targetFrameRate = frameRate;
    }

    #endregion

    public Transform objParent;
    // public int frameRate = 80;
    

    public GameObject gameOverScreen;
    public GameObject gameVictory;
    public GameObject Chestroom;
    public int AvailibleLives = 3;
   
   
    private int Lives { get; set; }
    
    public bool IsGameStarted { get; set; }
    public int numOfHearts;

    public Image[] hearts;
    
    public Sprite fullHeart;
    public Sprite emptyHeart;
   // public int level;
    private int timeall;
    private int key { get; set; }
    public Image[] Keys;
    // public int TimeCount;
    // [SerializeField] private Text timeText;
    
   
    [SerializeField] private TimeGame TimeGame1;

    public int CurrentKey
    {
        get => PlayerPrefs.GetInt("GameManager_currentkey");
        set => PlayerPrefs.SetInt("GameManager_currentkey", value);
    }

   
    public Sprite emptyKey;
    
    public int a = (int)Mathf.Pow(2, 5);
    private void Start()
    {
     
        
        this.Lives = this.AvailibleLives;
        Ball.OnBallDeath += OnBallDeath;
        Brick.DescareBrick += DescareBrick;
        InitKey();
        
        CheckPlayerPref();
        TimeGame1.SetDuration(120).Begin();
        TimeGame1.SetDuration(120).remainingDuration += PlayerPrefs.GetInt("TimeCount");
       
    }

    private void CheckPlayerPref()
    {
        if (!PlayerPrefs.HasKey("GameManager_currentkey")) CurrentKey = 0;
    }

//      void Update()
//      {
//          
//          if (this.Lives > numOfHearts)
//          {
//              this.Lives = numOfHearts;
//          }
//          for (int i = 0; i < hearts.Length; i++)
//          {
//              if (i < this.Lives)
//             {
//                  hearts[i].sprite = fullHeart;
//              }
//              else
//              {
//                  hearts[i].sprite = emptyHeart;
//              }   
//             /*if (i < numOfHearts)
//             {
//                  hearts[i].enabled = true;
//
//              }
//             else
//             {
//                 hearts[i].enabled = false;
//             }*/
//          }
//
//       
//
//      }

    private void numberlive()
    {
        // if (this.Lives > numOfHearts)
        // {
        //     this.Lives = numOfHearts;
        // }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < this.Lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }   
            
        }
    }
    

    public void SKey()
    {
        CurrentKey++;
        InitKey();
    }

    private void InitKey()
    {
        switch (CurrentKey)
        {
            case 1:
                Keys[0].sprite = emptyKey;
                break;
            case 2:
                Keys[0].sprite = emptyKey;
                Keys[1].sprite = emptyKey;
                break;
            case 3:
                Keys[0].sprite = emptyKey;
                Keys[1].sprite = emptyKey;
                Keys[2].sprite = emptyKey;
           
               //if (CurrentKey == 3 && BricksManager.Instance.RemainingBricks.Count <= 0 )
               //{
               // gameVictory.SetActive(true);
               // audioManager.instance.SetSound(7, false);
              //  Debug.Log("var2");
              // }
              
                
                
                //Time.timeScale = 0f;
               // CurrentKey = 0;
                break;
        }
    }
   
    

    public void RestartGame()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
       // TestStatic.Instance.CurrentLevelPlaying = level;
        BallsManager.Instance.ResetBalls();
        IsGameStarted = true;
    }

    private void OnBallDeath(Ball obj)
    {
 
        if (BallsManager.Instance.Balls.Count <= 0 )
        {
            
            this.Lives--;
            numberlive();

            if (this.Lives < 1)
            {
                
                gameOverScreen.SetActive(true);
                TimeGame1.End();
                audioManager.instance.SetSound(4, false);

            }
            else
            {
              
                BallsManager.Instance.ResetBalls();
                BallsManager.Instance.InitBall();

                IsGameStarted = false;
                

            }
        }
    }


    [SerializeField] private Text coinWinText;
    private int coinwin;
   
    public void DescareBrick(Brick obj)
    {
        if (BricksManager.Instance.RemainingBricks.Count <= 0  )
        {
            BallsManager.Instance.ResetBalls();
        
           if (CurrentKey == 3)
           {
             Chestroom.SetActive(true);
             audioManager.instance.SetSound(8,false);
             CurrentKey = 0;
           
             
           }
           else{
            gameVictory.SetActive(true);
            audioManager.instance.SetSound(7,false);
           }
           
            //gameVictory.SetActive(true);
            PlayerPrefs.SetInt("levelUnlocked",PlayerPrefs.GetInt("levelUnlocked") + 1);
            IsGameStarted = false;
            //PlayerPrefs.SetInt("nv1",PlayerPrefs.GetInt("nv1") + 1);
           
            //audioManager.instance.SetSound(7, false);

            //PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + 300);
      
          
            if (TimeGame1.remainingDuration >=80)
            {
                PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + 300 + PlayerPrefs.GetInt("CoinUpGrade") );
                //int.TryParse(coinWinText.text, out var coinwin1);
               int coinwin1 = PlayerPrefs.GetInt("CoinUpGrade") + 300;
               coinWinText.text = coinwin1.ToString();
                PlayerPrefs.SetInt("completeTime40s", PlayerPrefs.GetInt("completeTime40s") + 1);
                TimeGame1.End();
            }
            else if( TimeGame1.remainingDuration < 80)
            {
                PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + 100 + PlayerPrefs.GetInt("CoinUpGrade") );
                //coinWinText.text = " 100";
                int coinwin2 = PlayerPrefs.GetInt("CoinUpGrade") + 100;
                coinWinText.text = coinwin2.ToString();
                TimeGame1.End();
            }
            else if (TimeGame1.remainingDuration <= 40)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 50 + PlayerPrefs.GetInt("CoinUpGrade")  );
                //coinWinText.text = " 50";
                int coinwin3 = PlayerPrefs.GetInt("CoinUpGrade") + 50;
                coinWinText.text = coinwin3.ToString();
                TimeGame1.End();
            }
            
        }
        
    }


   
    public void NextLevel()
    {
        //Debug.Log(PlayerPrefs.GetInt("levelUnlocked"));
        BallsManager.Instance.ResetBalls();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("nv1",PlayerPrefs.GetInt("nv1") + 1);
       
        // PlayerPrefs.SetInt("levelUnlocked",PlayerPrefs.GetInt("levelUnlocked") + 1);
       
   

    }
    
    private void OnDisable()
    {
        Ball.OnBallDeath -= OnBallDeath;
        Brick.DescareBrick -= DescareBrick;
    }
}

