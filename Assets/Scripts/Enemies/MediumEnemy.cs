using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class MediumEnemy : Enemy
    {

        const string _NAME = "Medium Enemy";
        const int _LIFE = 150;
        const float _ARMOR = 25.0f;
        const int _RESISTANCE = 25;
        const float _SPEED = 1.0f;
        const int _REWARD = 30;

        public MediumEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.MEDIUM_ENEMY;
        }
    }
}
