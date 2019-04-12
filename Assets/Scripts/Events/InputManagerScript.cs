using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefense
{

    public class InputManagerScript : SingletonScript<InputManagerScript>
    {
        //Events
        public delegate void OnMenuAction(TowerType t);
        public event OnMenuAction       StartShowingTiles;
        public event OnMenuAction       StopShowingTiles;

        private const string            TILE_MASK = "InteractableTile";
        private const string            CLICKABLE_MASK = "Clickable";
        private ClickableTileScript     _SavedLastClickableScript;
        private bool                    _interactionEnabled = true;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonUp(0) && _interactionEnabled && GameManagerScript.Instance.CanBeInteractive())
            {
                //OPEN TOWER MENU
                if (EventSystem.current.IsPointerOverGameObject() && _SavedLastClickableScript) {
                    _SavedLastClickableScript.ClickedIsDone();

                    _SavedLastClickableScript = null;
                } else {
                    LayerMask mask = LayerMask.GetMask(TILE_MASK);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, mask);

                    if (hit.collider != null)
                    {
                        if (_SavedLastClickableScript)
                        {
                            _SavedLastClickableScript.ClickedIsDone();
                        }

                        _SavedLastClickableScript = hit.collider.GetComponent<ClickableTileScript>();

                        _SavedLastClickableScript.Clicked();
                    }
                    else
                    {
                        if (_SavedLastClickableScript)
                        {
                            _SavedLastClickableScript.ClickedIsDone();
                        }

                        _SavedLastClickableScript = null;
                    }  
                }
                //*******************
            }
        }

        //private void CheckClickable() {
        //    LayerMask clickmask = LayerMask.GetMask(CLICKABLE_MASK);
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, clickmask);

        //    if (hit.collider != null) {
        //        hit.collider.gameObject.SendMessage("OnMouseDown");
        //    }
        //}

        public void SetInteraction(bool interaction) {
            _interactionEnabled = interaction;
        }

        public void ShowTiles(TowerType t) {
            if (StartShowingTiles != null)
                StartShowingTiles(t);
        }

        public void HideTiles()
        {
            if (StopShowingTiles != null)
                StopShowingTiles(TowerType.UNKNOWN);
        }
    }
}
