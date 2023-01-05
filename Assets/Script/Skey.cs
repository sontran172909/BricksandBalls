using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ball"))
        {
            this.Apply();
        }
        if (collision.CompareTag("Ball") || collision.CompareTag("DeathWall"))
        {
            Destroy(this.gameObject);
        }

     
    }
    public void Apply()
    {
        GameManager.Instance.SKey();
    }

   
}
