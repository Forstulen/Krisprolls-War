using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class CreateTowerButtonScript : MonoBehaviour
    {

        public TowerType    TowerType;

        public void CreateTower() {
            GameManagerScript.Instance.CreateTower(TowerType);
        }
    }
}