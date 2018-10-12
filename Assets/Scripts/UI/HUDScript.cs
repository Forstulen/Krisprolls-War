using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class HUDScript : MonoBehaviour
    {

        public Text _Lives;
        public Text _Golds;
        public Text _Waves;

        // Use this for initialization
        void Start()
        {
            SetTexts();
        }

        void SetTexts() {
            if (GameManagerScript.Instance.CurrentLevel != Level.ADJUSTEMENT)
            {
                int currentWave = (GameManagerScript.Instance.GetWaves() + 1);

                _Waves.text = (currentWave > GameManagerScript.Instance.GetWavesNumber() ? GameManagerScript.Instance.GetWavesNumber() : currentWave) + "/" + GameManagerScript.Instance.GetWavesNumber();

            } else {
                _Waves.text = "0/0";
            }
            _Lives.text = GameManagerScript.Instance.GetLives().ToString();
            _Golds.text = GameManagerScript.Instance.GetGolds().ToString();
        }

        // Update is called once per frame
        void Update()
        {
            SetTexts();
        }
    }
}