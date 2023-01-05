using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDaily : MonoBehaviour
{
    
    
    [SerializeField] private GameObject UnClam1;
    [SerializeField] private GameObject UnClam2;
    [SerializeField] private GameObject UnClam3;
    [SerializeField] private GameObject UnClam4;
    [SerializeField] private GameObject UnClam5;
    [SerializeField] private GameObject UnClam6;
  
    [SerializeField] private GameObject missonNV1;
    [SerializeField] private GameObject missonNV2;
    [SerializeField] private GameObject missonNV3;
    [SerializeField] private GameObject missonNV4;
    [SerializeField] private GameObject missonNV5;
    [SerializeField] private GameObject missonNV6;
 
    // [SerializeField] private Text CoinsTextAll;
    public Text textcoin1;
    public Text textcoin2;
    public Text textcoin3;
    public Text textcoin4;
    public Text textcoin5;
    public Text textcoin6;

    public GameObject taskimages;


   

    public void Update()
    {
       
        if (PlayerPrefs.GetInt("nv1") >=5)
        {
            UnClam1.SetActive(false);
         
        }
        
        if (PlayerPrefs.GetInt("countItems") >= 5)
        {
            UnClam2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("completeTime40s") >= 1)
        {
            UnClam3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("completeTime40s") >= 3)
        {
            UnClam4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("countspin") == 0)
        {
            UnClam5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 10)
        {
            UnClam6.SetActive(false);
          
        }

   
        //---------------------------------------------------------------------------------------------
        if (PlayerPrefs.GetInt("offclaim") >= 1)
        {
            missonNV1.SetActive((false));
            
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 2)
        {
            missonNV2.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 3)
        {
            missonNV3.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 4)
        {
            missonNV4.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 5)
        {
            missonNV5.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 6)
        {
            missonNV6.SetActive((false));
            
        }
    
    }

    public void buttonNV1()
    {
        taskimages.SetActive(false);
        PlusCoin1();
        
        //nhan thuong
        missonNV1.SetActive((false));
      
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }
    public void buttonNV2()
    {
        PlusCoin2();
       taskimages.SetActive(false);
        //nhan thuong
        missonNV2.SetActive((false));
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }
    public void buttonNV3()
    {
        taskimages.SetActive(false);
        PlusCoin3();
        //nhan thuong
        missonNV3.SetActive((false));
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }
    public void buttonNV4()
    {
        taskimages.SetActive(false);
        PlusCoin4();
        //nhan thuong
        missonNV4.SetActive((false));
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }
    public void buttonNV5()
    {
        taskimages.SetActive(false);
        PlusCoin5();
        //nhan thuong
        missonNV5.SetActive((false));
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }
    public void buttonNV6()
    {
        taskimages.SetActive(false);
        PlusCoin6();
        //nhan thuong
        missonNV6.SetActive((false));
        PlayerPrefs.SetInt("offclaim2", PlayerPrefs.GetInt("offclaim2") + 1);
    }

    void PlusCoin1()
    {
        int.TryParse(textcoin1.text, out var CoinPlus1);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus1);
    }

    void PlusCoin2()
    {
        int.TryParse(textcoin2.text, out var CoinPlus2);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus2);
    }
    void PlusCoin3()
    {
        int.TryParse(textcoin3.text, out var CoinPlus3);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus3);
    }
    void PlusCoin4()
    {
        int.TryParse(textcoin4.text, out var CoinPlus4);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus4);
    }
    void PlusCoin5()
    {
        int.TryParse(textcoin5.text, out var CoinPlus5);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus5);
    }
    void PlusCoin6()
    {
        int.TryParse(textcoin6.text, out var CoinPlus6);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus6);
    }

}
