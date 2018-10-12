using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class LightEnemy : Enemy
    {

        const string _NAME = "Light Enemy";
        const int _LIFE = 10;
        const float _ARMOR = 1.0f;
        const int _RESISTANCE = 0;
        const float _SPEED = 1.5f;
        const int _REWARD = 10;

        public LightEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.LIGHT_ENEMY;
        }
    }
}
