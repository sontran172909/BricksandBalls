using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Chest
{
    public enum Type
    {
        ball,
        paddle,
        coins
    }
    [System.Serializable]
    public class listChest
    {
        
        public UnityEngine.Sprite Icon ;
        public  string Label ;
        public Type type;
        public int BallID;
        public int PaddleID;
        public int CoinReward;

    }
   
}

