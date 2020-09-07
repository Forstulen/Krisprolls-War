using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class DisplayGameStatusScript : MonoBehaviour
    {
        public CanvasGroup  GameStatusCanvasGroup;
        public Text         GameStatusText;
        public float        FadeSpeed;
        public float        DisplayLenght;

        private float       _elapsedTime;

        private void OnEnable()
        {
            GameStatusText.text = GameManagerScript.Instance.GetWaveStatus();
            GameStatusCanvasGroup.alpha = 0.0f;
            _elapsedTime = 0.0f;
        }

        private void OnDisable()
        {
            GameStatusCanvasGroup.alpha = 0.0f;
        }

        private void Update()
        {
            if (DisplayLenght <= _elapsedTime) {
                GameStatusCanvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, (_elapsedTime - DisplayLenght) / FadeSpeed);

                if (GameStatusCanvasGroup.alpha <= 0.0f) {
                    GameStatusCanvasGroup.gameObject.SetActive(false);
                }
            } else {
                GameStatusCanvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, _elapsedTime / FadeSpeed);
            }

            _elapsedTime += Time.deltaTime;
        }
    }
}
