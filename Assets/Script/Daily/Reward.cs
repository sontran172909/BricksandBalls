/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using System;

namespace NiobiumStudios
{
    /**
    * The class representation of the Reward
    **/
    public enum RewardType
    {
        Ball,
        Paddle,
        Coin,
        x3,
        Plus3
    }
    [Serializable]
    public class Reward
    {
        public string unit;
        public int reward;
        public Sprite sprite;
        public int IdBallReward;
        public int idPaddleReward;
        public int coinReward;
        public int x3Reward;
        public int Plus3Reward;
    }
}