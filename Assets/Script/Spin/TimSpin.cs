using System.Collections;
using System.Collections.Generic;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using System;

public class TimSpin : MonoBehaviour
{
     

    [Header("TimeSpin UI references :")] [SerializeField]
    private Text TimeSpin;

    public GameObject spinbut;
    public GameObject claimbutton;
    public int Duration { get; private set; }
    public int remainingDuration;
    public Button buttonexit;
   
     public GameObject panelReward;
     [SerializeField] private Text txtNumber;

     public Button spinbutton;
     
   

    public bool IsGameStarted { get; set; }
  
    private void Awake()
    {
        ResetTime();
        
    }
    private void Reset()
    {
        buttonexit = GetComponent<Button>();
        spinbutton = GetComponent<Button>();

    }
    
    private void Start()
    {
        buttonexit.enabled = true;
        
        var counter = PlayerPrefs.GetInt("countspin");
        if (counter < 3)
        {
            //DateTimeNow.text = DateTime.Now.ToLongDateString();
        }
    }

 

    public void ResetTime()
    {
        TimeSpin.text = "00:00:00";
        Duration = remainingDuration = 0 ;
        
    }

    public TimSpin SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        //StopAllCoroutines();
        StartCoroutine(UpdateTime());
      
    }

     [SerializeField] private Text DateTimeNow;

    public IEnumerator UpdateTime()
    {
     
        while (remainingDuration > 0)
        {
            remainingDuration--;
            yield return new WaitForSeconds(1f);
            UpdateUI(remainingDuration);
           
            buttonexit.GetComponent<Button>().interactable = false;
        }
    
       if (remainingDuration == 0)
       {
           int.TryParse(txtNumber.text, out var couter);
           spinbut.SetActive(true);
           spinbut.GetComponent<Button>().enabled = true;
           claimbutton.SetActive(false);
           gameObject.SetActive(false);
           if (couter == 0)
           {
               spinbutton.GetComponent<Button>().interactable = false;
               DateTimeNow.text = DateTime.Now.ToLongDateString();
               
           }
           panelReward.SetActive(true);
           buttonexit.GetComponent<Button>().interactable = true;
          
       }
       
        //End();
    }
    

   //public GameObject exitbutton;

    private void UpdateUI(int seconds)
    {
        TimeSpin.text = string.Format("{0:D2}:{1:D2}:{2:D2}",seconds/3600, seconds % 3600 / 60, seconds % 3600 % 60);
    }
    
    // public void End()
    // {
    //     ResetTime();
    //     gameObject.SetActive(false);
    // }
    //
    // private void OnDestroy()
    // {
    //     StopAllCoroutines();
    // }
}
