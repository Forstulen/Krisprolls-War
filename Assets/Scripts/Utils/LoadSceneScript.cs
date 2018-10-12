using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

    public string MenuName;

    public void LoadScene() {
        SceneManager.LoadScene(MenuName);
    }
}
