using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BrickBall.ShopPaddle;
using UnityEngine.Events;

public class paddleshop : MonoBehaviour
{
    public static paddleshop instance;
    
    
    public static int IDPaddleSelected
    {
        get => PlayerPrefs.GetInt("idPaddleselected");
        set => PlayerPrefs.SetInt("idPaddleselected", value);
    }
  

    [System.Serializable]
     class ShopItemInfor
     {
         public Sprite Sprite;
         public int IDShopPaddle;
        
         public int Price;

        
     }

    
     public static Action<int> OnIDPaddleChangeAction;

     
    [SerializeField] private List<ShopItemInfor> ShopItemsList;
    [SerializeField] private Animator NoCoinAnimation;
    [SerializeField] private Text CoinsText;
     private GameObject ItemTemplate;
     private GameObject g;
    // public GameObject Select;
    [SerializeField] private Transform ShopScrollView;
    private Button buyBtn;
    private List<ShopPaddle> _shopItems = new List<ShopPaddle>();
    
    private void Start()
    {
        instance = this;
        
        if (!PlayerPrefs.HasKey("idPaddleselected")) IDPaddleSelected = 0;
     
     
        var shopItemPrefabs = ShopScrollView.GetChild(0).GetComponent<ShopPaddle>();
  
        foreach (var shopItemInfor in ShopItemsList)
        {
            
            var itemSpawn = Instantiate(shopItemPrefabs, ShopScrollView);
            itemSpawn.Initialize(shopItemInfor.IDShopPaddle, shopItemInfor.Sprite, shopItemInfor.Price);
          
            
            _shopItems.Add(itemSpawn);
    
            
        }
        shopItemPrefabs.gameObject.SetActive(false);

       
        
        OnIDPaddleChangeAction += OnIDPaddleChange;
        
        
        // for (var i = 0; i < ShopItemsList.Count; i++)
        // {
        //     // var itemSpawn = Instantiate(shopItemPrefabs, ShopScrollView);
        //     // itemSpawn.Initialize();
        //     g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Sprite;
        //     g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
        //     g.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].IDShopItem.ToString();
        //     buyBtn = g.transform.GetChild(2).GetComponent<Button>();
        //     //buyBtn.interactable = !ShopItemsList[i].IsPuschased;
        //     buyBtn.AddEventListener(i, OnShopItemBtnClick);
        //     
        // }
        // Destroy(ItemTemplate);

        // for (int i = 0; i < ShopItemsList.Count; i++)
        // { 
        //     buyBtn = gameObject.transform.GetChild(2).GetComponent<Button>();
        //     buyBtn.AddEventListener(i, OnShopItemBtnClick);   
        // }

      
        SetCoinsUI();
       
    }

 

  
    private void OnIDPaddleChange(int idPaddle )
    {
        foreach (var item in _shopItems)
        {
            if (item.IDShopPaddle != idPaddle)
            {
                item.SetSelectButton();
            }
            
        }
    }
  

    
     public void  OnShopItemBtnClick (int itemIndex)
     {
     
       if (Points.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Points.Instance.UseCoins();
            
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
       
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "SELECT";
            //change Ui text : coins
            SetCoinsUI();
        }
        else
        {
           NoCoinAnimation.SetTrigger("NoCoins"); 
        }
        // PlayerPrefs.SetInt("IDShopItem", 0);
    }
    
   
    /*---------------------------Shop coins ui --------------*/
    void SetCoinsUI()
    {
        CoinsText.text = PlayerPrefs.GetInt("Coin").ToString();
        
    }
 
}
