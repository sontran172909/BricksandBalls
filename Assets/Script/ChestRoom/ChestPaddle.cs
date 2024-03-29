using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ChestPaddle : MonoBehaviour
{
    public GameObject Chestroom;
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
    // public ParticleSystem fxruong;
    // public GameObject moruong;

    private void Awake()
    {
        //images = GetComponent<SpriteRenderer>(images);
        _skeletonGraphic = transform.GetChild(0).GetComponent<SkeletonGraphic>();
    }
    public void onclick()
    {
        _skeletonGraphic.AnimationState.SetAnimation(0, "1. shake" , false);
       //_skeletonGraphic.AnimationState.SetAnimation(0, "2. open" , false);
        rd = UnityEngine.Random.Range(0, rdicon.Length);
        thisbutton.GetComponent<Button>().enabled = false;
        //Debug.Log("var1");
       // oldimages.GetComponent<Image>().enabled = false;
       
       if(shg != null) StopCoroutine(shg);
       shg = StartCoroutine(ShowGift());
       
        
        icons.sprite = rdicon[rd];
        PlayerPrefs.SetInt("idPaddleselected",rd+1);
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
        // moruong.SetActive(true);
        // fxruong.Play();
        icon.SetActive(true);

    }
        
 
}
