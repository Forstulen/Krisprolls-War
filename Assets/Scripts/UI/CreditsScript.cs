using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class CreditsScript : MonoBehaviour
    {
        public Button       RestartButton;
        public Button       CreditsButton;
        public Button       NextButton;

        private void OnEnable()
        {
            string levelName = GameManagerScript.Instance.GetNextLevelName();

            CreditsButton.gameObject.SetActive(false);
            RestartButton.gameObject.SetActive(true);

            if (levelName == "CREDITS") {
                CreditsButton.gameObject.SetActive(true);
                RestartButton.gameObject.SetActive(false);
                NextButton.interactable = false;
            }
        }
    }
}
