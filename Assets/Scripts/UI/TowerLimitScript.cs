using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class TowerLimitScript : MonoBehaviour
    {
        public CanvasGroup      CanvasGroup;
        public Text             LimitText;
        public TowerType        Type;

        private const string    TOWER_STRING = "{0} left";

        private void OnEnable()
        {
            int left = LevelManagerScript.Instance.GetLevel(GameManagerScript.Instance.CurrentLevel).GetTowerLimit(Type) - TowerManagerScript.Instance.GetBuildTowerNumber(Type);

            if (left == 0) {
                CanvasGroup.alpha = 0.5f;
                LimitText.text = string.Format(TOWER_STRING, left);
            } else if (left <= 10) {
                CanvasGroup.alpha = 1.0f;
                LimitText.text = string.Format(TOWER_STRING, left);
            } else {
                CanvasGroup.alpha = 0.0f;
            }
        }

    }
}
