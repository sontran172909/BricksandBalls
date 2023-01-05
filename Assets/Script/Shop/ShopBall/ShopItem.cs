using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace ShopItems
{
    public class ShopItem : MonoBehaviour
    {
        // public bool IsPurhase
        // {
        //     get => PlayerPrefs.GetInt("purhaseshopitem" + IDShopItem) == 1;
        //     set => PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, value ? 1 : 0);
        // }


        public int IDShopItem;
        public Image image;
        public Button buttonBuy;
        public Button buttonSelect;
        public Text statusButtonBuy;
        public Text CoinsText;
        private int CoinAll;
        public Text statusButtonSelect;
       // public int ShopPoint;
        public Text Text;

        private void Start()
        {
          
            if (PlayerPrefs.GetInt("idBall1") == 1 && IDShopItem == 1)
            {
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
              
                PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, 1);
                if (PlayerPrefs.GetInt("idBall1") == IDShopItem)
                {
                    Debug.Log("var1");
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
             
            }
            if (PlayerPrefs.GetInt("idBall9") == 9 && IDShopItem == 9)
            {
              
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
              
               PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, 1);
                if (PlayerPrefs.GetInt("idBall9") == IDShopItem)
                { 
                    Debug.Log("var2");
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
                // else
                // {
                //     transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Select";
                // }
              
                
            }
          
        }
        
        public void OnEnable()
        {
            //IsPurhase = true;
            if (PlayerPrefs.GetInt("idBall1") == 1 && IDShopItem == 1)
            {
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
                PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, 1);
              
                if (PlayerPrefs.GetInt("idBall1") == IDShopItem)
                {
                    Debug.Log("var3");
                    transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
             
            
            }
            if (PlayerPrefs.GetInt("idBall9") == 9 && IDShopItem == 9)
            {
              
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
                //IsPurhase = true;
                PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, 1);
                if (PlayerPrefs.GetInt("idBall9") == IDShopItem)
                { 
                    Debug.Log("var4");
                   transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "Selected";
                }
              
                
            }
          
        }

  
        private void Reset()
        {
            buttonBuy = GetComponent<Button>();
    
        }
        public void Initialize(int id, Sprite sprite, int price)
        {
         
            IDShopItem = id;
            image.sprite = sprite;
            Text.text = price.ToString();
            
            buttonBuy.gameObject.SetActive(true);
            buttonBuy.enabled = true;
            buttonSelect.gameObject.SetActive(false);
            
            buttonBuy.onClick.AddListener(OnButtonBuyClick);
            buttonSelect.onClick.AddListener(OnButtonSelectClick);

            Debug.Log("ashjjkjhkk : "+PlayerPrefs.HasKey("purhaseshopitem" + IDShopItem));
            //if (!PlayerPrefs.HasKey("purhaseshopitem" + IDShopItem)) IsPurhase = false;
            if (PlayerPrefs.GetInt("purhaseshopitem" + IDShopItem) == 1)
            {
             
                buttonBuy.gameObject.SetActive(false);
                buttonSelect.gameObject.SetActive(true);
                if (Shop.IDBallSelected == IDShopItem  )
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
            
            PlayerPrefs.SetInt("purhaseshopitem" + IDShopItem, 1);
            //IsPurhase = true;
            statusButtonSelect.text = "Select";
            buttonSelect.gameObject.SetActive(true);
            buttonBuy.gameObject.SetActive(false);
            UseCoins();
         
        }
        void UseCoins()
        {
          
            int.TryParse(Text.text, out var CoinPrice);
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin") - CoinPrice);
            CoinsText.text = PlayerPrefs.GetInt("Coin").ToString();

        }
        
        private void OnButtonSelectClick()
        {
           
            PlayerPrefs.SetInt("idBall1", 0);
            PlayerPrefs.SetInt("idBall9", 0);
            Shop.IDBallSelected =IDShopItem;
            statusButtonSelect.text = "Selected";
            buttonBuy.gameObject.SetActive(false);
            
            // Debug.Log("before: " + IDShopItem);
             Shop.OnIDBallChangeAction.Invoke(IDShopItem);
            // Debug.Log("delay: " + IDShopItem);

          
        }

        public void SetSelectButton()
        {
            statusButtonSelect.text = "Select";
        }

     
    }
}