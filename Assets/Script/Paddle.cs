using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DunnGSunn;


public class Paddle : MonoBehaviour
{
    #region Singleton

    public static Paddle _instance;
    public static Paddle Instance => _instance;

    private void Awake()
    {
        this.sr = GetComponentInChildren<SpriteRenderer>();
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        // if (PlayerPrefs.GetInt("CheckSkillPaddleStart") == 0)
        // {
        //     skillPaddlestart = false;
        // }
        // else
        // {
        //     skillPaddlestart = true;
        // }
        //
        // if (skillPaddlestart == false)
        // {
        //     PlayerPrefs.SetInt("idPaddleselected", 12);
        //     skillPaddlestart = true;
        //     PlayerPrefs.SetInt("CheckSkillPaddleStart",(skillPaddlestart ? 1 : 0));
        // }
    }

    #endregion

    [Serializable]
    public class PaddleRenderer
    {
        public int idPaddle;
        public int chessID;
        public Sprite paddleSprite;
    }
    private Camera mainCamera;
    private float paddleInitialY;
    private SpriteRenderer sr;
    private object position;
    
    public List<PaddleRenderer> renderers;
    public SpriteRenderer renderer;
    
    private int idPaddle;
   // public bool skillPaddlestart { get; set; }
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        paddleInitialY = this.transform.position.y;
        //sr = GetComponent<SpriteRenderer>();
        OldPos = this.transform.position;
        //this.sr = GetComponentInChildren<SpriteRenderer>();
       
        GameControl._instance._isPlay = true;
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("idPaddle") == 2)
        {
            PlayerPrefs.SetInt("idPaddleselected", 2);
        }
        idPaddle = PlayerPrefs.GetInt("idPaddleselected");
        this.sr.enabled = true;
        renderer.sprite = renderers.Find(o => o.idPaddle == idPaddle).paddleSprite;
        
    }
   

    Vector2 FirstPos;
    bool Clicked;
    public Vector2 OldPos;
    Vector2 nPos;
    Vector2 diffDistance, currentPos;
    Vector2 GetInputMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            PaddleMovement();
        }

    }
    private void PaddleMovement()
    {
      
        if (Input.touchCount == 1)
        {
            
            if (!GameControl._instance._isPlay) return;
        
            if (Input.GetMouseButtonDown(0))
            {
                Clicked = true;
                FirstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            }
            else if (Input.GetMouseButton(0))
            {
                Clicked = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Clicked = false;
                OldPos = this.transform.localPosition;
            }

            if (Clicked)
            {
                nPos = GetInputMousePos();

                diffDistance = nPos - FirstPos;
                currentPos = OldPos + diffDistance;
                if (currentPos.x > 3.38f)
                {
                    FirstPos.x = nPos.x;
                    OldPos.x = 3.38f;
                    currentPos.x = 3.38f;
                }
                else if (currentPos.x < -3.38f)
                {
                    FirstPos.x = nPos.x;
                    OldPos.x = -3.38f;
                    currentPos.x = -3.38f;
                }

                this.transform.localPosition = new Vector3(currentPos.x, this.transform.position.y, 0);
            }

        }

        if (Input.touchCount == 2)
        {
            Clicked = false;
        }

    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            ballRb.velocity = Vector2.zero;
            float difference = paddleCenter.x - hitPoint.x;
            if (hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), BallsManager.Instance.initialBallSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallsManager.Instance.initialBallSpeed));
            }
            //audioManager.instance.PlaySound(audioManager.instance.BallHit, 1f);
        }
    }
}

public class GameControl
{
    public class _instance
    {
        public static bool _isPlay;
    }
}