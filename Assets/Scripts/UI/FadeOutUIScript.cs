using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Image))]
    public class FadeOutUIScript : MonoBehaviour
    {
        Image   _fadeImage;
        Color   _transparentColor;
        float   _time;

        // Use this for initialization
        void Start()
        {
            _fadeImage = GetComponent<Image>();
            _transparentColor = new Color(0, 0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            _fadeImage.color = Color.Lerp(_fadeImage.color, _transparentColor, _time);
            _time += Time.deltaTime / 1.0f;

            if (_fadeImage.color == _transparentColor)
                _fadeImage.gameObject.SetActive(false);
        }
    }
}
