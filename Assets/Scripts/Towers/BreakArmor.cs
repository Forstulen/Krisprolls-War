using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class BreakArmor : Tower
    {
        public static string _NAME = "Break Armor";
        const int _DAMAGEMIN = 5;
        const int _DAMAGEMAX = 5;
        const float _RANGE = 2.0f;
        const float _SPEED = 0.0f;
        public static int _COST = 60;

        public BreakArmor() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
            _TowerType = TowerType.BREAK_ARMOR;


        }

        public override void Action()
        {

            // Si l'ennemie entre dans la zone
            // L'armure de celle ci est diminué tant qu'il est dans la zone
            // Remettre l'armure à son état initial quand il sort du trigger

        }

        protected override void OnTriggerEnter2D(Collider2D collider2D)
        {
            

            if (collider2D.gameObject.tag == "Enemy")
            {
                Enemy _Enemy = collider2D.GetComponent<Enemy>();
                Debug.Log(_Enemy.name);
                float alea = Random.Range(_DamageMin, _DamageMax);
                _Enemy.BreakArmor(alea);

            }
        }

        protected override void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Enemy")
            {
              
                Enemy _Enemy = collider2D.GetComponent<Enemy>();
                Debug.Log(_Enemy.name);
                float alea = Random.Range(_DamageMin, _DamageMax);
                _Enemy.RestoreArmor(alea);
            }
        }

        public override void UpgradeTower()
        {
            ++_TowerLevel;

            switch (_TowerLevel)
            {
                case TowerLevel.LEVEL_1:
                    _CurrentPriceTower = _COST;
                    break;
                case TowerLevel.LEVEL_2:
                    _DamageMin = 10.0f;
                    _DamageMax = 10.0f;
                    _Speed -= 0.2f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 20.0f;
                    _DamageMax = 20.0f;
                    _Speed -= 0.2f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 30.0f;
                    _DamageMax = 30.0f;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 50.0f;
                    _DamageMax = 50.0f;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 4;
                    break;
                case TowerLevel.LEVEL_6:
                    _DamageMin = 75.0f;
                    _DamageMax = 75.0f;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _TowerLevel = TowerLevel.LEVEL_MAX;
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
            return TowerLevel.LEVEL_6;
        }
    }
}
