using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace UI.Chest
{
    public class Chest : MonoBehaviour
    {
        public static Chest instance;
        //public int chessID;
       
        //public RandomList<Transform> listchest;
        //public Transform itemHolder;
        public GameObject Chestroom;
         public GameObject victory;
        //
        // [Space] [Header("Picker wheel pieces :")]
        // public listChest[] listchest;
        public Sprite[] rdicon ;
        //public Image oldimages;
        //private Sprite sprite;
        public Button thisbutton;
        public GameObject icon;
        public Image icons;
        private int rd;
        public Button[] buttons;
        private SkeletonGraphic _skeletonGraphic;
        public GameObject oldimages;

        private void Awake()
        {
        //images = GetComponent<SpriteRenderer>(images);
        _skeletonGraphic = transform.GetChild(0).GetComponent<SkeletonGraphic>();
        }
        public void onclick()
        {
            _skeletonGraphic.AnimationState.SetAnimation(0, "1. shake" , false);
       
             rd = UnityEngine.Random.Range(0, rdicon.Length);
             thisbutton.GetComponent<Button>().enabled = false;
            //Debug.Log("var1");
            //oldimages.GetComponent<Image>().enabled = false;
              
            if(shg != null) StopCoroutine(shg);
            shg = StartCoroutine(ShowGift());
          
            icons.sprite = rdicon[rd];
            PlayerPrefs.SetInt("idballselected",rd+1);
            //PlayerPrefs.SetInt("idPaddleselected",rd+1);
                for (int i = 0; i < 8; i++)
            {
                
                buttons[i].enabled = false; 
               // Debug.Log(buttons);
            }
               
        }
        private Coroutine shg;
        IEnumerator ShowGift()
        {
            yield return new WaitForSeconds(0.75f);
            _skeletonGraphic.AnimationState.AddAnimation(0, "2. open" , false, 0);
            yield return new WaitForSeconds(0.5f);
            oldimages.SetActive(false);
            // fxRuong.Play();
            icon.SetActive(true);
          
        }
       
         public void Skip()
         {
             Chestroom.SetActive(false);
             Time.timeScale = 1f;
             victory.SetActive(true);

         }

        // public int IDChest()
        // {
        //     get => PlayerPrefs.GetInt("idchest");
        //
        //     int value = 0;
        //     set => PlayerPrefs.SetInt("idchest", value: value);
        // }
        //
        // private void Start()
        // {
        //     CheckID();
        // }
        //
        //
        // private void CheckID()
        // {
        //     instance = this;
        //     if (!PlayerPrefs.HasKey("idchest")) IDChest = 0;
        // }
    }

}
