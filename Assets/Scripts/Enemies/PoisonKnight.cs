using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class PoisonKnight : Enemy
    {

        const string _NAME = "Poison Knight";
        const int _LIFE = 50;
        const float _ARMOR = 50.0f;
        const int _RESISTANCE = 25;
        const float _SPEED = 1.5f;
        const int _REWARD = 30;

        public PoisonKnight() : base(_NAME, _LIFE, _ARMOR, _RESISTANCE, _SPEED, _REWARD)
        {
            _Type = EnemyType.POISON_KNIGHT;
        }

        protected override IEnumerator TickDuration(PoisonStruct s)
        {
            float i = 0;
            while (i < s.TickDuration)
            {
                _LifePoisonous = _Life * s.Damage / 100.0f;
                _Life += Mathf.RoundToInt(_LifePoisonous);

                float value = (float)_Life / (float)_SavedLife;

                HealthBar.value = value;

                yield return new WaitForSeconds(s.TickProc);

                i += s.TickProc;
            }
        }
    }
}
