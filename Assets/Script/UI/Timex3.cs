using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class Timex3 : MonoBehaviour
{
   
   [SerializeField] private Image TimeUI;

   public GameObject XButton;
    public int Duration;
    private int remainingDuration;
   
    private void OnEnable()
    {
        Being(Duration); 
       
    }
    

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(updatetime());
        
    }
    
    private IEnumerator updatetime()
    {
        while (remainingDuration >= 0)
        {
            TimeUI.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
            
        }

        XButton.GetComponent<Button>().enabled = true;
        //XButton.SetActive(true);
        gameObject.SetActive(false);
      
    }
    
}
