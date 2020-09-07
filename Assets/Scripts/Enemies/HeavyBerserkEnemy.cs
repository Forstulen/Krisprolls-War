using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class HeavyBerserkEnemy : Enemy
    {

        const string _NAME = "Heavy Berserk Enemy";
        const int _LIFE = 500;
        const float _ARMOR = 0.0f;
        const int _RESISTANCE = 40;
        const float _SPEED = 1.25f;
        const int _REWARD = 30;

        public HeavyBerserkEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.HEAVY_BERSERK_ENEMY;
        }
    }
}
