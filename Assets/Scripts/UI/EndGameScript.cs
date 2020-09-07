using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class EndGameScript : MonoBehaviour
    {
        public ScrollRect   CreditsRect;
        public float        Length = 20.0f;
        public float        InitialDelay = 3.0f;
        public Button       SkipButton;
        public GameObject   Background;

        private float       _elapsedTime;
        private bool        _startAutoScrolling;

        private void OnEnable()
        {
            _startAutoScrolling = false;
            _elapsedTime = 0.0f;
            CreditsRect.enabled = false;

            if (Background)
                Background.SetActive(false);

            StartCoroutine(StartAutoScrolling());
        }

        void Update()
        {
            if (_startAutoScrolling)
            {
                CreditsRect.verticalNormalizedPosition = 1.0f - (1.0f / Length) * _elapsedTime;

                _elapsedTime += Time.smoothDeltaTime;
            }

            if (_elapsedTime >= Length) {
                SkipButton.onClick.Invoke();
            }
        }

        private IEnumerator StartAutoScrolling() {
            yield return new WaitForSeconds(InitialDelay);

            _startAutoScrolling = true;
        } 
    }
}
