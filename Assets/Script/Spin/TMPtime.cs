using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TMPtime : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text txtNumber;
    //[SerializeField] private TimSpin Timespin;

    string time;
    string dateQuitString;

    DateTime dateStart;
    DateTime dateQuit;

    private TimeSpan timeSpan;

    private void Awake()
    {
        time = DateTime.UtcNow.ToLocalTime().ToString("dd/MM/yyyy");
        PlayerPrefs.SetString("Time", time);
    }

    private void Start()
    {
        // check time 
        dateQuitString = PlayerPrefs.GetString("DateQuit", "");
        if (!dateQuitString.Equals(""))
        {
            
            
            
            dateQuit = DateTime.Parse(dateQuitString);
            dateStart = DateTime.Now;
            
            // check counter
            if (dateStart > dateQuit)
            {
                timeSpan = dateStart - dateQuit;
                if (timeSpan.Days >= 1)
                {
                    //Debug.Log("ngay moi");
                    var couter = PlayerPrefs.GetInt("countspin");
                    // Debug.Break();
                    PlayerPrefs.SetInt("countspin", 3);
                    couter = PlayerPrefs.GetInt("countspin");
                    
                }
                else
                {
                   // Debug.Log("trong ngay");
                    var couter = PlayerPrefs.GetInt("countspin");
                    PlayerPrefs.SetInt("countspin", couter);
                }
                
            }
           
            PlayerPrefs.SetString("DateQuit","");
        }
         
    }

    private void OnApplicationQuit()
    {
        // save time quit
        
         DateTime dateQuit = DateTime.Now;
      
         // var dateQuit = $"{DateTime.Now:dd/MM/yyyy}";
      
        PlayerPrefs.SetString("DateQuit", dateQuit.ToString());
        
        // save counter
        int.TryParse(txtNumber.text, out var couter);
        PlayerPrefs.SetInt("countspin", couter);
        PlayerPrefs.Save();
    }

  

  
}
