using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeCoins : MonoBehaviour
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
        // theNumber();
        // theValue();
    }

    // Update is called once per frame
    public void onclickGrade()
    {
        int.TryParse(coinGrade.text, out coins);
        int.TryParse(coinText.text, out allcoin);
        if (allcoin >= coins)
        {
            theValue();
        
            PlayerPrefs.SetInt("SttCoin",PlayerPrefs.GetInt("SttCoin")+1);
            PlayerPrefs.SetInt("CoinUpGrade",PlayerPrefs.GetInt("CoinUpGrade") +5);
            theNumber();
        }
        fx.Play();
        
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
        //BallsManager.Instance.BallsCount++;
    }
    public bool CoinGradeStart { get; set; }
    private void Awake()
    {
        //PlayerPrefs.SetInt("levelUnlocked",1);
        if (PlayerPrefs.GetInt("CheckCoinGradeCoinStart") == 0)
        {
            CoinGradeStart = false;
        }
        else
        {
            CoinGradeStart = true;
        }
        if (CoinGradeStart == false)
        {
            PlayerPrefs.SetInt("CoinPlusCoin", 100);
       
            CoinGradeStart = true;
            PlayerPrefs.SetInt("CheckCoinGradeCoinStart",(CoinGradeStart ? 1: 0));
        }
    
    }

    private void Update()
    {
        sttGrade.text = PlayerPrefs.GetInt("SttCoin").ToString();
      
        coinGrade.text = PlayerPrefs.GetInt("CoinPlusCoin").ToString();
    }
    
  
    public void theNumber()
    {
        stt = PlayerPrefs.GetInt("SttCoin");
        sttGrade.text = stt.ToString();
        PlayerPrefs.SetInt("CoinGrade", 100 );
        if (stt > 0 && stt <= 1)
        {
            int Plus = PlayerPrefs.GetInt("CoinGrade", 100);
            PlayerPrefs.SetInt("CoinPlusCoin", Plus);
            coinGrade.text = Plus.ToString();
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - Plus);
            coinText.text = PlayerPrefs.GetInt("Coin").ToString();
            
        }

        if (stt > 1)
        {
            int x = PlayerPrefs.GetInt("levelUnlocked");
            int plus = PlayerPrefs.GetInt("CoinGrade") + (20 * x);
            PlayerPrefs.SetInt("CoinPlusCoin",plus );
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
