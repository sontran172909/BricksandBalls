using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> uii = new List<GameObject>();
    public float fadetime = 1.5f;

    public static Action<int> ActionChess;
    //public Text coinText;
    public void Start()
    {
        StartCoroutine("ItemsAnimation");
        StartCoroutine("abc");
        
        //Debug.Log("VAR");
    }

    // public void StartSomething()
    // {
    //     
    //     ActionChess = value =>
    //     {
    //         foreach (var item in items)
    //         {
    //             var chestScript = item.GetComponent<Chest>();
    //             if (value != chestScript.chessID)
    //             {
    //                 item.GetComponent<Button>().interactable = false;
    //             }
    //         }
    //       
    //    
    //     };
    // }
    //
    private IEnumerator ItemsAnimation()
    {
       
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
           
        }
         
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadetime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0f);
            
        }
        //audioManager.instance.PlaySound(audioManager.instance.theme, 1f , true);
        
    }
    private IEnumerator abc()
    {
        foreach (var ua in uii)
        {
            ua.transform.localScale = Vector3.zero;
        }
    
        foreach (var ua in uii)
        {
            ua.transform.DOScale(1f, fadetime).SetEase(Ease.OutBounce);
            ua.transform.DOMove(new Vector3(30, 0, 0), 2).From();
            yield return new WaitForSeconds(0.5f);
        }
       // audioManager.instance.PlaySound(audioManager.instance.theme, 1f , true);
    }

    
}
