using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using DunnGSunn;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.VFX;
using Unity.Entities;
using Random = UnityEngine.Random;


[Serializable]
public class BallRenderer
{
    public int idBall;
    public int chessID;
    public Sprite ballSprite;
}

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private LineRenderer line;
    private Vector3 lastVelocity;
    
    public int speed = 280;
    public static event Action<Ball> OnBallDeath;
    //public GameObject ChangeColor;
    
    public SpriteRenderer renderer;
    public List<BallRenderer> renderers;
    private int idBall;
  
    public bool isStartingBall;
    public bool isLightningBall;
    private SpriteRenderer sr;
    public ParticleSystem LightningBallEffect;
    public Vector3 direction;
    public bool running = false;
    
    //public float LightningBallDuration = 7;

    
    //public LayerMask _wallayer;
    public static event Action OnLightningBallEnable;
    public static event Action OnLightningBallDisable;

    public bool skillstart { get; set; }
    private Coroutine _lightingEffectCoroutine;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponentInChildren<LineRenderer>();
        this.sr = GetComponentInChildren<SpriteRenderer>();
   
    }
    

    private Vector3 movement;

    private void Start()
    {
        movement = new Vector3(0, 0, 200);
    }

    private void OnEnable()
    {
      

        if (PlayerPrefs.GetInt("idBall1") == 1)
        {
           PlayerPrefs.SetInt("idballselected", 1);
        }
        
        if (PlayerPrefs.GetInt("idBall9")== 9)
        {
            PlayerPrefs.SetInt("idballselected", 9);
        }
        
        
        idBall = PlayerPrefs.GetInt("idballselected");
        this.sr.enabled = true;
        renderer.sprite = renderers.Find(o => o.idBall == idBall).ballSprite;
        
        if (BallsManager.Instance.IsLightEffectActive)
        {
            LightningBallEffect.gameObject.SetActive(true);
            LightningBallEffect.Play(true);
        }
        else
        {
            LightningBallEffect.Stop(true);
            LightningBallEffect.gameObject.SetActive(false);
        }

        isLightningBall = BallsManager.Instance.IsLightEffectActive;
    }
    
    public void  ResetBall()
    {
        
        this.isLightningBall = false;
        LightningBallEffect.Stop(true);
       //StopLightningBall();    
      
    }
   
    // private void Update()
    // {
    //   
    //     idBall = PlayerPrefs.GetInt("idballselected");
    //     this.sr.enabled = true;
    //     renderer.sprite = renderers.Find(o => o.idBall == idBall).ballSprite;
    //    
    // }
   
  

    private void FixedUpdate()
    {
        transform.Rotate(movement );
        lastVelocity = rb.velocity;
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        // if (!running)
        // {
        //     StartCoroutine(changeDirection());
        //   
        // }
        // audioManager.instance.SetSound(0, false);
        audioManager.instance.collisionBall();
        
        transform.Rotate(movement);

        
        // var speed = lastVelocity.magnitude;



        var randomVec2 = new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f));
       // var directionValue = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal + randomVec2);
        var directionValue = Vector2.Reflect(lastVelocity.normalized,  randomVec2);
        
        // var direction = new Vector3( UnityEngine.Random.Range(-100f, 100f),UnityEngine.Random.Range(-100f, 100f), 0);
        // direction = coll.contacts[0].normal;
        // direction = Quaternion.AngleAxis(UnityEngine.Random.Range(-100f, 100f), Vector3.forward) * direction;
        // transform.rotation = Quaternion.LookRotation(movement);
        lastVelocity = directionValue * Mathf.Max(speed, 0f);
        
      //  rb.AddForce(coll.contacts[0].normal + new Vector2(Random.Range(-2, 2), Random.Range(-2, 2)));
        rb.AddForce( new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)));
        if (isStartingBall)
        
        {
            isStartingBall = false;
            SunEventManager.EmitEvent(EventID.OnStartingBallCollision, sender: coll.gameObject.GetInstanceID());
        }
        
        
      
    }

    // IEnumerator changeDirection()
    // {
    //     running = true;
    //     yield return new WaitForSeconds(0.05f);
    //     // direction.x = UnityEngine.Random.Range(-5, 5);
    //     // direction.y = UnityEngine.Random.Range(-5, 5);
    //
    //     var right = transform.right;
    //     right = new Vector3(right.x + UnityEngine.Random.Range(-100, 100), right.y + UnityEngine.Random.Range(-100, 100),
    //         right.z);
    //     transform.right = right;
    //     
    //     lastVelocity = direction * Mathf.Max(speed, 0f);
    //     Debug.Log("VAR");
    //     running = false;
    //
    // }


  
    public void Die()
    {
        
        OnBallDeath?.Invoke(this);
        
        rb.velocity = Vector2.zero;
        StopLightningBall();
        // if (_lightingEffectCoroutine != null)
        // {
        //     StopCoroutine(_lightingEffectCoroutine);
        //     StopLightningBall();
        // }
        Pooler.Instance.AddToPool("Ball", gameObject);
   
        audioManager.instance.SetSound(2, false);
    }

 
    public void DeactiveLine()
    {
        line.enabled = false;
    }

    public void StartLightingBall()
    {
        
        this.isLightningBall = true;
        // this.sr.enabled = false;
        if (!LightningBallEffect.isPlaying)
        {
            LightningBallEffect.gameObject.SetActive(true);
            LightningBallEffect.Play(true);
        }
        
     
        // _lightingEffectCoroutine = StartCoroutine(StopLightningBallAfterTime(this.LightningBallDuration));
        OnLightningBallEnable?.Invoke();
   
    }

    private IEnumerator StopLightningBallAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StopLightningBall();
    }

    public void StopLightningBall()
    {
        this.isLightningBall = false;
        // this.sr.enabled = true; 
        LightningBallEffect.gameObject.SetActive(false);
        OnLightningBallDisable?.Invoke();
     
    }

   

   
}
