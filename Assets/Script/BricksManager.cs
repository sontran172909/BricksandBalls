using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class BricksManager : MonoBehaviour
{
    #region Singleton

    private static BricksManager _instance;
    public static BricksManager Instance => _instance;

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
    public Sprite[] Sprites;
    public List<Brick> RemainingBricks { get; set; } = new List<Brick>();
    public float delayTimer = 1.2f;
    private float lastTimeSpawn = 0f;
 

    public bool CanSpawnBuff
    {
        
        get
        {
            var result = Time.unscaledTime > lastTimeSpawn + delayTimer;
            if (result) lastTimeSpawn = Time.unscaledTime;
          //  Debug.Log("VAR11");
            return result;
        }
    }
    
    
    private void Start()
    {
        var bricks = GameObject.FindObjectsOfType<Brick>();
        foreach (var brick in bricks)
        {
            RemainingBricks.Add(brick);
        }
        Brick.DescareBrick += brick =>
        {
            RemainingBricks.Remove(brick);
        };
    }
    
 
}