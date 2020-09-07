using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class FrostEnemy : Enemy
    {

        const string _NAME = "Frost Enemy";
        const int _LIFE = 200;
        const float _ARMOR = 40.0f;
        const int _RESISTANCE = 25;
        const float _SPEED = 0.75f;
        const int _REWARD = 40;

        public FrostEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.FROST_ENEMY;
        }

        public override void DecreaseSpeed(float percent)
        {
            //UNSTOPABLE !
        }

        public override void RestoreSpeed(float percent)
        {
            //UNSTOPABLE !
        }
    }
}
