using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class InitializeSliderScript : MonoBehaviour
    {
        public Slider   MusicSlider;
        public Slider   SoundSlider;

        public void OnEnable()
        {
            MusicSlider.value = UserPropertiesModel.Instance.MusicVolume;
            SoundSlider.value = UserPropertiesModel.Instance.SoundVolume;
        }
    }
}
