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
        private int             _currentWave;
        private WaveModel[]     _wavesArray;
        private int             _bestScore;
        private bool            _unlocked;
        private int             _life;
        private int             _goldsIni;

        public LevelModel(WaveModel[] waves, string name, int life, int goldsIni) {
            _levelName = name;
            _wavesArray = waves;
            _life = life;
            _currentWave = 0;
            _bestScore = 0;
            _unlocked = false;
            _goldsIni = goldsIni;
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

        public string GetLevelName() {
            return _levelName;
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
