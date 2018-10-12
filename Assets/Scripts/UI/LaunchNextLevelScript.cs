using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class LaunchNextLevelScript : MonoBehaviour
    {
        public LoadingTextScript LoadingScreen;
        public Button NextLevelButton;

        private string levelName;

        private void Start()
        {
            levelName = GameManagerScript.Instance.GetNextLevelName();

            if (levelName == "") {
                NextLevelButton.interactable = false;
            }
        }

        public void LaunchNextLevel()
        {
            LoadingScreen.SceneName = levelName;

            LoadingScreen.LaunchScene();
        }
    }

}