using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using DunnGSunn;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallsManager : MonoBehaviour
{
    #region Singleton

    private static BallsManager _instance;
    public static BallsManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    [SerializeField] private Ball initialBall;

    private Rigidbody2D initialBallRb;

    // public float Force = 100;
    public float initialBallSpeed = 300f;
    public float timeLightingEffect = 8f;
    public List<Ball> Balls { get; set; }
    [SerializeField] private int count = 3;

    private Vector3 lastVelocity;
    private RaycastHit2D hit;

    private Scene sceneMain;


    private PhysicsScene2D sceneMainPhysics;

    private Scene scenePrediction;

    public int BallsCount = 350;
    [SerializeField] private Text BallCount;
    private PhysicsScene2D scenePredictionPhysics;


    // [SerializeField] private Text txtNumber;
    //public int counter = 3;
    private Vector2 defaultBallPosition;

    private Vector2 endPosition;
    private Vector2 startPosition;
    

    public GameObject ballPrecdiction;
    private static LineRenderer line;

    public Action<bool> LightEffectChange;

    private bool isLightEffectActive;
    public bool IsLightEffectActive
    {
        get => isLightEffectActive;
        set
        {
            isLightEffectActive = value;
            LightEffectChange?.Invoke(value);
        }
    }

    private float _currentTimeLightingEffect;

    private void Start()
    {
        
       InitBall();
       sceneMain = SceneManager.CreateScene("MainScene");
        sceneMainPhysics = sceneMain.GetPhysicsScene2D();
        CreateSceneParameters sceneParameters = new CreateSceneParameters(LocalPhysicsMode.Physics2D);
        scenePrediction = SceneManager.CreateScene("PredictionScene", sceneParameters);
        scenePredictionPhysics = scenePrediction.GetPhysicsScene2D();
        BallsCount += PlayerPrefs.GetInt("BallCount");
        BallCount.text = BallsCount.ToString();
        
        //
        IsLightEffectActive = false;
        _currentTimeLightingEffect = timeLightingEffect;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            CheckingInput();
        }
       
            CheckingEffect();
    }
    
    //
    private void CheckingEffect()
    {
        if (IsLightEffectActive)
        {
            _currentTimeLightingEffect -= Time.deltaTime;
            if (_currentTimeLightingEffect <= 0)
            {
                IsLightEffectActive = false;
                _currentTimeLightingEffect = timeLightingEffect;
                DeactiveAllEffectInBalls();
            }
        }
    }

    private void DeactiveAllEffectInBalls()
    {
        //Debug.Log("VAR");
        foreach (var ball in Balls)
        {
            ball.StopLightningBall();
        }
    }

    //
    private void CheckingInput()
    {
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + .20f, 0);
            initialBall.transform.position = ballPosition;
            Vector2 startPosition = new Vector3(Paddle.Instance.gameObject.transform.position.x,
                Paddle.Instance.gameObject.transform.position.y + .30f, 0);

            if (Input.GetMouseButtonDown(0))
            {
                startPosition = getMousePosition();
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 dragPosition = getMousePosition();

                Vector2 power = (startPosition - dragPosition).normalized;


                GameObject newBallPrediction = GameObject.Instantiate(ballPrecdiction);
                SceneManager.MoveGameObjectToScene(newBallPrediction, scenePrediction);
                newBallPrediction.transform.position = transform.position;
                newBallPrediction.GetComponent<Rigidbody2D>().AddForce(power * initialBallSpeed);

                LineRenderer line = GetComponent<LineRenderer>();
                newBallPrediction.transform.position = new Vector3(initialBall.transform.position.x,
                    newBallPrediction.transform.position.y);

                line.positionCount = 50;

                for (int i = 0; i < 50; i++)
                {
                    scenePredictionPhysics.Simulate(Time.fixedDeltaTime);

                    line.SetPosition(i,
                        new Vector3(newBallPrediction.transform.position.x, newBallPrediction.transform.position.y, 0));
                }

                Destroy(newBallPrediction);
            }

            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<LineRenderer>().positionCount = 0;
                endPosition = getMousePosition();

                Vector2 power = (startPosition - endPosition).normalized;
                initialBallRb.isKinematic = false;
                initialBallRb.AddForce(power * initialBallSpeed);
                initialBall.DeactiveLine();
                //initialBall.transform.right = power;
                GameManager.Instance.IsGameStarted = true;
            }
    }

    private void FixedUpdate()
    {
        if (!sceneMainPhysics.IsValid()) return;
       

        //sceneMainPhysics.Simulate(Time.fixedDeltaTime);
    }

    private Vector2 getMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static void DeactiveLine()
    {
        line.enabled = false;
    }

    public void ResetBalls()
    {
        foreach (var t in Balls)
        {
            t.ResetBall();
            t.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Pooler.Instance.AddToPool("Ball", t.gameObject);
            
        }

        for (int i = 0; i < GameManager.Instance.objParent.childCount; i++)
        {
            Destroy(GameManager.Instance.objParent.GetChild(i).gameObject);
        }
    }


    public void InitBall()
    {
        IsLightEffectActive = false;
        _currentTimeLightingEffect = timeLightingEffect;
        
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y + .45f, 0);
        initialBall = Pooler.Instance.SpawnFromPool("Ball", startingPosition, quaternion.identity).GetComponent<Ball>();
        initialBall.isStartingBall = true;

        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>();
        Balls.Add(initialBall);
    }

    public void SpawnBalls(Transform ballTrans)
    {
        for (int i = 0; i < count; i++)
        {
            if (Balls.Count >= BallsCount)
            {
              
                return;
            }
            
            var spawnedBall = Pooler.Instance.SpawnFromPool("Ball", ballTrans.position, quaternion.identity)
                .GetComponent<Ball>();
            spawnedBall.isStartingBall = false;

            Rigidbody2D spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
            if (i == 0)
            {
                spawnedBallRb.velocity = new Vector2(-1, 1) * 6f;
            }
            else if (i == 1)
            {
                spawnedBallRb.velocity = new Vector2(0, 1) * 6f;
            }
            else if (i == 2)
            {
                spawnedBallRb.velocity = new Vector2(1, 1) * 6f;
            }
          

            this.Balls.Add(spawnedBall);
        }
    }

    public void SBalls()
    {
        for (int i = 0; i < count; i++)
        {
            if (Balls.Count >= BallsCount)
            {
                //Debug.Log("Max balls");
                return;
            }

            Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
            Ball sball = Pooler.Instance.SpawnFromPool("Ball",
                    new Vector3(paddlePosition.x, paddlePosition.y + .25f, 0), quaternion.identity)
                .GetComponent<Ball>();
            sball.isStartingBall = false;
            if (sball == null)
            {
                break;
            }

            Rigidbody2D spawnedBallRb = sball.GetComponent<Rigidbody2D>();

            if (i == 0)
            {
                spawnedBallRb.velocity = new Vector2(-1, 1) * 6f;
            }
            else if (i == 1)
            {
                spawnedBallRb.velocity = new Vector2(0, 1) * 6f;
            }
            else if (i == 2)
            {
                spawnedBallRb.velocity = new Vector2(1, 1) * 6f;
            }


            this.Balls.Add(sball);
        }
    }


    public void SpawnLightningBalls(Vector3 transformPosition, int count, bool isLightningBall)
    {
        for (int j = 0; j < count; j++)
        {
            var spawnBall = Pooler.Instance.SpawnFromPool("Ball", transformPosition, quaternion.identity)
                .GetComponent<Ball>();
            spawnBall.isStartingBall = false;
            if (isLightningBall)
            {
                spawnBall.StartLightingBall();
            }

            Rigidbody2D spawnBallRb = spawnBall.GetComponent<Rigidbody2D>();
            spawnBall.isStartingBall = false;
            // spawnBallRb.isKinematic = false;
            // spawnBallRb.AddForce(new Vector2(0, initialBallSpeed));
            this.Balls.Add(spawnBall);
        }
    }
}