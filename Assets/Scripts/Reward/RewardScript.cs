using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public abstract class RewardScript : MonoBehaviour
    {

        public int GoldAmount;
        public float ExpirationTime = 1.0f;
        protected RewardType Type;

        private float _time;

        public void Initialize(int goldAmount)
        {
            GoldAmount = goldAmount;
            _time = 0.0f;
            gameObject.SetActive(true);
        }

        // Update is called once per frame
        protected void Update()
        {
            _time += Time.deltaTime;

            if (_time > ExpirationTime)
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
            GameManagerScript.Instance.ClaimReward(GoldAmount);
            gameObject.SetActive(false);
        }
    }
}
