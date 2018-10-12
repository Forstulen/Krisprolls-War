using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class CreateLevelSelectionMenuScript : MonoBehaviour
    {
        public GameObject           LevelPanel;
        public ScrollSnapRect       ParentScript;
        public LoadingTextScript    LoadingTextScript;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < LevelManagerScript.Instance.GetLevelNumber(); ++i) {
                GameObject go = (GameObject)Instantiate(LevelPanel, transform);

                LevelSelectionPanelScript script = go.GetComponent<LevelSelectionPanelScript>();

                script.LevelNumber = i;
                script.LoadingTextScript = LoadingTextScript;
                script.ParentScript = ParentScript;
                script.InitializeLevelSelection();
            }

            ParentScript.Initialize();
        }

    }
}
