﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    
    public GameObject       MenuPanel;
    public GameObject       OptionsPanel;
    public GameObject       LevelPanel;
    public GameObject       LorePanel;
    public Button           LoreButton;
    public Image            OverlayImage;

    private bool            _displayOverlay;
    private float           _time;

    const float             _delay = 0.5f;

    public void PlayBtn ()
    {
        _time = 0.0f;
        _displayOverlay = true;
        MenuPanel.SetActive(false);
        LevelPanel.SetActive(true);
        LorePanel.SetActive(false);
        LoreButton.gameObject.SetActive(false);
    }

    public void BackBtn()
    {
        _time = 0.0f;
        _displayOverlay = false;
        MenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        LevelPanel.SetActive(false);
        LorePanel.SetActive(false);
        LoreButton.gameObject.SetActive(true);
    }

    public void OptionsBtn(string Play)
    {
        _time = 0.0f;
        OverlayImage.color = new Color(0, 0, 0, 0.0f);
        _displayOverlay = true;
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        LorePanel.SetActive(false);
        LoreButton.gameObject.SetActive(false);
    }

    public void LoreBtn()
    {
        _time = 0.0f;
        _displayOverlay = false;
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        LevelPanel.SetActive(false);
        LorePanel.SetActive(true);
        LoreButton.gameObject.SetActive(false);
    }

    public void ExitBtn (string Exit)
    {
        Application.Quit();
    }

    private void Update()
    {
        OverlayImage.gameObject.SetActive(_displayOverlay);

        if (_displayOverlay) {
            OverlayImage.color = Color.Lerp(OverlayImage.color, new Color(0, 0, 0, 0.25f), _time);

            _time += Time.deltaTime / _delay;
        } else {
            OverlayImage.color = Color.Lerp(OverlayImage.color, new Color(0, 0, 0, 0.0f), _time);

            _time += Time.deltaTime / _delay;
        }
    }
}
