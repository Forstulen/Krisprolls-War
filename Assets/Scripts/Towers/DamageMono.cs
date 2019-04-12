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

        public DamageMono() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
            _TowerType = TowerType.DAMAGE_MONO;
        }

        public override void UpgradeTower()
        {
            ++_TowerLevel;

            switch (_TowerLevel) {
                case TowerLevel.LEVEL_1:
                    _CurrentPriceTower = _COST;
                    break;
                case TowerLevel.LEVEL_2:
                    _DamageMin = 20;
                    _DamageMax = 25;
                    _Speed -= 0.1f;
                    _Range += 0.2f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 25;
                    _DamageMax = 30;
                    _Speed -= 0.1f;
                    _Range += 0.2f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 30;
                    _DamageMax = 40;
                    _Speed -= 0.2f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 40;
                    _DamageMax = 50;
                    _Speed -= 0.2f;
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

            DisplayTowerLevelScript script = GetComponent<DisplayTowerLevelScript>();

            if (script)
                script.DisplayLevel();

            AudioManagerScript.Instance.Play(UpgradeSound, transform, 0.5f);
        }

        public override void DestroyTower()
        {
            base.DestroyTower();

            _DamageMin = _DAMAGEMIN;
            _DamageMax = _DAMAGEMAX;
            _Range = _RANGE;
            _Speed = _SPEED;
            _CurrentPriceTower = _COST;
            _TowerLevel = TowerLevel.LEVEL_1;

            if (_Collider)
                _Collider.radius = _Range;

            DisplayTowerLevelScript script = GetComponent<DisplayTowerLevelScript>();

            if (script)
                script.DisplayLevel();
        }

        public override TowerLevel GetMaxLevel()
        {
            return TowerLevel.LEVEL_5;
        }
    }
}