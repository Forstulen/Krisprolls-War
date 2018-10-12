using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{

    public class TowerStatsButtonScript : MonoBehaviour
    {
        public TowerType Type;

        //public Text Title;
        public Text Price;

        public void OnEnable()
        {
            //Title.text = TowerManagerScript.Instance.GetNameTower(Type);
            Price.text = TowerManagerScript.Instance.GetPriceTower(Type).ToString();
        }
    }

}