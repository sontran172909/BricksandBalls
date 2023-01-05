// using System;
// using System.Text;
// using DunnGSunn;
// using UnityEngine;
// using UnityEngine.UI;
// using Spine.Unity;
// using UnityEngine.PlayerLoop;
// using UnityEngine.SceneManagement;
//
// public class Timer : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public Slider timerSlider;
//     private float gameTime = 100;
//     private bool stopTimer;
//
//     public Image[] Star;
//     public bool IsGameStarted { get; set; }
//     public Sprite emptyStar;
//
//     public GameObject gameOverScreen;
//     public GameObject gameVictory;
//
//
//     private Spine.AnimationState _animation;
//     private bool _stopShowing;
//         
//     // private void Awake()
//     // {
//     //     ske = GetComponent<SkeletonGraphic>();
//     // }
//
//     void Start()
//     {
//         ResetTimer();
//         stopTimer = false;
//         timerSlider.maxValue = gameTime;
//         timerSlider.value = gameTime;
//
//         //_animation = ske.AnimationState;
//      
//         _stopShowing = false;
//         
//         gameVictory.SetActive(false);
//     }
//
//     void FixedUpdate()
//     {
//         gameTime -= Time.deltaTime;
//         int minutes = Mathf.FloorToInt(gameTime / 60);
//         int seconds = Mathf.FloorToInt(gameTime - minutes * 60f);
//
//         // if (gameTime <= 60 && gameTime > 40)
//         // {
//         //     Star[0].sprite = emptyStar;
//         // }
//         // else if (gameTime <= 40 && gameTime > 20)
//         // {
//         //     Star[1].sprite = emptyStar;
//         // }
//         // else if (gameTime <= 20)
//         // {
//         //     Star[2].sprite = emptyStar;
//         // }
//
//         if (!stopTimer)
//         {
//             timerSlider.value = gameTime;
//         }
//
//         if (gameTime <= 0 && !_stopShowing)
//         {
//             _stopShowing = true;
//             stopTimer = true;
//             gameTime = 0;
//             gameOverScreen.SetActive(true);
//             ResetTimer();
//             BallsManager.Instance.ResetBalls();
//             //BallsManager.Instance.InitBall();
//             IsGameStarted = false;
//
//         }
//     }
//     private void LateUpdate()
//     {
//         if (BricksManager.Instance.RemainingBricks.Count <= 0 && !_stopShowing)
//         { 
//             BallsManager.Instance.ResetBalls();
//             GameManager.Instance.IsGameStarted = false;
//             ResetTimer();
//             stopTimer = true;
//             gameVictory.SetActive(true);
//             _stopShowing = true;
//        
//         }
//     }
//
//     public void ResetTimer()
//     {
//         stopTimer = true;
//         timerSlider.maxValue = gameTime;
//         timerSlider.value = gameTime;
//     }
// }