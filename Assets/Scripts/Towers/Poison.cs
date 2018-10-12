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
        const int _DAMAGEMIN = 1;
        const int _DAMAGEMAX = 2;
        const float _RANGE = 2.0f;
        const float _SPEED = 4.0f;
        public static int _COST = 150;

        const TowerType _TowerType = TowerType.POISON;

        private float _TickIni = 0.0f;
        private float _TickDuration = 2.0f;
        private float _TickProc = 0.5f;

        public Poison() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
        }

        public override void Action()
        {
            {
                if (_Enemy != null && !_Enemy.gameObject.activeInHierarchy)
                {
                    Debug.Log("Untarget");
                    _Enemy = null;
                }

                if (_Enemy != null && _ElapseTime >= this._Speed)
                {
                    _ElapseTime = 0.0f;

                    _anim.SetBool("Fire", true);

                    _anim.speed = _Speed;

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
                    _DamageMin = 3;
                    _DamageMax = 4;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 5;
                    _DamageMax = 6;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _TickDuration = 2.5f;
                    _TickProc = 0.5f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 7;
                    _DamageMax = 8;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 9;
                    _DamageMax = 10;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _TickDuration = 2.8f;
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

            AudioManagerScript.Instance.Play(UpgradeSound, transform, 0.5f);
        }

    }
}