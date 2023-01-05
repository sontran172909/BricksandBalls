using System;
using UnityEngine;
using UnityEngine.UI;

namespace DunnGSunn
{
    public class TestStatic : MonoBehaviour
    {
       
        public static TestStatic Instance { get; set; }
        
        public int CurrentLevelPlaying { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}