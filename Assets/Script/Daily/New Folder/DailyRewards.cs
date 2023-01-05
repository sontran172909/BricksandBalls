using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewards : MonoBehaviour
{
    public List<DailyRewardData> rewardDatas;
    public Button thisButton;
    public Text coinText;
    public GameObject NoReward;
    public Text amount;
    private int coin;

    private void OnEnable()
    {
        thisButton = GetComponent<Button>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("TimeGetReward"))
        {
            PlayerPrefs.SetString("TimeGetReward", DateTime.Now.Day - 1 + "-" + DateTime.Now.Month);
        }
        var time = DateTime.Now;
        var splitTimer = PlayerPrefs.GetString("TimeGetReward").Split('-');
        if (DateTime.Now > DateTime.Today)
        {
            onclickclaim();
        }
    }

    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        
    }
    
    public void onclickclaim()
    {
        // amount.text = coin.ToString();
        int.TryParse(amount.text, out coin);
        NoReward.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + coin);
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        PlayerPrefs.SetString("TimeGetReward", DateTime.Now.Day + "-" + DateTime.Now.Month);
        thisButton.GetComponent<Button>().enabled = false;
    }

}
