using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense {
    public enum TowerTargetingType {
        RANDOMLY = 0,
        QUEUE,
        LESS_LIFE
    }

    public enum TowerLevel
    {
        NONE = 0,
        LEVEL_1,
        LEVEL_2,
        LEVEL_3,
        LEVEL_4,
        LEVEL_5,
        LEVEL_6,
        LEVEL_7,
        LEVEL_8,
        LEVEL_9,
        LEVEL_MAX
    }


    [RequireComponent(typeof(CircleCollider2D))]
    public class Tower : MonoBehaviour
    {
        public bool IsActive = false;
        [SerializeField]
        protected float _DamageMin;
        [SerializeField]
        protected float _DamageMax;
        protected float _Range;
        [SerializeField]
        protected float _Speed;
        protected TowerType _TowerType;
        [SerializeField]
        protected TowerLevel _TowerLevel;
        protected TowerLevel _MaxTowerLevel;

        [SerializeField]
        protected TowerTargetingType _targetingType;

        public Animator _anim;

        public AudioClip CreateSound;
        public AudioClip FireSound;
        public AudioClip DestroySound;
        public AudioClip UpgradeSound;

        public SpriteRenderer RangeRenderer;

        [SerializeField]
        protected GameObject _Bullet;
        [SerializeField]
        protected Transform _Enemy;

        protected float _ElapseTime;


        protected CircleCollider2D _Collider;

        [SerializeField]
        private List<GameObject> _colliderList;
        [SerializeField]
        private List<GameObject> _shouldRemoveList;

        protected float _initialSpeed;

        protected int _CurrentPriceTower;

        public Tower(int _DamageMin, int _DamageMax, float _Range, float _Speed)
        {
            this._DamageMin = _DamageMin;
            this._DamageMax = _DamageMax;
            this._Range = _Range;
            this._Speed = _Speed;
            this._Enemy = null;
            this._ElapseTime = _Speed;
            this._targetingType = TowerTargetingType.RANDOMLY;
            this._TowerLevel = TowerLevel.NONE;
            this._initialSpeed = _Speed;
        }

        void Start()
        {
            _Collider = this.gameObject.GetComponent<CircleCollider2D>();
            _colliderList = new List<GameObject>(5);
            _shouldRemoveList = new List<GameObject>(5);

            UpgradeTower();
        }

        void Update()
        {
            if (RangeRenderer.gameObject.activeInHierarchy) {
                RangeRenderer.color = new Color(RangeRenderer.color.r, RangeRenderer.color.g, RangeRenderer.color.b, Mathf.PingPong(Time.time, 1));
            }

            if (IsActive)
                Action();
        }

        void ResetTarget(GameObject obj)
        {
            FollowingWaypointScript script = obj.gameObject.GetComponent<FollowingWaypointScript>();

            script.StopFollowing -= ResetTarget;

            _shouldRemoveList.Add(obj);

            if (_Enemy && obj.transform == _Enemy.transform)
            {
                _Enemy = null;
            }

            SelectTarget();
        }

        public void ShowRange() {
            RangeRenderer.transform.localScale = new Vector3(_Collider.radius * 0.9f, _Collider.radius * 1.08f, 0.0f);

            RangeRenderer.gameObject.SetActive(true);
        }

        public void HideRange() {
            RangeRenderer.gameObject.SetActive(false);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Enemy")
            {
                if (!_colliderList.Contains(collider2D.gameObject))
                {
                    FollowingWaypointScript script = collider2D.GetComponent<FollowingWaypointScript>();

                    script.StopFollowing += ResetTarget;

                    _colliderList.Add(collider2D.gameObject);
                }

                SelectTarget();
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                FollowingWaypointScript script = collider.gameObject.GetComponent<FollowingWaypointScript>();

                script.StopFollowing -= ResetTarget;
                _shouldRemoveList.Add(collider.gameObject);

                if (_Enemy != null && _Enemy == collider.transform || _Enemy == null)
                {
                    _Enemy = null;

                    SelectTarget();
                }
            }
        }

        //CREATE BUG WITH RESET TARGET
        /*void OnTriggerStay2D(Collider2D collider)
            {
                if (_Enemy == null && collider.gameObject.tag == "Enemy")
                {
                    _Enemy = collider.transform;

                    FollowingWaypointScript script = _Enemy.GetComponent<FollowingWaypointScript>();

                    script.StopFollowing += ResetTarget;
                }
            }*/

        public TowerTargetingType GetTargetingType()
        {
            return _targetingType;
        }

        public void SetTargetingType(TowerTargetingType type)
        {
            _targetingType = type;
        }

        public float Range()
        {
            return _Range;
        }

        public TowerType GetTowerType()
        {
            return _TowerType;
        }

        public virtual void Action()
        {
            if (_Enemy != null && _ElapseTime >= this._Speed)
            {

                if (!_Enemy.gameObject.activeSelf)
                {
                    Debug.Log("FORCE RESET FOR EMPTY TARGET");
                    SelectTarget();
                }

                if (_Enemy != null)
                {
                    _ElapseTime = 0.0f;

                    _anim.SetBool("Fire", true);
                    _anim.speed = _initialSpeed / _Speed;

                    StartCoroutine(ReactivateAnimation());

                    GameObject BulletGameObject = BulletManagerScript.Instance.CreateBullet(transform.position, Quaternion.identity, BulletType.SIMPLE_BULLET);

                    SimpleBulletScript bulletScript = BulletGameObject.GetComponent<SimpleBulletScript>();

                    bulletScript.target = _Enemy;

                    float alea = Random.Range(_DamageMin, _DamageMax);

                    bulletScript._Damage = alea;

                    AudioManagerScript.Instance.Play(FireSound, transform, 0.5f);
                }
            }
            _ElapseTime += Time.deltaTime;

        }

        protected IEnumerator ReactivateAnimation() {
            yield return new WaitForSeconds(_Speed - 0.1f);

            _anim.SetBool("Fire", false);
        }

        protected void SelectTarget()
        {
            if (_shouldRemoveList.Count > 0)
            {
                foreach (GameObject go in _shouldRemoveList)
                {
                    if (_colliderList.Contains(go))
                        _colliderList.Remove(go);
                }
                _shouldRemoveList.Clear();

            }

            if ((_Enemy == null || (_Enemy != null && !_Enemy.gameObject.activeSelf)) &&
                (_colliderList != null &&
                 _colliderList.Count > 0))
            {
                switch (_targetingType)
                {
                    case TowerTargetingType.RANDOMLY:
                        _Enemy = _colliderList[Random.Range(0, _colliderList.Count)].transform;
                        break;
                    case TowerTargetingType.LESS_LIFE:
                        int life = int.MaxValue;
                        GameObject g = _colliderList[0];
                        foreach (GameObject go in _colliderList)
                        {
                            int temp = go.GetComponent<Enemy>().GetLife();
                            if (life > temp)
                            {
                                life = temp;
                                g = go;
                            }
                        }
                        _Enemy = g.transform;
                        break;
                    case TowerTargetingType.QUEUE:
                        _Enemy = _colliderList[0].transform;
                        break;

                }

                if (_Enemy != null && !_Enemy.gameObject.activeSelf) {
                    _shouldRemoveList.Add(_Enemy.gameObject);
                    _Enemy = null;
                    SelectTarget();
                }
            }
        }

        public virtual void CreateTower() {
            AudioManagerScript.Instance.Play(CreateSound, transform, 0.5f);

            IsActive = true;
        }

        public virtual void DestroyTower() {
            AudioManagerScript.Instance.Play(DestroySound, transform, 0.5f);

            IsActive = false;
        }

        public virtual void UpgradeTower()
        {
            _DamageMin = Mathf.RoundToInt(_DamageMin * 1.2f);
            _DamageMax = Mathf.RoundToInt(_DamageMax * 1.2f);
            _Speed += 0.2f;
            _Range += 0.2f;
            _Collider.radius = _Range;
            _CurrentPriceTower *= 2;

            AudioManagerScript.Instance.Play(UpgradeSound, transform, 0.5f);
        }

        public bool CanBeUpgraded() {
            return _TowerLevel != TowerLevel.LEVEL_MAX;
        }

        public TowerLevel GetLevel()
        {
            return _TowerLevel;
        }

        public virtual TowerLevel GetMaxLevel() {
            return TowerLevel.LEVEL_MAX;   
        }

        public int GetCurrentPrice()
        {
            return _CurrentPriceTower;
        }
            
    }
}

