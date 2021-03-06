﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class UIAnimatedEnemyScript : MonoBehaviour
    {

        public RectTransform            Background;
        public RectTransform            Panel;
        public TranslateImageScript[]   TranslateArray;

        private float                   _time;
        private float                   _delay;

        private void Start()
        {
            _time = 0.0f;
            _delay = Random.Range(1.0f, 2.0f);
        }

        private void Update()
        {
            if (_time >= _delay) {
                int type = Random.Range(0, TranslateArray.Length);

                TranslateImageScript go = Instantiate<TranslateImageScript>(TranslateArray[type], Panel);
                RectTransform rect = go.GetComponent<RectTransform>();

                go.transform.position = Vector3.zero;
                go.SetLimit(Background.rect.width / 2 + rect.rect.width);
                rect.localPosition = new Vector3(-Background.rect.width / 2 - rect.rect.width, Random.Range(-180.0f, -200.0f), 0.0f);

                _time = 0.0f;

                _delay = Random.Range(3.0f, 8.0f);
            }

            _time += Time.deltaTime;
        }
    }
}
