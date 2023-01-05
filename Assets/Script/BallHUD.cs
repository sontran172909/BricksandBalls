using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class BallHUD : MonoBehaviour
{
    [SerializeField] private Text BallText;
    public int balls = 1;
    public int Value { get; set; }
   
    private void Start()
    {
        UpdateHUD();
        
    }

    private void Update()
    {
        
        balls = BallsManager.Instance.Balls.Count;
       
    }
    
    private void UpdateHUD()
    {
        BallText.text = balls.ToString();
     
    }

    private void FixedUpdate()
    {
        BallText.text = balls.ToString();
        
    }
}
