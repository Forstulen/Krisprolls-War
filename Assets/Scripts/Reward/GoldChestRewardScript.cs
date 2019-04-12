using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GoldChestRewardScript : RewardScript
    {
        private SpriteRenderer  _renderer;
        private Color           _savedColor;

        private void Start()
        {
            Type = RewardType.CHEST;
            ExpirationTime = 1.5f;
            _renderer = GetComponent<SpriteRenderer>();
            _savedColor = _renderer.color;
        }

        protected override IEnumerator AnimateCollect()
        {
            GoldAnimator.SetBool(DEAD_ANIM_KEY, true);

            _renderer.color = new Color(0, 0, 0, 0);

            yield return new WaitForSeconds(0.5f);

            gameObject.SetActive(false);

            _renderer.color = _savedColor;

            GoldAnimator.SetBool(DEAD_ANIM_KEY, false);
        }
    }
}
