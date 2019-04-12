using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

namespace TowerDefense
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MenuTileScript : ClickableTileScript
    {
        public  string          SortingLayerName;

        private RectTransform   _CreateMenuPanel;
        private RectTransform   _ModifyMenuPanel;
        private Canvas          _CreateMenuCanvas;
        private Vector3Int      _tilePosition;
        private SpriteRenderer  _renderer;
        private bool            _isActive;

        private Color           _initialColor;
        private Color           _displayColor;

        private const string    CREATE_MENU_PANEL_NAME = "CreateTowerMenu";
        private const string    MODIFY_MENU_PANEL_NAME = "ModifyTowerMenu";
        private const string    CANVAS_PANEL_NAME = "CreateTowerCanvas";

        private TowerType _towerType;

        private void Start()
        {
            _CreateMenuCanvas = GameObject.Find(CANVAS_PANEL_NAME).GetComponent<Canvas>();
            _CreateMenuPanel = _CreateMenuCanvas.transform.Find(CREATE_MENU_PANEL_NAME).GetComponent<RectTransform>();
            _ModifyMenuPanel = _CreateMenuCanvas.transform.Find(MODIFY_MENU_PANEL_NAME).GetComponent<RectTransform>();
            _renderer = GetComponent<SpriteRenderer>();

            _initialColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            _displayColor = new Color(1.0f, 1.0f, 1.0f, 0.15f);

            InputManagerScript.Instance.StartShowingTiles += ShowTile;
            InputManagerScript.Instance.StopShowingTiles += HideTile;

            Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
            _tilePosition = tilemap.WorldToCell(transform.position);

            if (_CreateMenuPanel == null || _CreateMenuCanvas == null || _ModifyMenuPanel == null)
                throw new System.Exception("MenuTileScript: NO SUITABLE CREATETOWERMENU");
        }

        void OnSelectTower(TowerType t)
        {
            _isActive = true;
            _towerType = t;
        }

        //private void Update()
        //{
        //    if (_isActive) {
        //        _renderer.color = Color.Lerp(_initialColor, _displayColor, Mathf.PingPong(Time.time, 1));
        //    }
        //}

        public void ActivateCreateMenu()
        {
            _CreateMenuPanel.gameObject.SetActive(true);
        }

        public void DeactivateCreateMenu()
        {
            _CreateMenuPanel.gameObject.SetActive(false);
        }

        public void ActivateModifyMenu()
        {
            _ModifyMenuPanel.gameObject.SetActive(true);
        }

        public void DeactivateModifyMenu()
        {
            _ModifyMenuPanel.gameObject.SetActive(false);
        }

        public override void Clicked() {
            TowerManagerScript.Instance.SetPotentialPosition(GetTowerPosition());
            TowerManagerScript.Instance.SetSortingLayer(SortingLayer.NameToID(SortingLayerName));

            Debug.Log("Clicked Tile");

            if (CanBuild()) {
                //ADD 0.5f to reach the center
                Vector2 myPositionOnScreen = Camera.main.WorldToScreenPoint(new Vector3(_tilePosition.x + 1.1f, _tilePosition.y + 1.0f, 0.0f));
                Vector2 finalPosition = new Vector2(myPositionOnScreen.x, myPositionOnScreen.y);
                _CreateMenuPanel.position = finalPosition;

                DeactivateModifyMenu();
                ActivateCreateMenu();    
            } else {
                //ADD 0.5f to reach the center
                Vector2 myPositionOnScreen = Camera.main.WorldToScreenPoint(new Vector3(_tilePosition.x + 1.1f, _tilePosition.y + 1.0f, 0.0f));
                Vector2 finalPosition = new Vector2(myPositionOnScreen.x, myPositionOnScreen.y);
                _ModifyMenuPanel.position = finalPosition;

                TowerManagerScript.Instance.DisplayTowerRange();

                DeactivateCreateMenu();
                ActivateModifyMenu(); 
            }

            _isActive = true;
        }

        private void ShowTile(TowerType t)
        {
            _isActive = true;
            _towerType = t;
        }

        private void HideTile(TowerType t) {
            _isActive = false;

            _renderer.color = _initialColor;
        }

        //public override void Clicked()
        //{
        //    TowerManagerScript.Instance.SetPotentialPosition(GetTowerPosition());

        //    if (CanBuild() && _isActive)
        //    {
        //        _isActive = false;

        //        GameManagerScript.Instance.CreateTower(_towerType);
        //    } else if (!CanBuild()) {
        //        TowerManagerScript.Instance.DisplayTowerRange();

        //        ActivateModifyMenu();
        //    }



        //    InputManagerScript.Instance.HideTiles();
        //}

        public override void ClickedIsDone()
        {
            DeactivateCreateMenu();

            _renderer.color = _initialColor;

            _isActive = false;

            DeactivateCreateMenu();
            DeactivateModifyMenu();

            TowerManagerScript.Instance.HideTowerRange();
        }

        private bool CanBuild() {
            return TowerManagerScript.Instance.CanBuildTower(GetTowerPosition());
        }

        private Vector3 GetTowerPosition() {
            return new Vector3(_tilePosition.x + 0.5f, _tilePosition.y + 0.5f, 0.0f);
        }
    }
}
