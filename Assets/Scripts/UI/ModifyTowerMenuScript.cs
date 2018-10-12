using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class ModifyTowerMenuScript : MonoBehaviour
    {

        public Button   UpgradeButton;

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


        private void SetButtons()
        {
            UpgradeButton.gameObject.SetActive(GameManagerScript.Instance.CanUpgradeTower());
        }

    }
}
