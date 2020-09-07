using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class SpeedEnemy : Enemy
    {

        const string _NAME = "Speed Enemy";
        const int _LIFE = 10;
        const float _ARMOR = 95.0f;
        const int _RESISTANCE = 0;
        const float _SPEED = 3.25f;
        const int _REWARD = 20;

        const float _SPEED_REDUCER_COEFF = 4.0f;

        public SpeedEnemy() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.SPEED_ENEMY;
        }

        public override void DecreaseSpeed(float percent)
        {
            FrostObject.SetActive(true);
            _DecreaseSpeed = _Speed * (percent * _SPEED_REDUCER_COEFF / 100.0f);

            Debug.Log(_DecreaseSpeed);

            if (_DecreaseSpeed >= _Speed) {
                _DecreaseSpeed = _Speed - 0.25f;
            }

            _Speed -= _DecreaseSpeed;
            MovementSpeed = _Speed;
        }

        public override void RestoreSpeed(float percent)
        {
            FrostObject.SetActive(false);
            _Speed += _DecreaseSpeed;
            _DecreaseSpeed = 0;
            MovementSpeed = _Speed;
        }

    }
}
