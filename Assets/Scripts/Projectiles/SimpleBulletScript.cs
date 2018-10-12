using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class SimpleBulletScript : MonoBehaviour
    {

        [SerializeField]
        public Transform target;
        public float _Speed = 0.9f;
        public float _Damage;
        public Animator _anim;

        private Vector3 _lastPosition;
        private CircleCollider2D _collider2D;

        protected const string ANIM_KEY = "isColliding";

        // Use this for initialization
        void Start()
        {
            _collider2D = GetComponent<CircleCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                _lastPosition = target.position;
            } else {
                _collider2D.enabled = false;
            }
            
                float step = _Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _lastPosition, step);

            if (_lastPosition == transform.position && target == null )
            {
                this.gameObject.SetActive(false);
            }
            
        }

        public void DeactivateBullet() {
            _anim.SetBool(ANIM_KEY, false);
            this.gameObject.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                _anim.SetBool(ANIM_KEY, true);
            }
        }
    }
}
