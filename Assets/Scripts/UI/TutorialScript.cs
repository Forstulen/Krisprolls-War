using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    
    public class TutorialScript : MonoBehaviour
    {
        public enum TutorialStep
        {
            INITIAL = 0,
            FIRST_STEP,
            SECOND_STEP,
            THIRD_STEP,
            FOURTH_STEP,
            FIFTH_STEP,
            SIXTH_STEP,
            SEVENTH_STEP,
            FINAL_STEP
        }

        public float            InitialDelay = 2.0f;
        public GameObject       CreateMenuPanel;
        public GameObject       ModifyMenuPanel;
        public GameObject       FirstPanel;
        public MenuTileScript   FirstTile;
        public GameObject       SecondPanel;
        public GameObject       ThirdPanel;
        public GameObject       FourthPanel;
        public GameObject       FifthPanel;
        public MenuTileScript   FifthTile;
        public GameObject       SixthPanel;
        public MenuTileScript   SixthTile;
        public GameObject       SeventhPanel;
        public MenuTileScript   SeventhTile;
        public GameObject       LastPanel;

        public Button           MonoButton;
        public Button           AOEButton;
        public Button           PoisonButton;
        public Button           FrostButton;
        public Button           BreakButton;
        public Button           UpgradeButton;
        public Button           DestroyButton;

        private TutorialStep    _currentStep;
        private float           _time;

        // Use this for initialization
        void Start()
        {
            GameManagerScript.Instance.GameFinished += FinishTutorial;

            _currentStep = TutorialStep.INITIAL;

            LaunchNewStep(_currentStep + 1);
        }

        IEnumerator StartTutorial()
        {
            InputManagerScript.Instance.SetInteraction(false);
            yield return new WaitForSeconds(InitialDelay);
            FirstPanel.SetActive(true);
        }

        void FinishTutorial() {
            LaunchNewStep(TutorialStep.FINAL_STEP);
        }

        public void LaunchNewStep(TutorialStep step)
        {
            Debug.Log("new STEP");
            if (IsValidNextStep(step))
            {
                _currentStep = step;
                switch (_currentStep)
                {
                    case TutorialStep.FIRST_STEP:
                        StartCoroutine(StartTutorial());
                        break;
                    case TutorialStep.SECOND_STEP:
                        GameManagerScript.Instance.PauseGameForTutorial();
                        SecondPanel.SetActive(true);

                        FirstTile.Clicked();

                        CreateMenuPanel.SetActive(true);

                        MonoButton.interactable = true;
                        BreakButton.interactable = false;
                        AOEButton.interactable = false;
                        FrostButton.interactable = false;
                        PoisonButton.interactable = false;

                        break;
                    case TutorialStep.THIRD_STEP:
                        GameManagerScript.Instance.CreateRewardEvent += CreateRewardEvent;
                        GameManagerScript.Instance.ClaimRewardEvent += ClaimRewardEvent;
                        break;
                    case TutorialStep.FOURTH_STEP:
                        GameManagerScript.Instance.PauseGameForTutorial();
                        FourthPanel.SetActive(true);
                        ModifyMenuPanel.SetActive(true);

                        FirstTile.Clicked();


                        UpgradeButton.interactable = true;
                        DestroyButton.interactable = false;
                        break;
                    case TutorialStep.FIFTH_STEP:
                        GameManagerScript.Instance.PauseGameForTutorial();
                        FifthPanel.SetActive(true);

                        FifthTile.Clicked();

                        MonoButton.interactable = false;
                        BreakButton.interactable = false;
                        AOEButton.interactable = true;
                        FrostButton.interactable = false;
                        PoisonButton.interactable = false;
                        break;
                    case TutorialStep.SIXTH_STEP:
                        GameManagerScript.Instance.PauseGameForTutorial();
                        SixthPanel.SetActive(true);

                        SixthTile.Clicked();

                        MonoButton.interactable = false;
                        BreakButton.interactable = false;
                        AOEButton.interactable = false;
                        FrostButton.interactable = true;
                        PoisonButton.interactable = false;

                        break;
                    case TutorialStep.SEVENTH_STEP:
                        GameManagerScript.Instance.PauseGameForTutorial();
                        SeventhPanel.SetActive(true);

                        SeventhTile.Clicked();

                        MonoButton.interactable = false;
                        BreakButton.interactable = false;
                        AOEButton.interactable = false;
                        FrostButton.interactable = false;
                        PoisonButton.interactable = true;

                        //TowerManagerScript.Instance.SetPotentialPosition(new Vector3(-1.5f, 3.5f, 0.0f));
                        break;
                    case TutorialStep.FINAL_STEP:
                        LastPanel.SetActive(true);

                        Time.timeScale = 1.0f;

                        //TowerManagerScript.Instance.SetPotentialPosition(new Vector3(-1.5f, 3.5f, 0.0f));
                        break;
                    default:
                        break;
                }
            }
        }

        bool IsValidNextStep(TutorialStep step) {
            return step == _currentStep + 1;
        }

        void CreateRewardEvent()
        {
            ThirdPanel.SetActive(true);

            GameManagerScript.Instance.PauseGameForTutorial();

            InputManagerScript.Instance.SetInteraction(true);
        }

        void ClaimRewardEvent() {
            ValidStep();
        }


        public void ValidStep() {
            switch (_currentStep)
            {
                case TutorialStep.FIRST_STEP:
                    break;
                case TutorialStep.SECOND_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    SecondPanel.SetActive(false);

                    LaunchNewStep(TutorialStep.THIRD_STEP);
                    break;
                case TutorialStep.THIRD_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    ThirdPanel.SetActive(false);

                    GameManagerScript.Instance.CreateRewardEvent -= CreateRewardEvent;
                    GameManagerScript.Instance.ClaimRewardEvent -= ClaimRewardEvent;
                    break;
                case TutorialStep.FOURTH_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    FourthPanel.SetActive(false);
                    break;
                case TutorialStep.FIFTH_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    FifthPanel.SetActive(false);
                    break;
                case TutorialStep.SIXTH_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    InputManagerScript.Instance.SetInteraction(true);

                    SixthPanel.SetActive(false);
                    break;
                case TutorialStep.SEVENTH_STEP:
                    GameManagerScript.Instance.PauseGameForTutorial();

                    InputManagerScript.Instance.SetInteraction(true);

                    SeventhPanel.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}