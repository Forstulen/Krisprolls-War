using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TriggerEventScript : MonoBehaviour
    {

        public TutorialScript.TutorialStep  Step;
        public TutorialScript               TutorialScript;
        public int WaveNumberCondition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (WaveNumberCondition == -1 || WaveNumberCondition == GameManagerScript.Instance.GetWaves())
                TutorialScript.LaunchNewStep(Step);
        }
    }
}
