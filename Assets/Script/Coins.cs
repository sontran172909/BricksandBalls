using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text coinText;
   
    public Text textlevel;
    public GameObject taskimages;
    public Text txtNumber;

    

    private void Start()
    {
        
        if (PlayerPrefs.HasKey("nv1"))
        {
            int nv = PlayerPrefs.GetInt("nv1");
           
            if (nv >= 5)
            {
                // taskimages.SetActive(true);

                if (PlayerPrefs.GetInt("offclaim") == 1)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 1)
                {
                    taskimages.SetActive(true);
                }
               
            }
            if (nv >= 10)
            {
                //taskimages.SetActive(true);
                if (PlayerPrefs.GetInt("offclaim") == 2)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 2)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 15)
            {
                if (PlayerPrefs.GetInt("offclaim") == 3)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 3)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 20)
            {
                if (PlayerPrefs.GetInt("offclaim") == 4)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 4)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 25)
            {
                if (PlayerPrefs.GetInt("offclaim") == 5)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 5)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 30)
            {
                if (PlayerPrefs.GetInt("offclaim") == 6)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 6)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 40)
            {
                if (PlayerPrefs.GetInt("offclaim") == 7)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 7)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 50)
            {
                if (PlayerPrefs.GetInt("offclaim") == 8)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 8)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 70)
            {
                if (PlayerPrefs.GetInt("offclaim") == 9)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 9)
                {
                    taskimages.SetActive(true);
                }
            }
            if (nv >= 100)
            {
                if (PlayerPrefs.GetInt("offclaim") == 10)
                {
                    taskimages.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("offclaim") < 10)
                {
                    taskimages.SetActive(true);
                }
            }
        }
        else
        {
            PlayerPrefs.SetInt("nv1", 0);
          
        }
        
        
        audioManager.instance.SetMusicBg();
      
        //PlayerPrefs.SetInt("countspin", 3);
        
    }

    public bool coinstart { get; set; }
    // public bool levelstart { get; set; }
    //
    // public bool CountSpin { get; set; }
    private void Awake()
    {
        //PlayerPrefs.SetInt("levelUnlocked",1);
        if (PlayerPrefs.GetInt("CheckCoinStart") == 0)
        {
            coinstart = false;
        }
        else
        {
            coinstart = true;
        }
        if (coinstart == false)
        {
            PlayerPrefs.SetInt("Coin", 0);
            PlayerPrefs.SetInt("levelUnlocked", 1);
            PlayerPrefs.SetInt("countspin", 3);
            PlayerPrefs.SetInt("idballselected", 24);
            PlayerPrefs.SetInt("idPaddleselected", 12);
            coinstart = true;
            PlayerPrefs.SetInt("CheckCoinStart",(coinstart ? 1: 0));
        }

       
    
    }


    public Button spinbutton;
    [SerializeField] private Text DateTimeNow;
    void Update()
    {
        
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        textlevel.text = PlayerPrefs.GetInt("levelUnlocked" ).ToString();
        txtNumber.text = PlayerPrefs.GetInt("countspin").ToString();

        var couter = PlayerPrefs.GetInt("countspin");
        if (couter == 0)
        {
            spinbutton.GetComponent<Button>().interactable = false;
            DateTimeNow.text = DateTime.Now.ToLongDateString();
        }
    }
}
