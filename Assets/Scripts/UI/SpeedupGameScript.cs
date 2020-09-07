using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class SpeedupGameScript : UIPresser
    {
        void Update()
        {
            if (Pressed)
                GameManagerScript.Instance.SpeedUpGame();
            else
                GameManagerScript.Instance.NormalSpeedGame();
        }
    }
}