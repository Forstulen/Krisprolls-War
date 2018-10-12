using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class GameManagerScript : SingletonScript<GameManagerScript>
    {
        //Events
        public delegate void OnGameEvent();
        public event OnGameEvent GameStarted;
        public event OnGameEvent CreateRewardEvent;
        public event OnGameEvent ClaimRewardEvent;
        public event OnGameEvent GameFinished;

        //Attributes
        public Level        CurrentLevel;
        public AudioClip    MusicLevel;
        public AudioClip    ExtraGold;
        public AudioClip    WalkSound;
        public Canvas       PauseCanvas;
        public float        Delay = 5.0f;

        [SerializeField]
        private float   _elapsedTime;
        [SerializeField]
        private int     _currentWave;
        [SerializeField]
        private int     _spawnedEnemies;
        [SerializeField]
        private int     _killedEnemies;
        [SerializeField]
        private int     _escapedEnemies;
        [SerializeField]
        private bool    _waveIsFinished;
        private bool    _isGameStarted;
        private bool    _canLaunchWave;
        private bool    _gameFinished;

        [SerializeField]
        private int     _golds;
        [SerializeField]
        private int     _currentLives;

        private Vector3 _lastKilledEnemyPosition;

        private List<EnemyType> _killedEnemiesList;

        private bool    _isPaused;

        private AudioSource _footstepSource;

        private void Start()
        {
            EnemyManagerScript.Instance.EnemySpawning += AddSpawnedEnemy;
            EnemyManagerScript.Instance.EnemyKilling += AddKilledEnemy;
            EnemyManagerScript.Instance.EnemySurviving += AddSurvivedEnemy;

            _isGameStarted = false;
            _isPaused = false;

            _killedEnemiesList = new List<EnemyType>();
        }

        private void Update()
        {
            if (!_isGameStarted && _elapsedTime >= Delay && !_gameFinished && CurrentLevel != Level.TUTORIAL && CurrentLevel != Level.ADJUSTEMENT) {
                LaunchLevel();
            }

            if (IsWaveFinished() && _isGameStarted && _canLaunchWave) {
                _footstepSource.Pause();
                if (_escapedEnemies == 0)
                {
                    if (CreateRewardEvent != null)
                        CreateRewardEvent();
                    
                    RewardManagerScript.Instance.CreateReward(RewardType.CHEST, LevelManagerScript.Instance.GetWave(CurrentLevel, _currentWave)._ExtraReward, _lastKilledEnemyPosition);
                    AudioManagerScript.Instance.Play(ExtraGold, transform, 0.5f);
                }
                _waveIsFinished = false;
                _currentWave++;
                InitializeWave();
                StartCoroutine(LaunchDelayedWave());
            }
            _elapsedTime += Time.deltaTime;
        }

        private void InitializeWave() {
            _elapsedTime = 0.0f;
            _spawnedEnemies = 0;
            _killedEnemies = 0;
            _escapedEnemies = 0;
            _waveIsFinished = false;
            _canLaunchWave = false;
        }

        public void PauseGame() {

            PauseGameForTutorial();

            PauseCanvas.gameObject.SetActive(_isPaused);
        }

        public void PauseGameForTutorial() {
            if (_isPaused)
            {
                Debug.Log("UnPauseGame");
                Time.timeScale = 1.0f;
                StartCoroutine(AudioManagerScript.Instance.UnPauseMusicWithFadeIn());
                AudioManagerScript.Instance.UnpauseFX();
            }
            else
            {
                Debug.Log("PauseGame");
                Time.timeScale = 0.0f;
                StartCoroutine(AudioManagerScript.Instance.PauseMusicWithFadeOut());
                AudioManagerScript.Instance.PauseFX();
            }

            _isPaused = !_isPaused;
        }

        public string GetNextLevelName() {
            LevelModel model = LevelManagerScript.instance.GetNextLevel(CurrentLevel);

            if (model == null || !model.IsUnlocked())
                return "";

            return model.GetLevelName();
        }

        public void QuitGame() {
            Time.timeScale = 1.0f;

            StartCoroutine(AudioManagerScript.Instance.PauseMusicWithFadeOut());
            AudioManagerScript.Instance.PauseFX();

            EnemyManagerScript.Instance.DestroyEnemies();
            TowerManagerScript.Instance.DestroyTowers();

        }

        public void RestartGame() {
            Time.timeScale = 1.0f;

            EnemyManagerScript.Instance.DestroyEnemies();
            TowerManagerScript.Instance.DestroyTowers();

            StartCoroutine(AudioManagerScript.Instance.UnPauseMusicWithFadeIn());
            AudioManagerScript.Instance.UnpauseFX();

            LaunchLevel();
        }

        private void AddSpawnedEnemy(Enemy e) {
            _spawnedEnemies++;

            _canLaunchWave = true;

            if (_footstepSource == null) {
                _footstepSource = AudioManagerScript.Instance.PlayLoop(WalkSound, Camera.main.transform, 0.1f);
            } else if (!_footstepSource.isPlaying) {
                _footstepSource.Play();
            }
        }

        private void AddKilledEnemy(Enemy e)
        {
            _lastKilledEnemyPosition = e.transform.position;

            _killedEnemies++;
            AddGolds(e);

            _killedEnemiesList.Add(e.GetEnemyType());
        }

        private void AddSurvivedEnemy(Enemy e)
        {
            _escapedEnemies++;
            DecreaseLives();
        }

        public bool CanCreateTower(TowerType type) {
            return TowerManagerScript.Instance.GetPriceTower(type) <= _golds;
        }

        public void CreateTower(TowerType type)
        {
            int goldsTower = TowerManagerScript.Instance.GetPriceTower(type);

            if (_golds >= goldsTower)
            {
                TowerManagerScript.Instance.CreateTower(type);
                _golds -= goldsTower;
            } else {
                Debug.Log("Pas assez d'argent");

            }
        }

        public void DestroyTower()
        {
            
            int goldsTower = TowerManagerScript.Instance.GetPriceTower(TowerManagerScript.Instance.GetCurrentTower().GetTowerType());

            TowerManagerScript.Instance.DestroyTower();
            _golds += goldsTower / 2;

            // On regarde la position de la tour
            // Si il y en a une on la desactive
            // On rajoute aux golds la moitié de son coût
        }

        public bool CanUpgradeTower() {
            return TowerManagerScript.Instance.GetCurrentTower().CanBeUpgraded() && TowerManagerScript.Instance.GetCurrentTower().GetCurrentPrice() <= _golds;
        }

        public void UpgradeTower()
        {
            // Le prix de la tour * 2
            TowerManagerScript.Instance.GetCurrentTower().HideRange();

            int PriceUpgrade = TowerManagerScript.Instance.GetCurrentTower().GetCurrentPrice();

            Debug.Log(_golds + " " + PriceUpgrade);

            if (_golds >= PriceUpgrade)
            {
                TowerManagerScript.Instance.UpgradeTower();
                _golds -= PriceUpgrade;
            }
            // On prend la position de la tour
            // On regarde de quel type elle est
            // On regarde son niveau actuel d'amélioration
            // Si on a assez d'argent on la passe au niveau suivant
            // On retire l'argent de l'upgrade à ses golds
        }

        public int GetLives()
        {
            return _currentLives;
        }

        public int GetGolds()
        {
            return _golds;
        }

        public int GetWaves()
        {
            return _currentWave;
        }

        public int GetWavesNumber()
        {
            return LevelManagerScript.Instance.GetLevel(CurrentLevel).GetWavesNumber();
        }

        public List<EnemyType>  GetKilledEnemiesList() {
            return _killedEnemiesList;
        }

        public void ClaimReward(int golds)
        {
            _golds += golds;

            AudioManagerScript.Instance.Play(ExtraGold, transform, 0.5f);

            if (ClaimRewardEvent != null)
                ClaimRewardEvent();
        }

        private void AddGolds(Enemy e)
        {
            _golds += e.GetReward();

            AudioManagerScript.Instance.Play(ExtraGold, transform, 0.5f);
        }

        private void DecreaseLives()
        {
            if (CurrentLevel != Level.ADJUSTEMENT)
            {
                _currentLives -= 1;

                if (_currentLives <= 0 && !_waveIsFinished)
                {
                    EnemyManagerScript.Instance.DestroyEnemies();

                    EndGame();
                }
            }
       
        }

        private bool IsWaveFinished()
        {
            return (_killedEnemies + _escapedEnemies == _spawnedEnemies);
        }

        private void LaunchWave() {
            WaveModel wave = LevelManagerScript.Instance.GetWave(CurrentLevel, _currentWave);

           if (LevelManagerScript.Instance.CanLaunchAnotherWave(CurrentLevel, _currentWave))
            {
                LevelManagerScript.Instance.LaunchWave(CurrentLevel, _currentWave);
            } else {
                LevelManagerScript.Instance.UnlockNextLevel(CurrentLevel);

                EndGame();
            }
        }

        private void EndGame() {
            _canLaunchWave = false;
            _waveIsFinished = true;
            _isGameStarted = false;
            _gameFinished = true;

            StartCoroutine(AudioManagerScript.Instance.PauseMusicWithFadeOut());
            _footstepSource.Stop();

            if (GameFinished != null)
                GameFinished();
        }

        public void LaunchLevel() {
            Debug.Log("Launch Level");

            if (GameStarted != null)
                GameStarted();

            _isGameStarted = true;

            _gameFinished = false;

            _currentWave = 0;

            _killedEnemiesList.Clear();

            _currentLives = LevelManagerScript.Instance.GetLevel(CurrentLevel).GetLife();

            _golds = LevelManagerScript.Instance.GetLevel(CurrentLevel).GetGolds();

            StartCoroutine(AudioManagerScript.Instance.PlayMusicWithFadeIn(MusicLevel, 0.6f));

            InitializeWave();

            StartCoroutine(LaunchDelayedWave());
        }

        IEnumerator LaunchDelayedWave() {
            yield return new WaitForSeconds(1.0f);

            LaunchWave();
        }

    }
}
