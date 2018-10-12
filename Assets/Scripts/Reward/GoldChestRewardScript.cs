using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class GoldChestRewardScript : RewardScript
    {
        private void Start()
        {
            Type = RewardType.CHEST;
            ExpirationTime = 1.5f;
        }
    }
}
