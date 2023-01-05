using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class MultiBall : Collectable
{
    protected override void ApplyEffect()
    {
  
        Coroutine t = StartCoroutine(Create());
      
    }

   

    IEnumerator Create()
    {
       
        if (BallsManager.Instance.Balls.Count >= 10 )
        {
            int ball1 = BallsManager.Instance.Balls.Count / 10;
            // Debug.Log("ballllllllllllll1 : " + ball1);
           // Debug.Log("run here");
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
    
}

