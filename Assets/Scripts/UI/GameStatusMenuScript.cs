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
        public VerticalLayoutGroup      VerticalLayout;
        public HorizontalLayoutGroup    HorizontalLayout;
        public int                      MaxPerLine = 20;
        public int                      MaxLines = 8;
        public GameObject               SummaryTextPrefab;
        [SerializeField]
        private EnemySprite[]           EnemySpriteArray;

        private float[]                 _totalSize;
        private int[]                  _totalItem;

        private List<HorizontalLayoutGroup> _horizontalLayoutList;

        private float                   _decreasedDelay;
        private bool                    _isSkipped;


        private const string            NO_ENNEMY_KILLED = "No enemy killed";

        private void OnEnable()
        {
            Initialize();

            List<EnemyType> list = GameManagerScript.Instance.GetKilledEnemiesList();

            int i = 0;
            EnemyType lastEnemy = EnemyType.NONE;

            for (int j = 0; j < list.Count; ++j) {
                //if (lastEnemy != EnemyType.NONE && lastEnemy != t) {
                //    GameObject g = Instantiate(GetEnemySprite(lastEnemy));

                //    g.transform.SetParent(_horizontalLayoutList[i].transform, false);
                //    g.SetActive(false);
                //    g.GetComponent<Image>().color = new Color(1, 1, 1, 0);

                //    RectTransform r = g.GetComponent<RectTransform>();

                //    _totalSize[i] += r.rect.width;
                //    _totalItem[i]++;
                //}

                GameObject go = Instantiate(GetEnemySprite(list[j]));

                go.transform.SetParent(_horizontalLayoutList[i].transform, false);
                go.SetActive(false);

                RectTransform rect = go.GetComponent<RectTransform>();

                _totalSize[i] += rect.rect.width;
                _totalItem[i]++;

                if (_totalItem[i] >= MaxPerLine) {
                    ++i;

                    CreateNewHorizontalLayout();
                }

                if (i >= MaxLines) {
                    _horizontalLayoutList[i].childAlignment = TextAnchor.MiddleCenter;

                    go = Instantiate(GetEnemySprite(EnemyType.HEAVY_KNIGHT_ENEMY));
                    go.transform.SetParent(_horizontalLayoutList[i].transform, false);

                    go.GetComponent<Image>().color = new Color(0, 0, 0, 0);

                    go = Instantiate(SummaryTextPrefab) as GameObject;

                    go.transform.SetParent(_horizontalLayoutList[i].transform, false);
                    go.SetActive(false);
                    go.GetComponent<Text>().text = "+" + (list.Count - j).ToString() + "!";
                    break;
                }

                lastEnemy = list[j];
            }

            if (list.Count == 0) {
                _horizontalLayoutList[i].childAlignment = TextAnchor.MiddleCenter;

                GameObject go = Instantiate(SummaryTextPrefab) as GameObject;

                go.transform.SetParent(_horizontalLayoutList[i].transform, false);
                go.SetActive(false);
                go.GetComponent<Text>().text = NO_ENNEMY_KILLED;
            }

            DisplaySprites();
        }

        private void DisplaySprites() {
            float width = VerticalLayout.GetComponent<RectTransform>().rect.width;

            for (int i = 0; i < _horizontalLayoutList.Count; ++i)
            {
                Debug.Log(width + " " + _totalSize[i]);
                float spacing = (width - 200.0f /* MARGINS */ - _totalSize[i]) / (float)MaxPerLine;

                _horizontalLayoutList[i].spacing = spacing;// > (_totalSize[i] / (float)MaxPerLine) ? (_totalSize[i] / (float)MaxPerLine) : spacing;
            }

            StartCoroutine(DisplayWithDelay());
        }

        private void Initialize()
        {
            _totalSize = new float[10];
            _totalItem = new int[10];
            _horizontalLayoutList = new List<HorizontalLayoutGroup>();
            _decreasedDelay = Delay;
            _isSkipped = false;

            LevelStatus.text = "";

            foreach (Transform t in VerticalLayout.transform)
            {
                foreach (Transform tt in t)
                {
                    Destroy(tt.gameObject);
                }
                Destroy(t);
            }

            CreateNewHorizontalLayout();
        }

        private void CreateNewHorizontalLayout() {
            HorizontalLayoutGroup layout = Instantiate(HorizontalLayout) as HorizontalLayoutGroup;

            layout.GetComponent<RectTransform>().SetParent(VerticalLayout.transform, false);

            _horizontalLayoutList.Add(layout);
        }

        IEnumerator DisplayWithDelay()
        {
            int i = 0;

            foreach (Transform t in VerticalLayout.transform)
            {
                _decreasedDelay = Delay;
                foreach (Transform tt in t)
                {
                    tt.gameObject.SetActive(true);
                    if (!_isSkipped)
                    {
                        AudioManagerScript.Instance.Play(Sound, Camera.main.transform, 0.15f);
                        yield return new WaitForSeconds(_isSkipped ? 0.0f : _decreasedDelay);
                    }
                    _decreasedDelay -= 0.05f;
                    _decreasedDelay = _decreasedDelay <= 0.0f ? 0.05f : _decreasedDelay;
                }

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
                LevelStatus.text = "Have you done the tutorial?";
            }
            else
            {
                AudioManagerScript.Instance.Play(WinMusic, Camera.main.transform, 0.4f);
                LevelStatus.text = "Level complete!";
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
