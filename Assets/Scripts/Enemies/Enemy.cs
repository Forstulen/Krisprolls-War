using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public enum EnemyType
    {
        LIGHT_ENEMY = 0,
        MEDIUM_ENEMY,
        HEAVY_ENEMY,
        HEAVY_KNIGHT_ENEMY,
        SPEED_ENEMY,
        HEAVY_BERSERK_ENEMY,
        FROST_ENEMY,
        POISON_KNIGHT,
        NONE
    }

    [RequireComponent(typeof(SpriteRenderer))] 
    [RequireComponent(typeof(Animator))] 
    public abstract class Enemy : FollowingWaypointScript
    {
        protected string _Name;
        [SerializeField]
        protected int _Life;
        [SerializeField]
        protected float _Armor;
        protected int _Resistance;
        [SerializeField]
        protected float _Speed;

        public AudioClip DeathSound;
        //public AudioClip WalkSound;
        //public AudioClip SpawnSound;

        public Slider       HealthBar;
        public Animator     GoldAnimator;
        public Text         GoldText;
        public GameObject   BreakArmorObject;
        public GameObject   FrostObject;

        protected AudioSource _walkingSource;

        protected Animator _anim;

        protected int _Reward;

        protected float _BrokeArmor;

        protected float _DecreaseSpeed;

        protected float _speedMalus;

        protected float _LifePoisonous;

        protected SpriteRenderer _Renderer;

        protected EnemyType _Type;

        protected float _lastXPosition;

        protected Color _savedColor;

        const string DEAD_ANIM_KEY = "isDead";

        //DO NOT TOUCH
        protected int _SavedLife;
        protected float _SavedArmor;
        protected int _SavedResistance;
        protected float _SavedSpeed;

        private bool _hasMalus;

        public Enemy(string _Name, int _Life, float _Armor, int _Resistance, float _Speed, int _Reward) 
        {
            this._Name = _Name;
            this._Life = _Life;
            this._Armor = _Armor;
            this._Resistance = _Resistance;
            this._Speed = _Speed;
            this._Reward = _Reward;
            MovementSpeed = this._Speed;
            _Type = EnemyType.LIGHT_ENEMY;

            _SavedLife = _Life;
            _SavedArmor = _Armor;
            _SavedResistance = _Resistance;
            _SavedSpeed = _Speed;
            _speedMalus = 1.0f;

            _hasMalus = false;
        }

        private void OnEnable()
        {
            ResetEnemy();
        }

        private void ResetEnemy() {
            this._Life = _SavedLife;
            this._Armor = _SavedArmor;
            this._Resistance = _SavedResistance;
            this._Speed = _SavedSpeed / _speedMalus;
            MovementSpeed = this._Speed;

            _DecreaseSpeed = 0.0f;
            _BrokeArmor = 0.0f;
            _LifePoisonous = 0.0f;

            ResetTarget();

            StopCoroutine("TickDuration");

            if (_Renderer != null && _anim != null)
            {
                _Renderer.color = _savedColor;
                _anim.SetBool(DEAD_ANIM_KEY, false);
            }
            GoldAnimator.SetBool(DEAD_ANIM_KEY, false);

            BreakArmorObject.SetActive(false);
            FrostObject.SetActive(false);

            _lastXPosition = transform.position.x;
        }

        protected override void Update()
        {
            base.Update();

            if (_lastXPosition > transform.position.x) {
                _Renderer.flipX = true;
            } else {
                _Renderer.flipX = false;   
            }

            _lastXPosition = transform.position.x;
        }

        new void Start()
        {
            base.Start();
            _Renderer = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();

            _savedColor = _Renderer.color;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Shot")
            {
                SimpleBulletScript shot = collider.gameObject.GetComponent<SimpleBulletScript>();
                if (shot.target.gameObject == gameObject)
                    TakeDamage(shot._Damage);
            }

            if (collider.gameObject.tag == "Poison")
            {             
                PoisonousBulletScript shot = collider.gameObject.GetComponent<PoisonousBulletScript>();
                PoisonStruct s;
                s.Damage = shot._Damage;
                s.TickDuration = shot._TickDuration;
                s.TickProc = shot._TickProc;
                if (shot.target.gameObject == gameObject)
                    PoisonDot(s);
            }
        }

        public string GetName()
        {
            return _Name;
        }

        public int GetLife()
        {
            return _Life;
        }

        public int GetResistance()
        {
            return _Resistance;
        }

        public float GetArmor()
        {
            return _Armor;
        }

        public int GetReward()
        {
            return _Reward;
        }

        public EnemyType    GetEnemyType() {
            return _Type;
        }

        public void PoisonDot(PoisonStruct s)
        {
            StartCoroutine(TickDuration(s));
        }

        public virtual void DecreaseSpeed(float percent)
        {
            FrostObject.SetActive(true);
            _DecreaseSpeed = _Speed * (percent / 100.0f);
            _Speed -= _DecreaseSpeed;
            MovementSpeed = _Speed;
        }

        public virtual void RestoreSpeed(float percent)
        {
            FrostObject.SetActive(false);
            _Speed += _DecreaseSpeed;
            _DecreaseSpeed = 0;
            MovementSpeed = _Speed;
        }

        public virtual void BreakArmor(float armor)
        {
            BreakArmorObject.SetActive(true);
            if (_Armor >1.0f)
            {
                _BrokeArmor += armor;
                _Armor -= _BrokeArmor;

                Debug.Log("Armor is now " + _Armor);
            }
            
        }

        public virtual void RestoreArmor(float armor)
        {
            BreakArmorObject.SetActive(false);
            if (_Armor > 1.0f)
            {
                _Armor += _BrokeArmor;
                _BrokeArmor = 0;

                Debug.Log("Armor is restored now " + _Armor);
            }
        }

        public float GetSpeed()
        {
            return _Speed;
        }

        public void ApplyPermanentSpeedMalus(float coeff) {
            if (!_hasMalus)
            {
                _speedMalus = coeff;
                _Speed /= _speedMalus;
                MovementSpeed = _Speed;
                _hasMalus = true;

                transform.localScale = transform.localScale / coeff;
            }
        }

        public virtual void TakeDamage(float damage)
        {
            FXManagerScript.Instance.CreateFX(new Vector3(transform.position.x, transform.position.y + 0.2f, 0.0f));

            if (_Armor > 1)
            {
                _Life -= Mathf.RoundToInt(damage - (damage * _Armor / 100));
            }
            else
            {
                _Life -= Mathf.RoundToInt(damage);
            }

            float value = (float)_Life / (float)_SavedLife;

            HealthBar.value = value;
        
            if (_Life <= 0) {
                Die();  
            }
        }

        public void Create() {
            //AudioManagerScript.Instance.Play(SpawnSound, Camera.main.transform, 0.25f);

            HealthBar.value = 1.0f;
            HealthBar.gameObject.SetActive(true);
            GoldText.transform.parent.gameObject.SetActive(true);

            //_walkingSource = AudioManagerScript.Instance.PlayLoop(WalkSound, transform, 0.1f);

            StartWalking();
        }

        public void DeathStand() {
            Deactivate();
        }

        public void Die()
        {
            GoldText.text = string.Format("+{0}", _Reward);
            GoldAnimator.SetBool(DEAD_ANIM_KEY, true);
            _anim.SetBool(DEAD_ANIM_KEY, true);

            AudioManagerScript.Instance.Play(DeathSound, Camera.main.transform);

            HealthBar.value = 0.0f;
            HealthBar.gameObject.SetActive(false);

            StopWalking();
        }

        public void Deactivate() {
            ResetEnemy();

            gameObject.SetActive(false);
        }

        protected virtual IEnumerator TickDuration(PoisonStruct s)

        {
            float i = 0;
            while ( i < s.TickDuration)
            {
                _LifePoisonous = _Life * s.Damage / 100.0f;
                _Life -= Mathf.RoundToInt(_LifePoisonous);

                _Renderer.color = Color.Lerp(_savedColor, Color.green, Mathf.PingPong(Time.time, 1));

                float value = (float)_Life / (float)_SavedLife;

                HealthBar.value = value;

                yield return new WaitForSeconds(s.TickProc);

                i += s.TickProc;
            }
            _Renderer.color = _savedColor;

        }
    }

    
}
