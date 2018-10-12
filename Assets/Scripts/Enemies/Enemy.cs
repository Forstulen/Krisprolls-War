using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public enum EnemyType {
        LIGHT_ENEMY = 0,
        MEDIUM_ENEMY,
        HEAVY_ENEMY,
        HEAVY_KNIGHT_ENEMY,
        NONE
    }

    [RequireComponent(typeof(SpriteRenderer))] 
    [RequireComponent(typeof(Animator))] 
    public abstract class Enemy : FollowingWaypointScript
    {
        string _Name;
        [SerializeField]
        int _Life;
        [SerializeField]
        float _Armor;
        int _Resistance;
        [SerializeField]
        float _Speed;

        public AudioClip DeathSound;
        //public AudioClip WalkSound;
        //public AudioClip SpawnSound;

        public Slider    HealthBar;

        private AudioSource _walkingSource;

        private Animator _anim;

        private int _Reward;

        private float _BrokeArmor;

        private float _DecreaseSpeed;

        private float _LifePoisonous;

        private SpriteRenderer _Renderer;

        protected EnemyType _Type;

        private float _lastXPosition;

        const string DEAD_ANIM_KEY = "isDead";

        //DO NOT TOUCH
        int _SavedLife;
        float _SavedArmor;
        int _SavedResistance;
        float _SavedSpeed;

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
        }

        private void OnEnable()
        {
            ResetEnemy();
        }

        private void ResetEnemy() {
            this._Life = _SavedLife;
            this._Armor = _SavedArmor;
            this._Resistance = _SavedResistance;
            this._Speed = _SavedSpeed;
            MovementSpeed = this._Speed;

            _DecreaseSpeed = 0.0f;
            _BrokeArmor = 0.0f;
            _LifePoisonous = 0.0f;

            ResetTarget();

            StopCoroutine("TickDuration");

            if (_Renderer != null && _anim != null)
            {
                _Renderer.color = Color.white;
                _anim.SetBool(DEAD_ANIM_KEY, false);
            }

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
            _Renderer.color = Color.green;
            StartCoroutine(TickDuration(s));
        }

        public void DecreaseSpeed(float percent)
        {
            _Renderer.color = Color.blue;
            _DecreaseSpeed = _Speed * (percent / 100.0f);
            _Speed -= _DecreaseSpeed;
            MovementSpeed = _Speed;
        }

        public void RestoreSpeed(float percent)
        {
            _Renderer.color = Color.white;
            _Speed += _DecreaseSpeed;
            _DecreaseSpeed = 0;
            MovementSpeed = _Speed;
        }

        public void BreakArmor(float armor)
        {

            _Renderer.color = Color.black;
            if (_Armor >1.0f)
            {
                _BrokeArmor += armor;
                _Armor -= _BrokeArmor;

                Debug.Log("Armor is now " + _Armor);
            }
            
        }

        public void RestoreArmor(float armor)
        {
            _Renderer.color = Color.white;
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

        public void TakeDamage(float damage)
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

            //_walkingSource = AudioManagerScript.Instance.PlayLoop(WalkSound, transform, 0.1f);

            StartWalking();
        }

        public void DeathStand() {
            Deactivate();
        }

        public void Die()
        {
            _anim.SetBool(DEAD_ANIM_KEY, true);

            AudioManagerScript.Instance.Play(DeathSound, Camera.main.transform, 0.25f);

            HealthBar.value = 0.0f;
            HealthBar.gameObject.SetActive(false);

            StopWalking();
        }

        public void Deactivate() {
            ResetEnemy();

            gameObject.SetActive(false);
        }

        IEnumerator TickDuration(PoisonStruct s)

        {
            float i = 0;
            while ( i < s.TickDuration)
            {
                _LifePoisonous = _Life * s.Damage / 100.0f;
                _Life -= Mathf.RoundToInt(_LifePoisonous);

                float value = (float)_Life / (float)_SavedLife;

                HealthBar.value = value;

                yield return new WaitForSeconds(s.TickProc);

                i += s.TickProc;
            }
            _Renderer.color = Color.white;

        }
    }

    
}
