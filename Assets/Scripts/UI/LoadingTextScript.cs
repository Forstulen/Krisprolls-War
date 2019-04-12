using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TowerDefense
{

    public class LoadingTextScript : MonoBehaviour
    {

        public Text LoadingText;
        public GameObject TitleImage;
        public Image BackgroundImage;
        public AudioSource MenuMusic;
        public string SceneName;
        private bool _loadScene = false;
        private float _time;

        public void Initialize()
        {
            _loadScene = true;
            _time = 0;
            BackgroundImage.color = new Color(0, 0, 0, 0.0f);
            TitleImage.SetActive(false);
            LoadingText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_loadScene)
            {
                if (MenuMusic != null)
                    MenuMusic.volume = Mathf.InverseLerp(MenuMusic.volume, 0.0f, _time / 1.0f);
                else
                    StartCoroutine(AudioManagerScript.Instance.PauseMusicWithFadeOut());
                
                BackgroundImage.color = Color.Lerp(BackgroundImage.color, Color.black, _time / 0.75f);

                if (BackgroundImage.color == Color.black)
                {
                    TitleImage.SetActive(true);
                    LoadingText.gameObject.SetActive(true);
                    LoadingText.color = new Color(LoadingText.color.r, LoadingText.color.g, LoadingText.color.b, Mathf.PingPong(Time.time, 1));
                }

                _time += Time.deltaTime;
            }
        }

        public void LaunchScene()
        {
            StartCoroutine(LoadNewScene());
        }

        IEnumerator LoadNewScene()
        {
            yield return new WaitForSeconds(1.0f);

            AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);

            while (!async.isDone)
            {
                yield return null;
            }

        }
    }
}
