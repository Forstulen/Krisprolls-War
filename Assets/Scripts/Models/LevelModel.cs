using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    [System.Serializable]
    public class LevelModel
    {

        //Attributes
        private string          _levelName;
        private float           _levelEnemyCoeff;
        private Dictionary<TowerType, int> _towerLimitDict;
        private int             _currentWave;
        private WaveModel[]     _wavesArray;
        private int             _bestScore;
        private bool            _unlocked;
        private int             _life;
        private int             _goldsIni;

        public LevelModel(WaveModel[] waves, string name, float levelEnemyCoeff, int life, int goldsIni, Dictionary<TowerType, int> limits = null) {
            _levelName = name;
            _levelEnemyCoeff = levelEnemyCoeff;
            _wavesArray = waves;
            _life = life;
            _currentWave = 0;
            _bestScore = 0;
            _unlocked = false;
            _goldsIni = goldsIni;
            _towerLimitDict = limits;
        }

        public void SetScore(int highScore) {
            if (highScore > _bestScore)
                _bestScore = highScore;
        }

        public void UnlockLevel() {
            _unlocked = true;
        }

        public bool IsUnlocked() {
            return _unlocked;
        }

        public WaveModel GetWaveModel(int value) {
            if (_wavesArray.Length > value)
                return _wavesArray[value];
            return _wavesArray[0];
        }

        public int GetCurrentWaveNumber() {
            return _currentWave;
        }

        public int GetLife() {
            return _life;
        }

        public int GetTowerLimit(TowerType t) {
            if (_towerLimitDict != null && _towerLimitDict.ContainsKey(t)) {
                return _towerLimitDict[t];
            }
            return 2000;
        }

        public string GetLevelName() {
            return _levelName;
        }

        public float GetLevelEnemyCoeff()
        {
            return _levelEnemyCoeff;
        }

        public int GetWavesNumber() {
            return _wavesArray.Length;
        }

        public int GetGolds()
        {
            return _goldsIni;
        }
    }

}
