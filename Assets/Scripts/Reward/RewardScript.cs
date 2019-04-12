using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public abstract class RewardScript : MonoBehaviour
    {

        public int      GoldAmount;
        public float    ExpirationTime = 1.0f;
        public Animator GoldAnimator;
        public Text     GoldText;
        protected RewardType Type;

        private float   _time;
        private bool    _collected;

        protected string DEAD_ANIM_KEY = "isDead";

        public void Initialize(int goldAmount)
        {
            GoldAmount = goldAmount;
            _time = 0.0f;
            gameObject.SetActive(true);
            GoldText.text = string.Format("+{0}", GoldAmount);
            _collected = false;
        }

        // Update is called once per frame
        protected void Update()
        {
            _time += Time.deltaTime;

            if (_time > ExpirationTime && !_collected)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnMouseDown()
        {
            CollectReward();
        }

        protected virtual void CollectReward()
        {
            _collected = true;

            GameManagerScript.Instance.ClaimReward(GoldAmount);

            StartCoroutine(AnimateCollect());
        }

        protected virtual IEnumerator AnimateCollect() {
            GoldAnimator.SetBool(DEAD_ANIM_KEY, true);

            yield return new WaitForSeconds(0.5f);

            gameObject.SetActive(false);

            GoldAnimator.SetBool(DEAD_ANIM_KEY, false);
        }
    }
}
