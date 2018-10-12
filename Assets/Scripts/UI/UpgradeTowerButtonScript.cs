using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class UpgradeTowerButtonScript : MonoBehaviour
    {
        public void UpgradeTower() {
            TowerManagerScript.Instance.UpgradeTower();
        }
    }
}
