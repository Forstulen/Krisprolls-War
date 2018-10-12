using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    
    sealed public class DamageMono : Tower
    {
        public static string _NAME = "Damage Mono";
        const int _DAMAGEMIN = 15;
        const int _DAMAGEMAX = 20;
        const float _RANGE = 2.5f;
        const float _SPEED = 1.5f;
        public static int _COST = 20;

        const TowerType _TowerType = TowerType.DAMAGE_MONO;

        public DamageMono() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
        }

        public override void UpgradeTower()
        {
            ++_TowerLevel;

            switch (_TowerLevel) {
                case TowerLevel.LEVEL_1:
                    _CurrentPriceTower = _COST;
                    break;
                case TowerLevel.LEVEL_2:
                    _DamageMin = 25;
                    _DamageMax = 35;
                    _Speed -= 0.2f;
                    _Range += 0.2f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 35;
                    _DamageMax = 45;
                    _Speed -= 0.2f;
                    _Range += 0.2f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 45;
                    _DamageMax = 60;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 50;
                    _DamageMax = 75;
                    _Speed -= 0.25f;
                    _Range += 0.35f;
                    _Collider.radius = _Range;
                    _TowerLevel = TowerLevel.LEVEL_MAX;
                    break;
                case TowerLevel.LEVEL_6:
                    break;
                case TowerLevel.LEVEL_7:
                    break;
                case TowerLevel.LEVEL_8:
                    break;
                case TowerLevel.LEVEL_9:
                    break;
                case TowerLevel.LEVEL_MAX:
                    break;
            }

            AudioManagerScript.Instance.Play(UpgradeSound, transform, 0.5f);
        }
    }
}