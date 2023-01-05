using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpGradeBall : MonoBehaviour
{
    public Text coinText;
   
    public Text coinGrade;
    public Text sttGrade;
    private int coins;
    private int stt;
    private int allcoin;
    public Button thisButton;
    public ParticleSystem fx;

    private int plus;

    private void Reset()
    {
        thisButton = GetComponent<Button>();
      
    }

    

    private void Start()
    {
        thisButton.onClick.AddListener(onclickGrade);
        thisButton.enabled = true;
       
        // theNumber();
        // theValue();

    }

    // Update is called once per frame
    public void onclickGrade()
    {
      
        int.TryParse(coinText.text, out allcoin);
        int.TryParse(coinGrade.text, out coins);
        if (allcoin >= coins)
        {
            
            theValue();
            PlayerPrefs.SetInt("SttBall",PlayerPrefs.GetInt("SttBall")+1);
            theNumber();
            upgraded();
        }
        fx.Play();
    }

    public void upgraded()
    {
        int x = PlayerPrefs.GetInt("levelUnlocked");
        if ( x <= 5 )
        {
            PlayerPrefs.SetInt("BallCount", PlayerPrefs.GetInt("BallCount") + 10);
            if (stt >= 5)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
           
        }
        else if ( x > 5 && x <= 15)
        {
       
            PlayerPrefs.SetInt("BallCount", PlayerPrefs.GetInt("BallCount") + 5);
            thisButton.GetComponent<Button>().enabled = true;
            if (stt >= 15)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
            
        }
        else if (x >=16 && x <= 45)
        {
            PlayerPrefs.SetInt("BallCount", PlayerPrefs.GetInt("BallCount") + 2);
            thisButton.GetComponent<Button>().enabled = true;
            if (stt >= 45)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
        }
        else if ( x>=46 && x <= 70)
        {
            PlayerPrefs.SetInt("BallCount", PlayerPrefs.GetInt("BallCount") + 1);
            thisButton.GetComponent<Button>().enabled = true;
            if (stt >= 70)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
        }
    }
    public void IncreaseAndDisplay()
    {
        theValue();
        theNumber();
    }
    public void theValue()
    {
        int.TryParse(sttGrade.text, out stt);

        stt++;
        
    }
    public bool CoinGradeStart { get; set; }
    private void Awake()
    {
        //PlayerPrefs.SetInt("levelUnlocked",1);
        if (PlayerPrefs.GetInt("CheckCoinGradeStart") == 0)
        {
            CoinGradeStart = false;
        }
        else
        {
            CoinGradeStart = true;
        }
        if (CoinGradeStart == false)
        {
            PlayerPrefs.SetInt("CoinPlus", 100);
       
            CoinGradeStart = true;
            PlayerPrefs.SetInt("CheckCoinGradeStart",(CoinGradeStart ? 1: 0));
        }
    
    }

    private void Update()
    {
        
        sttGrade.text = PlayerPrefs.GetInt("SttBall").ToString();
        coinGrade.text = PlayerPrefs.GetInt("CoinPlus").ToString();
       // PlayerPrefs.GetInt("levelUnlocked").ToString();
    }

    public void theNumber()
    {
        stt = PlayerPrefs.GetInt("SttBall");
        sttGrade.text = stt.ToString();
        PlayerPrefs.SetInt("CoinGrade", 100 );
        if ( stt > 0 && stt <= 1)
        {
         
            int Plus = PlayerPrefs.GetInt("CoinGrade", 100);
            PlayerPrefs.SetInt("CoinPlus", Plus);
            coinGrade.text = Plus.ToString();
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - Plus);
            coinText.text = PlayerPrefs.GetInt("Coin").ToString();
          
            
        }
        
        
        if (stt > 1)
        {
            int x = PlayerPrefs.GetInt("levelUnlocked");
            plus = PlayerPrefs.GetInt("CoinGrade") + (20 * x);
            PlayerPrefs.SetInt("CoinPlus",plus );
            coinGrade.text = plus.ToString() ;
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - plus);
            coinText.text = PlayerPrefs.GetInt("Coin").ToString();
           
        }

        if (stt >= 70)
        {
            thisButton.GetComponent<Button>().enabled = false;
        }
        
    }

  
  
}
