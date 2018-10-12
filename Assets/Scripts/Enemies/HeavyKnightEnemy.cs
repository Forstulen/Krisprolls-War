using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class HeavyKnightEnemy : Enemy
    {

        const string _NAME = "Heavy Knight";
        const int _LIFE = 100;
        const float _ARMOR = 50.0f;
        const int _RESISTANCE = 25;
        const float _SPEED = 1.25f;
        const int _REWARD = 40;

        public HeavyKnightEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.HEAVY_KNIGHT_ENEMY;
        }
    }
}
