using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiBall2 : Collectable
{
   
    protected override void ApplyEffect()
    {
        BallsManager.Instance.SBalls();
    }


    
}
