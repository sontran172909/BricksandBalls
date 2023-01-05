using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiLightning : Collectable
{
    protected override void ApplyEffect()
    {
        foreach (Ball ball in BallsManager.Instance.Balls.ToList())
        {
            BallsManager.Instance.SpawnLightningBalls(ball.gameObject.transform.position, 2, ball.isLightningBall);
           
        }
    }

  
}
