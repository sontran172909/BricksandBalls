using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager2 : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    //public List<GameObject> uii = new List<GameObject>();
    public float fadetime = 0.5f;
    public void Start()
    {
        StartCoroutine("ItemsAnimation");
        // StartCoroutine("abc");
    }
 
    private IEnumerator ItemsAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
           
        }
         
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadetime).SetEase(Ease.OutBounce);
            item.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.WorldAxisAdd);
            yield return new WaitForSeconds(0.25f);
             
        }
        //audioManager.instance.PlaySound(audioManager.instance.theme, 1f , true);
    }
}
