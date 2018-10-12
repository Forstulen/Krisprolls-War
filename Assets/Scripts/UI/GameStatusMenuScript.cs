using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class GameStatusMenuScript : MonoBehaviour
    {
        [System.Serializable]
        public struct EnemySprite
        {
            public EnemyType type;
            public GameObject enemySprite;
        };

        public float                    Delay = 0.5f;
        public AudioClip                Sound;
        public AudioClip                WinMusic;
        public AudioClip                LoseMusic;
        public Text                     LevelStatus;
        public RectTransform[]          EnemyPanelArray;
        public HorizontalLayoutGroup[]  HorizontalLayoutArray;
        public Text[]                   CountArray;
        [SerializeField]
        private EnemySprite[]           EnemySpriteArray;

        private float[]                 _totalSize;
        private int[]                   _totalItem;

        private float                   _decreasedDelay;
        private bool                    _isSkipped;

        private void OnEnable()
        {
            Initialize();

            List<EnemyType> list = GameManagerScript.Instance.GetKilledEnemiesList();

            foreach (EnemyType t in list) {
                GameObject go = Instantiate(GetEnemySprite(t));

                go.transform.parent = EnemyPanelArray[(int)t];
                go.SetActive(false);

                RectTransform rect = go.GetComponent<RectTransform>();

                _totalSize[(int)t] += rect.rect.width;
                _totalItem[(int)t]++;
            }

            DisplaySprites();
        }

        private void DisplaySprites() {
            for (int i = 0; i < HorizontalLayoutArray.Length; ++i)
            {
                float spacing = (EnemyPanelArray[i].rect.width - _totalSize[i]) / (float)_totalItem[i] - 10.0f;

                HorizontalLayoutArray[i].spacing = spacing > (_totalSize[i] / (float)_totalItem[i]) ? (_totalSize[i] / (float)_totalItem[i]) : spacing;
            }

            StartCoroutine(DisplayWithDelay());
        }

        private void Initialize()
        {
            _totalSize = new float[(int)EnemyType.NONE];
            _totalItem = new int[(int)EnemyType.NONE];
            _decreasedDelay = Delay;
            _isSkipped = false;

            LevelStatus.text = "";

            foreach (RectTransform rect in EnemyPanelArray)
            {
                foreach (Transform t in rect.transform)
                {
                    Destroy(t.gameObject);
                }
            }
        }

        IEnumerator DisplayWithDelay()
        {
            int i = 0;

            foreach (RectTransform rect in EnemyPanelArray)
            {
                _decreasedDelay = Delay;
                foreach (Transform t in rect.transform)
                {
                    if (!_isSkipped)
                        AudioManagerScript.Instance.Play(Sound, Camera.main.transform, 0.15f);
                    t.gameObject.SetActive(true);
                    yield return new WaitForSeconds(_isSkipped ? 0.0f : _decreasedDelay);
                    _decreasedDelay -= 0.05f;
                    _decreasedDelay = _decreasedDelay <= 0.0f ? 0.05f : _decreasedDelay;
                }

                CountArray[i].text =  _totalItem[i] > 0 ? _totalItem[i].ToString() : "";
                ++i;
            }

            DisplayText();
        }

        public void Skip() {
            _isSkipped = true;
        }

        private void DisplayText() {
            int lives = GameManagerScript.Instance.GetLives();

            if (lives <= 0)
            {
                AudioManagerScript.Instance.Play(LoseMusic, Camera.main.transform, 0.4f);
                LevelStatus.text = "Guntherson is disappointed...";
            }
            else
            {
                AudioManagerScript.Instance.Play(WinMusic, Camera.main.transform, 0.4f);
                LevelStatus.text = "Guntherson is proud of you!";
            }
        }

        private GameObject GetEnemySprite(EnemyType type) {
            foreach (EnemySprite s in EnemySpriteArray) {
                if (s.type == type)
                    return s.enemySprite;
            }
            return null;
        }
    }
}
