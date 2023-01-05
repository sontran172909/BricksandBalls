using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DunnGSunn;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
    
    public int Hitpoints = 1;
    
    //public static event Action<Brick> OnBrickDestruction;
    private SpriteRenderer sr;
   
    private Vector3 lastVelocity;
    public static event Action <Brick> DescareBrick ;
    private BoxCollider2D boxCollider;
    

    private void Awake()
    {
        this.sr = this.GetComponent<SpriteRenderer>(); 
        this.boxCollider = this.GetComponent<BoxCollider2D>();
        SunEventManager.StartListening(EventID.OnStartingBallCollision, OnStartingBallCollision);
    }

    private void Start()
    {

        BallsManager.Instance.LightEffectChange += LightEffectChange;
    }

    // private void Update()
    // {
    //     if (BallsManager.Instance.IsLightEffectActive)
    //     {
    //         OnLightningBallEnable();
    //     }
    //     else
    //     {
    //         OnLightningBallDisable();
    //     }
    // }
    

    private void LightEffectChange(bool value)
    {
        if (value)
        {
            OnLightningBallEnable();
        }
        else
        {
            OnLightningBallDisable();
        }
    }
    
    private void OnLightningBallEnable()
    {
        
        this.boxCollider.isTrigger = true;
    }
    private void OnLightningBallDisable()
    {
       
        this.boxCollider.isTrigger = false;
    }

    private void OnDestroy()
    {
        SunEventManager.StopListening(EventID.OnStartingBallCollision, OnStartingBallCollision);
        BallsManager.Instance.LightEffectChange -= LightEffectChange;
        
    }
    private void OnStartingBallCollision()
    {
        var sender = (int)SunEventManager.GetSender(EventID.OnStartingBallCollision);
        if (sender == gameObject.GetInstanceID())
        {
            //Collectable newBuff = this.SpawnCollectable(true);
            Collectable newBuff1 = this.SpawnClearCollectable(true);
        }
        
    }

    public bool running = false;
    public Vector3 direction;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Ball ball = coll.gameObject.GetComponent<Ball>();
        
        ApplyCollisionLogic(ball);
        if (coll.gameObject.tag == "Ball")
        {
           
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            lastVelocity = direction * Mathf.Max(speed, 0f);
            //audioManager.instance.SetSound(0, false);
          
           // audioManager.instance.Play("Ballhit");
        }

    }
 

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.tag.Equals("Ball")) return;
        
        Ball ball = coll.gameObject.GetComponent<Ball>();
        ApplyCollisionLogic(ball);
            
    }

    private void ApplyCollisionLogic(Ball ball)
    {
        this.Hitpoints--;
        if (this.Hitpoints <= 0)
        {
            BricksManager.Instance.RemainingBricks.Remove(this);
            DescareBrick?.Invoke((this));
            OnBrickDestroy();
            Destroy(this.gameObject);
        }
        else
        {
            this.sr.sprite = BricksManager.Instance.Sprites[this.Hitpoints - 1];
        }
    }
    
    private void OnBrickDestroy()
    {
        float buffSpawnChance = UnityEngine.Random.Range(0, 1000f);
        //float DebuffSpawnChance = UnityEngine.Random.Range(0, 1000f);
        float SpawnChance3 = UnityEngine.Random.Range(0, 1000f);
        float Spawnclear = UnityEngine.Random.Range(0, 1000f);
       // bool alreadySpawned = false;

       
       
        if (buffSpawnChance <= CollectabaleManager.Instance. x3BuffChance && BricksManager.Instance.CanSpawnBuff)
        {
            // alreadySpawned = true;
            Collectable newBuff = this.SpawnCollectable(true);
        }
        if (Spawnclear <= CollectabaleManager.Instance. buffclear )
        {

            Collectable newBuff1 = this.SpawnClearCollectable(true);
        }
        if (SpawnChance3 <= CollectabaleManager.Instance. PlusChance3 )
        {   
        
            Collectable newBuff2 = this.SpawnPlusCollectable(true);
        }
        
        // if (DebuffSpawnChance <= CollectabaleManager.Instance.DebuffChance && !alreadySpawned)
        // {
        //     Collectable newDebuff = this.SpawnCollectable(false);
        // }
    }

    private Collectable SpawnCollectable(bool isBuff)
    {
        List<Collectable> collection = null;
        
        if (isBuff)
        {
            collection = CollectabaleManager.Instance.AvailableBuffs;
            
        }
        int buffIndex = UnityEngine.Random.Range(0, collection.Count);
      
        Collectable prefab = collection[buffIndex];
        Collectable newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity) as Collectable;
        newCollectable.gameObject.transform.SetParent(GameManager.Instance.objParent);
        return newCollectable;
        
    }
    
    private Collectable SpawnPlusCollectable(bool isBuffPlus)
    {
        
        List<Collectable> collection = null;
        
        if (isBuffPlus)
        {
            collection = CollectabaleManager.Instance.PlusChance;
            
        }
        int buffIndex = UnityEngine.Random.Range(0, collection.Count);
            
        
        Collectable prefab = collection[buffIndex];
        Collectable newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity) as Collectable;
        newCollectable.gameObject.transform.SetParent(GameManager.Instance.objParent);
        return newCollectable;
        
    }
    private Collectable SpawnClearCollectable(bool isBuffClear)
    {
        List<Collectable> collection = null;

     

        if (isBuffClear)
        {
            collection = CollectabaleManager.Instance.ClearChance;
            
        }
        int buffIndex = UnityEngine.Random.Range(0, collection.Count);
    
        Collectable prefab = collection[buffIndex];
        Collectable newCollectable = Instantiate(prefab, this.transform.position, Quaternion.identity) as Collectable;
        newCollectable.gameObject.transform.SetParent(GameManager.Instance.objParent);
        return newCollectable;
        
    }
    

    private void OnDisable()
    {
        Ball.OnLightningBallEnable -= OnLightningBallEnable;
        Ball.OnLightningBallDisable -= OnLightningBallDisable;
    }
    
}
