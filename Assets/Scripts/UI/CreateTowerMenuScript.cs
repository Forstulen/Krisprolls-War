using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class CreateTowerMenuScript : MonoBehaviour
    {

        public CreateTowerButtonScript[] Buttons;
        private bool _ShouldCheckButtons;

        private void OnEnable()
        {
            _ShouldCheckButtons = true;
        }

        private void OnDisable()
        {
            _ShouldCheckButtons = false;
        }

        private void Update()
        {
            if (_ShouldCheckButtons)
                SetButtons();
        }


        private void SetButtons() {
            foreach (CreateTowerButtonScript script in Buttons)
            {
                TowerType type = script.TowerType;

                UnityEngine.UI.Button b = script.gameObject.GetComponent<UnityEngine.UI.Button>();

                b.interactable = GameManagerScript.Instance.CanCreateTower(type);
            }
        }
    }
}
