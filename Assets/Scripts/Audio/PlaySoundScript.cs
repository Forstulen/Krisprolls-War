using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class PlaySoundScript : MonoBehaviour
    {

        public AudioClip Clip;
        public float VolumeCoeff = 1.0f;

        private void OnEnable()
        {
            AudioManagerScript.Instance.Play(Clip, Camera.main.transform, VolumeCoeff);
        }
    }
}
