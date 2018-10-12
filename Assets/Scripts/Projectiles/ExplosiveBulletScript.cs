using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class ExplosiveBulletScript : MonoBehaviour
    {
        [SerializeField]
        public Vector3 target;
        public AudioClip ExplosiveSound;
        public float _Speed = 50.0f;
        public float _Damage;
        public Animator _anim;
        public SpriteRenderer Shadow;
        private float _RotationSpeed = -1;

        private const string ANIM_KEY = "isColliding";


        // Use this for initialization
        void Start()
        {

        }

        public void DeactivateBullet()
        {
            _anim.SetBool(ANIM_KEY, false);
            this.transform.parent.gameObject.SetActive(false);

            _RotationSpeed = -1;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_anim.GetBool(ANIM_KEY)) {
                if (_RotationSpeed == -1) {
                    _RotationSpeed = Random.Range(200.0f, 500.0f);
                }

                float step = _Speed * Time.deltaTime;
                transform.parent.position = Vector3.MoveTowards(transform.position, target, step);

                transform.Rotate(0, 0, _RotationSpeed * Time.deltaTime);
                Shadow.transform.Rotate(0, 0, _RotationSpeed * Time.deltaTime);

                if (transform.position == target)
                {
                    AudioManagerScript.Instance.Play(ExplosiveSound, Camera.main.transform, 0.75f);

                    _anim.SetBool(ANIM_KEY, true);

                    LayerMask EnemyMask;
                    EnemyMask = LayerMask.GetMask("Enemy");
                    RaycastHit2D[] colliders = Physics2D.CircleCastAll(transform.position, 1.0f, Vector2.left, 0f, EnemyMask);
                    for (int q = 0; q < colliders.Length; q++)
                    {
                        Debug.Log(colliders[q].collider.name);

                        if (colliders[q].collider.gameObject.tag == "Enemy")
                        {
                            Enemy e = colliders[q].collider.gameObject.GetComponent<Enemy>();
                            e.TakeDamage(_Damage);
                        }
                    }
                }
            }
        }

    }
}