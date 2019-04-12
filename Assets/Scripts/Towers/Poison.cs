using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public struct PoisonStruct
    {
        public float Damage;
        public float TickDuration;
        public float TickProc;

    }

    public class Poison : Tower
    {
        public static string _NAME = "Poison";
        const int _DAMAGEMIN = 7;
        const int _DAMAGEMAX = 10;
        const float _RANGE = 2.5f;
        const float _SPEED = 2.5f;
        public static int _COST = 150;

    
        private float _TickIni = 0.0f;
        private float _TickDuration = 2.5f;
        private float _TickProc = 0.5f;

        public Poison() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
            _TowerType = TowerType.POISON;
        }

        public override void Action()
        {
                if (_Enemy != null && _ElapseTime >= this._Speed)
                {

                if (!_Enemy.gameObject.activeSelf)
                    {
                        Debug.Log("FORCE RESET FOR EMPTY TARGET");
                        SelectTarget();
                    }

                    _ElapseTime = 0.0f;

                    _anim.SetBool("Fire", true);

                    _anim.speed = _initialSpeed / _Speed;

                    StartCoroutine(ReactivateAnimation());

                    GameObject BulletGameObject = BulletManagerScript.Instance.CreateBullet(transform.position, Quaternion.identity, BulletType.POISONOUS_BULLET);
                    PoisonousBulletScript bulletScript = BulletGameObject.GetComponent<PoisonousBulletScript>();

                    bulletScript.target = _Enemy;

                    float alea = Random.Range(_DamageMin, _DamageMax);

                    bulletScript._Damage = alea;
                    bulletScript._TickIni = _TickIni;
                    bulletScript._TickDuration = _TickDuration;
                    bulletScript._TickProc = _TickProc;

                    AudioManagerScript.Instance.Play(FireSound, transform, 0.5f);
                }
                _ElapseTime += Time.deltaTime;
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
                    _DamageMin = 7;
                    _DamageMax = 10;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 10;
                    _DamageMax = 12;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _TickDuration = 3.0f;
                    _TickProc = 0.5f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 12;
                    _DamageMax = 15;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 15;
                    _DamageMax = 20;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _TickDuration = 3.2f;
                    _TickProc = 0.4f;
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