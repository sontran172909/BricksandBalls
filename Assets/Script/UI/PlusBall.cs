using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlusBall : Collectable
{
    public Button thisButton;
    public int counter;
    private void Reset()
    {
        thisButton = GetComponent<Button>();
    }

    private void Start()
    {
       
        if (thisButton == null)
        {
            thisButton = GetComponent<Button>();
        }
        thisButton.onClick.AddListener(OnButtonClick);
       
        thisButton.enabled = true;
        counter = PlayerPrefs.GetInt("+3");
        txtNumber.text = counter.ToString();
        
    }
    protected override void ApplyEffect()
    {
        BallsManager.Instance.SBalls();
    }


    private void Update()
    {
        txtNumber.text = PlayerPrefs.GetInt("+3").ToString();
    }


    public void OnButtonClick()
    {
        if (counter <= 0)
        {
            thisButton.enabled = false;
         
        }
        else
        {
            counter--;
            BallsManager.Instance.SBalls();
            audioManager.instance.SetSound(3, false);
            PlayerPrefs.SetInt("+3",counter);
            PlayerPrefs.SetInt("countItems", PlayerPrefs.GetInt("countItems") + 1);
        }
        txtNumber.text = counter.ToString();
    }   
    
    [SerializeField] private Text txtNumber;

 
}