using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShopItems;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    
    public static int IDBallSelected
    {
        get => PlayerPrefs.GetInt("idballselected");
        set => PlayerPrefs.SetInt("idballselected", value);
    }

    

    [System.Serializable]
     class ShopItemInfor
     {
         public Sprite Sprite;
         public int IDShopItem;
        
         public int Price;

        
     }

     public static Action<int> OnIDBallChangeAction;
     //public static Action<int> OnIDPaddleChangeAction;

     
    [SerializeField] private List<ShopItemInfor> ShopItemsList;
    [SerializeField] private Animator NoCoinAnimation;
    [SerializeField] private Text CoinsText;
     private GameObject ItemTemplate;
     private GameObject g;
    // public GameObject Select;
    [SerializeField] private Transform ShopScrollView;
    private Button buyBtn;
    private List<ShopItem> _shopItems = new List<ShopItem>();



    private void Start()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("idballselected")) IDBallSelected = 0;
        //if (!PlayerPrefs.HasKey("idPaddleselected")) IDPaddleSelected = 0;
     
     
        var shopItemPrefabs = ShopScrollView.GetChild(0).GetComponent<ShopItem>();
  
        foreach (var shopItemInfor in ShopItemsList)
        {
            
            var itemSpawn = Instantiate(shopItemPrefabs, ShopScrollView);
            itemSpawn.Initialize(shopItemInfor.IDShopItem, shopItemInfor.Sprite, shopItemInfor.Price);
          
            
            _shopItems.Add(itemSpawn);
    
            
        }
        shopItemPrefabs.gameObject.SetActive(false);

        OnIDBallChangeAction += OnIDBallChange;


        SetCoinsUI();

    }

 

    private void OnIDBallChange(int idBall )
    {
        foreach (var item in _shopItems)
        {
            if (item.IDShopItem != idBall)
            {
                item.SetSelectButton();
            }
            
        }
    }
    // private void OnIDPaddleChange(int idBall )
    // {
    //     foreach (var item in _shopItems)
    //     {
    //         if (item.IDShopItem != idBall)
    //         {
    //             item.SetSelectButton();
    //         }
    //         
    //     }
    // }
  

    
     public void  OnShopItemBtnClick (int itemIndex)
     {
     
       if (Points.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Points.Instance.UseCoins();
            
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
       
            buyBtn.interactable = false;
            //buyBtn.transform.GetChild(0).GetComponent<Text>().text = "SELECT";
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
