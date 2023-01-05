using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taskmanager : MonoBehaviour
{
    // #region Singleton
    //
    // private static Taskmanager _instance;
    // public static Taskmanager Instance => _instance;
    //
    // private void Awake()
    // {
    //     if (_instance != null)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         _instance = this;
    //     }
    // }
    //
    // #endregion
    
    [SerializeField] private GameObject UnClam1;
    [SerializeField] private GameObject UnClam2;
    [SerializeField] private GameObject UnClam3;
    [SerializeField] private GameObject UnClam4;
    [SerializeField] private GameObject UnClam5;
    [SerializeField] private GameObject UnClam6;
    [SerializeField] private GameObject UnClam7;
    [SerializeField] private GameObject UnClam8;
    [SerializeField] private GameObject UnClam9;
    [SerializeField] private GameObject UnClam10;
    [SerializeField] private GameObject missonNV1;
    [SerializeField] private GameObject missonNV2;
    [SerializeField] private GameObject missonNV3;
    [SerializeField] private GameObject missonNV4;
    [SerializeField] private GameObject missonNV5;
    [SerializeField] private GameObject missonNV6;
    [SerializeField] private GameObject missonNV7;
    [SerializeField] private GameObject missonNV8;
    [SerializeField] private GameObject missonNV9;
    [SerializeField] private GameObject missonNV10;
    [SerializeField] private Text CoinsTextAll;
    public Text textcoin1;
    public Text textcoin2;
    public Text textcoin3;
    public Text textcoin4;
    public Text textcoin5;
    public Text textcoin6;
    public Text textcoin7;
    public Text textcoin8;
    public Text textcoin9;
    public Text textcoin10;
    public GameObject taskimages;


    // public void Start()
    // {
    //     tasknv();
    //
    // }
    //
    // public void tasknv()
    // {
    //     int nv = PlayerPrefs.GetInt("nv1");
    //     Debug.Log(nv);
    //     if (nv >= 5)
    //     {
    //         taskimages.SetActive(true);
    //         Debug.Log("VAR");
    //     }
    // }

    public void Update()
    {
        CoinsTextAll.text = PlayerPrefs.GetInt("Coin").ToString();
        if (PlayerPrefs.GetInt("nv1") >=5)
        {
            UnClam1.SetActive(false);
           //taskimages.SetActive(true);
        }

        if (PlayerPrefs.GetInt("nv1") >= 10)
        {
            UnClam2.SetActive(false);
          
        }
        if (PlayerPrefs.GetInt("nv1") >= 15)
        {
            UnClam3.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 20)
        {
            UnClam4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 25)
        {
            UnClam5.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 30)
        {
            UnClam6.SetActive(false);
        }

        if (PlayerPrefs.GetInt("nv1") >= 40)
        {
            UnClam7.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 50)
        {
            UnClam8.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 70)
        {
            UnClam9.SetActive(false);
        }
        if (PlayerPrefs.GetInt("nv1") >= 100)
        {
            UnClam10.SetActive(false);
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
        if (PlayerPrefs.GetInt("offclaim") >= 7)
        {
            missonNV7.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 8)
        {
            missonNV8.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 9)
        {
            missonNV9.SetActive((false));
            
        }
        if (PlayerPrefs.GetInt("offclaim") >= 10)
        {
            missonNV10.SetActive((false));
            
        }
    }

    public void btNV1()
    {
        taskimages.SetActive(false);
        PlusCoin1();
        
        //nhan thuong
        missonNV1.SetActive((false));
      
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV2()
    {
        PlusCoin2();
       taskimages.SetActive(false);
        //nhan thuong
        missonNV2.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV3()
    {
        taskimages.SetActive(false);
        PlusCoin3();
        //nhan thuong
        missonNV3.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV4()
    {
        taskimages.SetActive(false);
        PlusCoin4();
        //nhan thuong
        missonNV4.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV5()
    {
        taskimages.SetActive(false);
        PlusCoin5();
        //nhan thuong
        missonNV5.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV6()
    {
        taskimages.SetActive(false);
        PlusCoin6();
        //nhan thuong
        missonNV6.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV7()
    {
        taskimages.SetActive(false);
        PlusCoin7();
        //nhan thuong
        missonNV7.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV8()
    {
        taskimages.SetActive(false);
        PlusCoin8();
        //nhan thuong
        missonNV8.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV9()
    {
        taskimages.SetActive(false);
        PlusCoin9();
        //nhan thuong
        missonNV9.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
    }
    public void btNV10()
    {
        taskimages.SetActive(false);
        PlusCoin10();
        //nhan thuong
        missonNV10.SetActive((false));
        PlayerPrefs.SetInt("offclaim", PlayerPrefs.GetInt("offclaim") + 1);
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
    void PlusCoin7()
    {
        int.TryParse(textcoin7.text, out var CoinPlus7);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus7);
    }
    void PlusCoin8()
    {
        int.TryParse(textcoin8.text, out var CoinPlus8);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus8);
    }
    void PlusCoin9()
    {
        int.TryParse(textcoin9.text, out var CoinPlus9);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus9);
    }
    void PlusCoin10()
    {
        int.TryParse(textcoin10.text, out var CoinPlus10);
        PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + CoinPlus10);
    }
}
