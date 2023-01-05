using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ValueButton : MonoBehaviour
{
   [SerializeField] private Text txtNumber;
   public int counter = 3;

   public void Start()
   {
      DisplayTheNumber();
   }

   public void IncreaseAndDisplay()
   {
      TheValue();
      DisplayTheNumber();
   }
   public void TheValue()
   {
      counter--;
      if (counter <= 0)
      {
         
      }
   }
   
      public void DisplayTheNumber()
   {
      txtNumber.text = counter.ToString();
   }
}
