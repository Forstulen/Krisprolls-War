using UnityEngine;

namespace TowerDefense {
    public class DragonFlightScript : MonoBehaviour {

        public AudioClip DragonSound;

        void DestroyTower() {
            TowerManagerScript.Instance.DestroyTowers(true);
        }

        void PlaySound() {
            _ = AudioManagerScript.Instance.Play(DragonSound, Camera.main.transform, 0.3f);
        }

        void DestroyDragon() {
            GameObject.Destroy(gameObject);
        }
    }
}
