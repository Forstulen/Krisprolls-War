using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class ModifyTowerMenuScript : MonoBehaviour
    {

        public Button   UpgradeButton;
        public Text     TowerLevelText;

        private bool _ShouldCheckButtons;

        private const string LEVEL = "LEVEL ";

        private void OnEnable()
        {
            UpgradeButton.gameObject.SetActive(false);
            _ShouldCheckButtons = true;
  
            Tower t = TowerManagerScript.Instance.GetCurrentTower();

            if (t) {
                TowerLevel level = t.GetLevel();
                TowerLevelText.text = LEVEL + (level == TowerLevel.LEVEL_MAX ? "MAX" : ((int)level).ToString());
            }
        }

        private void OnDisable()
        {
            UpgradeButton.gameObject.SetActive(false);
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
