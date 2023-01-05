using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace BrickBall.ShopPaddle
{
    public class ShopPaddle : MonoBehaviour
    {
        // public bool IsPurhase
        // {
        //     get => PlayerPrefs.GetInt("purhaseshoppaddle" + IDShopPaddle) == 1;
        //     set => PlayerPrefs.SetInt("purhaseshoppaddle" + IDShopPaddle, value ? 1 : 0);
        // }


        public int IDShopPaddle;
        public Image image;
        public Button buttonBuy;
        public Button buttonSelect;
        public Text statusButtonBuy;
        public Text CoinsText;
     
        public Text statusButtonSelect;
       // public int ShopPoint;
        public Text Text;
        private void Start()
        {
          
            if (PlayerPrefs.GetInt("idPaddle") == 2 && IDShopPaddle == 2)
            {
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
              
                PlayerPrefs.SetInt("purhaseshoppaddle" + IDShopPaddle, 1);
                if (PlayerPrefs.GetInt("idPaddle") == IDShopPaddle)
                {
                   
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
             
            }
          
                
            
          
        }
        private void OnEnable()
        {
          
            if (PlayerPrefs.GetInt("idPaddle") == 2 && IDShopPaddle == 2)
            {
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
              
                PlayerPrefs.SetInt("purhaseshoppaddle" + IDShopPaddle, 1);
                if (PlayerPrefs.GetInt("idPaddle") == IDShopPaddle)
                {
                   
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
             
            }
            
          
        }
        
     

        
        
        public void Initialize(int id, Sprite sprite, int price)
        {
            IDShopPaddle = id;
            image.sprite = sprite;
            Text.text = price.ToString();
            
            buttonBuy.gameObject.SetActive(true);
            buttonSelect.gameObject.SetActive(false);
            
            buttonBuy.onClick.AddListener(OnButtonBuyClick);
            buttonSelect.onClick.AddListener(OnButtonSelectClick);

           // if (!PlayerPrefs.HasKey("purhaseshoppaddle" + IDShopPaddle)) IsPurhase = false;
            if (PlayerPrefs.GetInt("purhaseshoppaddle" + IDShopPaddle)== 1)
            {
             
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
                if (paddleshop.IDPaddleSelected == IDShopPaddle)
                {
                    statusButtonSelect.text = "Selected";
                }
                else
                {
                    statusButtonSelect.text = "Select" ;
                }
                
            }
            else
            {
                buttonBuy.gameObject.SetActive(true);
                buttonSelect.gameObject.SetActive(false);
                statusButtonBuy.text = "Buy";
            
            }
        }

        private int CoinAll;
        private int CoinPrice;
        private void Update()
        {
         
            int.TryParse(CoinsText.text, out CoinAll);
            int.TryParse(Text.text, out CoinPrice);
           
            if (CoinAll < CoinPrice )
            {
                buttonBuy.interactable = false;
              
            }
        }
       

        private void OnButtonBuyClick()
        {
            PlayerPrefs.SetInt("purhaseshoppaddle" + IDShopPaddle, 1);
            //IsPurhase = true;
            statusButtonSelect.text = "Select";
            buttonSelect.gameObject.SetActive(true);
            buttonBuy.gameObject.SetActive(false);
            
            UseCoins();
          
        }
        
         void UseCoins()
        {
            // Coins -= amount;
            // PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin")- amount);
            int.TryParse(Text.text, out var CoinPrice);
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - CoinPrice);
            CoinsText.text = PlayerPrefs.GetInt("Coin").ToString();
        
       
        }
        
        private void OnButtonSelectClick()
        {
            paddleshop.IDPaddleSelected =IDShopPaddle;
            statusButtonSelect.text = "Selected";
            buttonBuy.gameObject.SetActive(false);
            paddleshop.OnIDPaddleChangeAction.Invoke(IDShopPaddle);
            
        }

        public void SetSelectButton()
        {
            statusButtonSelect.text = "Select";
        }

     
    }
}