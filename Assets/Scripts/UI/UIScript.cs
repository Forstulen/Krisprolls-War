using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class UIScript : MonoBehaviour
    {
        public GameObject GameStatusPanel;

        // Use this for initialization
        void Start()
        {
            GameManagerScript.Instance.GameFinished += GameFinished;
    
        }

        void GameFinished()
        {
            GameStatusPanel.SetActive(true);
        }

    }

}
