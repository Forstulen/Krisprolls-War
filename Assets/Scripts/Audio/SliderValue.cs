using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {


    public Text sliderText;
    public Slider slider;
    public string prefix;

    void Update()
    {
        sliderText.text = prefix + slider.value.ToString() + " / " + slider.maxValue;
     }
}