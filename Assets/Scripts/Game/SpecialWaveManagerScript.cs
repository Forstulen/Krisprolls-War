using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class SpecialWaveManagerScript : SingletonScript<SpecialWaveManagerScript>
    {
        public GameObject DragonFlightObject;
        public GameObject Grid;

        public void ApplySpecialEffect(SpecialWave type) {
            switch (type) {
                case SpecialWave.DRAGON:
                    ApplyDragonEffect();
                    break;
                default:
                    break;
            }
        }

        private void ApplyDragonEffect() {
            GameObject gameObject = Object.Instantiate(DragonFlightObject);
            gameObject.SetActive(true);
            gameObject.transform.parent = Grid.transform;
        }
    }

}