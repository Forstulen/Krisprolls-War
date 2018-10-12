using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class DestroyTowerButtonScript : MonoBehaviour
    {
        public void DestroyTower()
        {
            TowerManagerScript.Instance.DestroyTower();
        }
    }
}
