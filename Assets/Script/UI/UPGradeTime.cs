using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UPGradeTime : MonoBehaviour
{
    public Text coinText;
   
    public Text coinGrade;
    public Text sttGrade;
    private int coins;
    private int stt;
    private int allcoin;
    public Button thisButton;
    public ParticleSystem fx;

    private void Reset()
    {
        thisButton = GetComponent<Button>();
    
    }
    private void Start()
    {
  
        thisButton.onClick.AddListener(onclickGrade);
        thisButton.enabled = true;
        // theValue();
        // theNumber();
    }
    
    // Update is called once per frame
  
    public void onclickGrade()
    {
        int.TryParse(coinGrade.text, out coins);
        int.TryParse(coinText.text, out allcoin);
        if (allcoin >= coins)
        {
            theValue();
            PlayerPrefs.SetInt("SttTime",PlayerPrefs.GetInt("SttTime")+1);
            upgrade();
            theNumber();
        }
        fx.Play();
        
    }

    public void upgrade()
    {
        int x = PlayerPrefs.GetInt("levelUnlocked");
        if ( x >= 1 && x <= 20 )
        {
            PlayerPrefs.SetInt("TimeCount",PlayerPrefs.GetInt("TimeCount") + 3);
            if (stt >= 20)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
        }
        else if ( x >= 21 && x <= 50)
        {
            PlayerPrefs.SetInt("TimeCount",PlayerPrefs.GetInt("TimeCount") + 2);
            thisButton.GetComponent<Button>().enabled = true;
            if (stt >= 50)
            {
                thisButton.GetComponent<Button>().enabled = false;
            }
        }
        else if ( x>= 51 && x<= 110)
        {
            PlayerPrefs.SetInt("TimeCount",PlayerPrefs.GetInt("TimeCount") + 1);
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
        //sttGrade.text = stt.ToString();
        stt++;
      
    }
    public bool CoinGradeStart { get; set; }
    private void Awake()
    {
       //PlayerPrefs.SetInt("levelUnlocked",1);
        if (PlayerPrefs.GetInt("CheckCoinGradeTimeStart") == 0)
        {
            CoinGradeStart = false;
        }
        else
        {
            CoinGradeStart = true;
        }
        if (CoinGradeStart == false)
        {
            PlayerPrefs.SetInt("CoinPlusTime", 100);
       
            CoinGradeStart = true;
            PlayerPrefs.SetInt("CheckCoinGradeTimeStart",(CoinGradeStart ? 1: 0));
        }
    
    }
       private void Update()
        {
            sttGrade.text = PlayerPrefs.GetInt("SttTime").ToString();
            coinGrade.text = PlayerPrefs.GetInt("CoinPlusTime").ToString();
        }

    public void theNumber()
    {
        
        stt = PlayerPrefs.GetInt("SttTime");
        sttGrade.text = stt.ToString();
        PlayerPrefs.SetInt("CoinGrade", 100 );
        if (stt > 0 && stt <= 1)
        {
          
            int Plus = PlayerPrefs.GetInt("CoinGrade", 100);
            PlayerPrefs.SetInt("CoinPlusTime", Plus);
            coinGrade.text = Plus.ToString();
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - Plus);
            coinText.text = PlayerPrefs.GetInt("Coin").ToString();
            
        }

        if (stt > 1)
        {
            int x = PlayerPrefs.GetInt("levelUnlocked");
            int plus = PlayerPrefs.GetInt("CoinGrade") + (20 * x);
            PlayerPrefs.SetInt("CoinPlusTime", plus);
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
