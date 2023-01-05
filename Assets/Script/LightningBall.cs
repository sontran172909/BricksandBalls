using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class LightningBall : Collectable
{
    protected override void ApplyEffect()
    {
        BallsManager.Instance.IsLightEffectActive = true;
        foreach (var ball in BallsManager.Instance.Balls)
        {
            ball.StartLightingBall();
        }
    }

    
}
