using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenScript : MonoBehaviour {

    private bool loadScene = false;

    [SerializeField]
    private string SceneName;
    [SerializeField]
    private Text loadingText;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private GameObject hintBlock;

    public void LaunchNewScene() {
        loadScene = true;
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        startButton.gameObject.SetActive(false);
        hintBlock.gameObject.SetActive(true);

        StartCoroutine(LoadNewScene());
    }

    private void Update()
    {
        if (loadScene)
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);

        while (!async.isDone)
        {
            yield return null;
        }

    }
}
