using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class HeavyEnemy : Enemy
    {

        const string _NAME = "Heavy Enemy";
        const int _LIFE = 500;
        const float _ARMOR = 50.0f;
        const int _RESISTANCE = 40;
        const float _SPEED = 0.75f;
        const int _REWARD = 50;

        public HeavyEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.HEAVY_ENEMY;
        }
    }
}
