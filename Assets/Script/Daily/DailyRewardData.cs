using UnityEngine;

public enum RewardType
    {
        Coin,
        Ball,
        Buff,
        Paddle,
        Mix
    }
    
    [CreateAssetMenu(fileName = "Daily Reward Data", menuName = "Daily Reward", order = 0)]
    public class DailyRewardData : ScriptableObject
    {
        public int dayIndex;
        public RewardType rewardType;
        public int rewardCoin;
        public int rewardBallID;
        
    }