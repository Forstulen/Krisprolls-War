using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class ActivateTileTowerScript : MonoBehaviour
    {
        public TowerType Type;

        private Button _towerButton;

        public void OnEnable()
        {
            _towerButton = GetComponent<Button>();
        }

        public void CreateTower() {
            GameManagerScript.Instance.CreateTower(Type);
        }

        public void Update()
        {
            if (GameManagerScript.Instance.CanBeInteractive())
                _towerButton.interactable = GameManagerScript.Instance.CanCreateTower(Type);
        }
    }
}
