
    
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using JetBrains.Annotations;
using UnityEngine.UI;



public class Spindemo : MonoBehaviour
{
    public Button thisButton;
    

   
    [SerializeField] private Text txtNumber;
    public int counter;
    //public GameObject TimeSpin;
    public GameObject freebutton;
    public GameObject spinningbutton;
   // public GameObject Panel;
    [SerializeField] private PickerWheel pickWheel;
    
    public GameObject TimeSpin;
     [SerializeField] private TimSpin timespin;
     public Button buttonexit;
   
    // [SerializeField] private Spin _spin;
    private void Reset()
    {
        thisButton = GetComponent<Button>();
    
    }

    private void Start()
    {
        DisplayTheNumber();   
        if (thisButton == null)
        {
            thisButton = GetComponent<Button>();
        }
        thisButton.onClick.AddListener(OnButtonClick);
        thisButton.enabled = true;
        
    }
    
  
    
    public void OnButtonClick()
    {
        
        buttonexit.GetComponent<Button>().interactable = false;
        freebutton.SetActive(false);
        spinningbutton.SetActive(true);
        TimeSpin.SetActive(true);
        timespin.SetDuration(10).Begin();
        
        pickWheel.OnSpinStart(() =>
        {
            IncreaseAndDisplay();
            Debug.Log("Spin started..");
        });
        pickWheel.OnSpinEnd(WheelPiece =>
             {
                 Debug.Log("Spin end : label:" + WheelPiece.Label);
                 if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.Ball1   )
                 { 
                     //PlayerPrefs.SetInt("idballselected",WheelPiece.IdBallReward);
                    PlayerPrefs.SetInt("idBall1", WheelPiece.IdBallReward);
                   //Debug.Log(WheelPiece.IdBallReward);
                    
                 }
                 if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.Ball9   )
                 { 
                     //PlayerPrefs.SetInt("idballselected",WheelPiece.IdBallReward);
                     PlayerPrefs.SetInt("idBall9", WheelPiece.IdBallReward);
                     //Debug.Log(WheelPiece.IdBallReward);
                    
                 }
                 else if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.Paddle)
                 {
                     PlayerPrefs.SetInt("idPaddle", WheelPiece.idPaddleReward);
                     //Debug.Log(WheelPiece.idPaddleReward);
                 }
                 else if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.Coin)
                 {
                     PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") + WheelPiece.coinReward);
                    // Debug.Log(WheelPiece.coinReward);
                 }
                 else if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.x3)
                 {
                     PlayerPrefs.SetInt("X3",PlayerPrefs.GetInt("X3") + WheelPiece.x3Reward);
                    // Debug.Log(WheelPiece.x3Reward);
                 }
                 else if (WheelPiece.type == EasyUI.PickerWheelUI.RewardType.Plus3)
                 {
                     PlayerPrefs.SetInt("+3",PlayerPrefs.GetInt("+3") + WheelPiece.Plus3Reward);
                    // Debug.Log(WheelPiece.Plus3Reward);
                 }
                 PlayerPrefs.SetInt("IdImages", WheelPiece.idimages);
                 
                 thisButton.interactable = true;
               
               
             });
             
             pickWheel.Spin();
             
             PlayerPrefs.SetInt("countspin",PlayerPrefs.GetInt("countspin") - 1);
             DisplayTheNumber();
    }

    private void Update()
    {
        txtNumber.text = PlayerPrefs.GetInt("countspin").ToString();
    }


    public void IncreaseAndDisplay()
    {
        TheValue();
        DisplayTheNumber();
        
    }
    public void DisplayTheNumber()
    {
        txtNumber.text = counter.ToString();
    }

   // public GameObject TimeManager;
    public void TheValue()
    {
        int.TryParse(txtNumber.text, out counter);
        counter--;
        // if (counter == 0)
        // {
        //
        //     thisButton.GetComponent<Button>().interactable = false;
        //   
        //      TimeSpin.SetActive(true);
        //      //timespin.SetDuration(88820).Begin();
        //      // TimeManager.SetActive(true);
        //     PlayerPrefs.SetString("TimeNow", DateTime.Now.ToString());
        //    
        // }
    }

 

    
}
