using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DamageAoE : Tower
    {
        public static string _NAME = "Damage Multi";
        const int _DAMAGEMIN = 40;
        const int _DAMAGEMAX = 80;
        const float _RANGE = 2.0f;
        const float _SPEED = 4.0f;
        public static int _COST = 100;

        const TowerType _TowerType = TowerType.AOE;

        public DamageAoE() : base(_DAMAGEMIN, _DAMAGEMAX, _RANGE, _SPEED)
        {
        }

        public override void Action()
        {
            if (_Enemy != null && _ElapseTime >= this._Speed)
            {   
                _ElapseTime = 0.0f;

                _anim.SetBool("Fire", true);

                //_anim.speed = _Speed;

                StartCoroutine(ReactivateAnimation());

                GameObject BulletGameObject = BulletManagerScript.Instance.CreateBullet(new Vector3(transform.position.x, transform.position.y + 0.75f, 0.0f), Quaternion.identity, BulletType.EXPLOSIVE_BULLET);
                
                ExplosiveBulletScript bulletScript = BulletGameObject.GetComponentInChildren<ExplosiveBulletScript>();

                bulletScript.target = _Enemy.position;

                float alea = Random.Range(_DamageMin, _DamageMax);

                bulletScript._Damage = alea;

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
                    _DamageMin = 60;
                    _DamageMax = 100;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST;
                    break;
                case TowerLevel.LEVEL_3:
                    _DamageMin = 80;
                    _DamageMax = 120;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 2;
                    break;
                case TowerLevel.LEVEL_4:
                    _DamageMin = 100;
                    _DamageMax = 130;
                    _Speed -= 0.25f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 3;
                    break;
                case TowerLevel.LEVEL_5:
                    _DamageMin = 120;
                    _DamageMax = 150;
                    _Speed -= 0.5f;
                    _Range += 0.25f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 4;
                    break;
                case TowerLevel.LEVEL_6:
                    _DamageMin = 150;
                    _DamageMax = 180;
                    _Speed -= 0.5f;
                    _Range += 0.5f;
                    _Collider.radius = _Range;
                    _CurrentPriceTower += _COST * 5;
                    break;
                case TowerLevel.LEVEL_7:
                    _DamageMin = 180;
                    _DamageMax = 225;
                    _Speed -= 0.5f;
                    _Range += 0.5f;
                    _Collider.radius = _Range;
                    _TowerLevel = TowerLevel.LEVEL_MAX;
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
