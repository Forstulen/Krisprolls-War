using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnimationScript : MonoBehaviour {

    public Animator TitleAnimator;
    public Animator MenuAnimator;
    public Button   TitleButton;

    public string Key = "ShowMenu";


    public void DisplayMenu() {
        TitleAnimator.SetBool(Key, true);
        MenuAnimator.SetBool(Key, true);

        TitleButton.interactable = false;
    }
}
