using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TowerDefense
{

    public class LevelSelectionPanelScript : MonoBehaviour
    {
        public Text     LevelName;
        public Button   PlayButton;
        public int      LevelNumber;
        public Image    LevelImage;
        public LoadingTextScript LoadingTextScript;
        public ScrollSnapRect ParentScript;

        public void InitializeLevelSelection() {
            LevelModel model = LevelManagerScript.Instance.GetLevel((Level)LevelNumber);

            LevelImage.color = model.IsUnlocked() ? LevelImage.color : new Color(0.5f, 0.5f, 0.5f, 0.8f);
            LevelName.text = model.IsUnlocked() ? model.GetLevelName() : "LOCKED";
            LevelImage.sprite = Resources.Load<Sprite>(model.GetLevelName());
        }

        public void LaunLevel() {
            if (LevelManagerScript.Instance.GetLevel((Level)ParentScript.GetCurrentSlider()).IsUnlocked())
            {
                LoadingTextScript.gameObject.SetActive(true);
                LoadingTextScript.Initialize();

                StartCoroutine(LoadNewScene());
            }
        }

        IEnumerator LoadNewScene()
        {
            yield return new WaitForSeconds(1.5f);

            AsyncOperation async = SceneManager.LoadSceneAsync(LevelManagerScript.Instance.GetLevel((Level)ParentScript.GetCurrentSlider()).GetLevelName());

            while (!async.isDone)
            {
                yield return null;
            }

        }
    }

}
