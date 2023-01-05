using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemStore : MonoBehaviour
{
   public Text coinText;
   public Button thisButton;
   public Text coinstore;
   
   public Text bufftextx3;

   public Text PlusText;
   //private int coins;


   private void Start()
   {
      thisButton.onClick.AddListener(onclick);
   }

   private void Update()
   {
        int.TryParse(coinText.text, out var coinall);
        int.TryParse(coinstore.text, out var coins);
      
      if (coinall < coins)
      {
         thisButton.interactable = false;
      }
      else
       {
            thisButton.interactable = true;
       }
      
      
   }

   public void onclick()
   {
      thisButton.interactable = false;
      int.TryParse(coinstore.text, out var coins);
      PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - coins);
      coinText.text = PlayerPrefs.GetInt("Coin").ToString();
      int.TryParse(bufftextx3.text, out var amount);
      PlayerPrefs.SetInt("X3", PlayerPrefs.GetInt("X3") + amount);
      int.TryParse(PlusText.text, out var plusball);
      PlayerPrefs.SetInt("+3", PlayerPrefs.GetInt("+3") + plusball);
   }
}
