   using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBuff : MonoBehaviour
{

   private void FixedUpdate()
   {
      transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f);
   }
   
}