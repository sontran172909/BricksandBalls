using UnityEngine ;
using UnityEngine.UIElements;
using UnityEngine.UI;

namespace EasyUI.PickerWheelUI {
    public enum RewardType
    {
        Ball1,
        Ball9,
        Paddle,
        Coin,
        x3,
        Plus3
    }
    
    [System.Serializable]
    public class WheelPiece {
      
        public Sprite Icon ;
        public string Label ;
        public RewardType type;
        public int IdBallReward;
        public int idPaddleReward;
        public int coinReward;
        public int x3Reward;
        public int Plus3Reward;
        public int idimages;

        // [Tooltip ("Reward amount")] public int Amount ;

        [Tooltip ("Probability in %")] 
        [Range (0f, 100f)] 
        public float Chance = 100f ;

        [HideInInspector] public int Index ;
        [HideInInspector] public double _weight = 0f ;
       

        private void start()
        {
           
        }
    }
}