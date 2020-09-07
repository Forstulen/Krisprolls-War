using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class SpecialWaveManagerScript : SingletonScript<SpecialWaveManagerScript>
    {
        public void ApplySpecialEffect(SpecialWave type) {
            switch (type) {
                case SpecialWave.NUCLEAR:
                    ApplyNuclearEffect();
                    break;
                default:
                    break;
            }
        }

        private void ApplyNuclearEffect() {
            TowerManagerScript.Instance.DestroyTowers(true);
        }
    }

}