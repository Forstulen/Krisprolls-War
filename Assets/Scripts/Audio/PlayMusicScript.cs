using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class PlayMusicScript : MonoBehaviour
    {

        public AudioClip Music;

        // Use this for initialization
        void Start()
        {
            AudioManagerScript.Instance.PlayMusic(Music, 1.0f);
        }
    }
}
