using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class XButton : Collectable
{
  
    public Button thisButton;

    public bool IsButtonStarted { get; set; }
    public GameObject Timex3;
    [SerializeField] private Text txtNumber;
    public int counter;

    private void Reset()
    {
        thisButton = GetComponent<Button>();
        Timex3.SetActive(true);
    }

    private void Start()
    {
        if (thisButton == null)
        {
            thisButton = GetComponent<Button>();
        }
        thisButton.onClick.AddListener(OnButtonClick);
        thisButton.enabled = true;
        counter = PlayerPrefs.GetInt("X3");
        txtNumber.text = counter.ToString();
    }

    private void Update()
    {
        txtNumber.text = PlayerPrefs.GetInt("X3").ToString();
        
    }
    protected override void ApplyEffect()
    {
  
        Coroutine t = StartCoroutine(Create());
      
    }

   

    IEnumerator Create()
    {
       
        if (BallsManager.Instance.Balls.Count >= 10 )
        {
            int ball1 = BallsManager.Instance.Balls.Count / 10;
          
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < ball1; j++)
                {
                    BallsManager.Instance.SpawnBalls(BallsManager.Instance.Balls[j].transform);               
                }
                //Debug.Log("VAR1");
                yield return new WaitForSeconds(.1f);
            }
            yield break;
        }
        else
        {
            foreach (Ball ball in BallsManager.Instance.Balls.ToList())
            {
                            
                BallsManager.Instance.SpawnBalls(ball.transform);
                            
            }
                    
            //Debug.Log("VAR2");
            yield break;
        }  
    }
    
    public void OnButtonClick()
    {
        
        if (counter == 0)
        {
            thisButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            counter--;
            PlayerPrefs.SetInt("countItems", PlayerPrefs.GetInt("countItems") + 1);
            Coroutine t = StartCoroutine(Create());
            audioManager.instance.SetSound(3, false);
            Timex3.SetActive(true);
            PlayerPrefs.SetInt("X3", counter);
        }
        txtNumber.text = counter.ToString();
    }

}
