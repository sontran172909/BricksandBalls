using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    #region SIngleton:Points

    public static Points Instance;

    private int amount;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    // public int Coins;
    //
    //
    // public void UseCoins(int amount)
    // {
    //     Coins -= amount;
    // }
    // public bool HasEnoughCoins(int price)
    // {
    //     
    //     return (Coins >= amount);
    // }
    public Text CoinsText;
    private int CoinPrice;
    public Text PriceText;
    
    public void UseCoins()
    {
        // Coins -= amount;
        // PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin")- amount);
        int.TryParse(PriceText.text, out CoinPrice);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - CoinPrice);
        CoinsText.text = PlayerPrefs.GetInt("Coin").ToString();
        
       
    }
    
    public bool HasEnoughCoins(int CoinAll)
    {
        int.TryParse(CoinsText.text, out CoinAll);
        return ( CoinAll >= CoinPrice);
    }

}
