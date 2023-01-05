using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectabaleManager : MonoBehaviour
{
    #region Singleton

    private static CollectabaleManager _instance;

    public static CollectabaleManager Instance => _instance;



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

    public List<Collectable> AvailableBuffs;

    public List<Collectable> PlusChance;
    public List<Collectable> ClearChance;

    [Range(0, 1000)]
    public float x3BuffChance;

    [Range(0, 1000)]
    public float PlusChance3;
    
    [Range(0, 1000)] public float buffclear;

    // [Range(0, 1000)]
    // public float DebuffChance;
}

