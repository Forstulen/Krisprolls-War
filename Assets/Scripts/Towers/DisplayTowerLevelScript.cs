using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Tower))]
    public class DisplayTowerLevelScript : MonoBehaviour
    {
        public Transform                RootTransform;
        public Vector3                  Offset;
        public Vector3                  MaximumSize;
        public Sprite                   EmptyLevelSprite;
        public Sprite                   FilledLevelSprite;
        public string                   SortingLayerName;
        public int                      SortingLayer;

        private Tower                   _towerScript;
        private List<SpriteRenderer>    _rendererList;
        private bool                    _isInitialized = false;

        // Use this for initialization
        void Start()
        {
            if (!_isInitialized)
                InitializeSprites();
            DisplayLevel();
        }

        private void InitializeSprites() {
            _isInitialized = true;
            _towerScript = GetComponent<Tower>();
            _rendererList = new List<SpriteRenderer>();

            int level           = (int)_towerScript.GetLevel();
            int maxLevel        = (int)_towerScript.GetMaxLevel();
            float xOffset       = Offset.x / (maxLevel - 1);

            for (int i = 0; i < maxLevel; ++i) {
                GameObject go = new GameObject();
                go.AddComponent<SpriteRenderer>();

                SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();

                spriteRenderer.sprite = EmptyLevelSprite;
                spriteRenderer.sortingLayerName = SortingLayerName;
                spriteRenderer.sortingOrder = SortingLayer;
                _rendererList.Add(spriteRenderer);

                go.transform.parent = RootTransform;
                go.transform.localScale = new Vector3((MaximumSize.x - xOffset * (maxLevel - 1)) / (float)maxLevel, MaximumSize.y, 0.0f);
                go.transform.localPosition = new Vector3((MaximumSize.x / (float)maxLevel + xOffset) * 
                                                         (i - Mathf.Round(maxLevel / 2) + 
                                                          (maxLevel % 2 == 0 ? ((MaximumSize.x - xOffset * (maxLevel - 1)) / (float)maxLevel) / 2.0f: 0.0f)), 0f, 0.0f);
            }
        }

        public void DisplayLevel() {
            if (!_isInitialized)
                InitializeSprites();

            for (int i = 0; i < (int)_towerScript.GetMaxLevel(); ++i) {
                if (i <= (int)_towerScript.GetLevel() - 1) {
                    _rendererList[i].sprite = FilledLevelSprite;
                } else {
                    _rendererList[i].sprite = EmptyLevelSprite;
                }
            }
        }

    }
}
