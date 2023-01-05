using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public abstract class Collectable : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
      
        if (collision.CompareTag("Paddle"))
        {
            //audioManager.instance.PlaySound(audioManager.instance.ItemUsed, 1f);
            //audioManager.instance.Play("item");
            audioManager.instance.SetSound(1, false);
            this.ApplyEffect();
            
        }

        if (collision.CompareTag("Paddle") || collision.CompareTag("DeathWall") )
        {

            if(transform.GetComponent<MultiBall>() != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetComponent<CircleCollider2D>().enabled = false;
                StartCoroutine(Des((this.gameObject)));
            }
            else
            {
                Destroy(this.gameObject);   
            }

        }

       
      
    }

    IEnumerator Des(GameObject g)
    {
        yield return new WaitForSeconds(.5f);
        Destroy(g);
    }
    
    protected abstract void ApplyEffect();

   
}
