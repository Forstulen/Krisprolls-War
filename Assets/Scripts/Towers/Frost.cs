using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Frost : Tower
    {
        public static string _NAME = "Frost";
       const int _DAMAGEMIN = 10;
        const int _DAMAGEMAX = 10;
       const float _RANGE = 2.0f;
       const float _SPEED = 0.0f;
        public static int _COST = 40;

        public Frost() : base(_DAMAGEMIN,_DAMAGEMAX, _RANGE, _SPEED)
        {
            _TowerType = TowerType.FROST;
        }


        public override void Action()
        {

        }

        protected override void OnTriggerEnter2D(Collider2D collider2D)
        {


            if (collider2D.gameObject.tag == "Enemy")
            {
                Enemy enemy = collider2D.GetComponent<Enemy>();
                float alea = Random.Range(_DamageMin, _DamageMax);
                enemy.DecreaseSpeed(alea);

            }
        }

        protected override void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Enemy")
            {

                Enemy enemy = collider2D.GetComponent<Enemy>();
                float alea = Random.Range(_DamageMin, _DamageMax);
                enemy.RestoreSpeed(alea);
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
                    _DamageMin = 15;
                    _DamageMax = 15;
                    _Speed -= 0.2f;
                    _Range += 0.1f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 20;
                    _DamageMax = 20;
                    _Speed -= 0.2f;
                    _Range += 0.1f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 30;
                    _DamageMax = 30;
                    _Speed -= 0.25f;
                    _Range += 0.2f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 40;
                    _DamageMax = 40;
                    _Speed -= 0.25f;
                    _Range += 0.3f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 4;
                    break;
                case TowerLevel.LEVEL_6:
                    _DamageMin = 50;
                    _DamageMax = 50;
                    _Speed -= 0.25f;
                    _Range += 0.3f;
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
