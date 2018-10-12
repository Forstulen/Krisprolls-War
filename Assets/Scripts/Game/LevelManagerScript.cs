using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public enum Level
    {
        ADJUSTEMENT = -1,
        TUTORIAL,
        LEVEL_1,
        LEVEL_2,
        LEVEL_3,
        LEVEL_4,
        LEVEL_5,
        LEVEL_6,
        LEVEL_7,
        LEVEL_8,
        LEVEL_9,
        LEVEL_10,
        END
    }

    public class LevelManagerScript : SingletonScript<LevelManagerScript>
    {
        private Dictionary<Level, LevelModel>   _LevelCollection;

        private void Awake()
        {
            _LevelCollection = new Dictionary<Level, LevelModel>();

            _LevelCollection.Add(Level.TUTORIAL, CreateTutorial());
            _LevelCollection.Add(Level.LEVEL_1, CreateLevel1());
            _LevelCollection.Add(Level.LEVEL_2, CreateLevel2());
            _LevelCollection.Add(Level.LEVEL_3, CreateLevel3());
            _LevelCollection.Add(Level.LEVEL_4, CreateLevel4());
           // _LevelCollection.Add(Level.LEVEL_6, CreateLevel6());
        }

        private void Start()
        {
           
        }

        private LevelModel CreateTutorial() {
            //WAVES1
            WaveModel[] tutorialWaves = new WaveModel[5];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.5f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 0.5f, 2, 50);

            WaveModel wave4 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
            }, FollowingPath.MAIN_PATH, 0.5f, 3, 50);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_KNIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 4, 20);

            tutorialWaves[0] = wave1;
            tutorialWaves[1] = wave2;
            tutorialWaves[2] = wave3;
            tutorialWaves[3] = wave4;
            tutorialWaves[4] = wave5;

            //*************

            LevelModel tutorial = new LevelModel(tutorialWaves, "Tutorial", 5, 30);

            //******

            tutorial.UnlockLevel();

            return tutorial;
        }

        private LevelModel CreateLevel1() {
            //WAVES1
            WaveModel[] level1Waves = new WaveModel[4];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 1, 10);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 2, 20);

            WaveModel wave4 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.25f, 3, 30);

            level1Waves[0] = wave1;
            level1Waves[1] = wave2;
            level1Waves[2] = wave3;
            level1Waves[3] = wave4;

            //*************

            LevelModel level1 = new LevelModel(level1Waves, "Level 1", 10, 20);

            //******

            level1.UnlockLevel();

            return level1;
        }

        private LevelModel CreateLevel2() {
            WaveModel[] level2Waves = new WaveModel[3];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY,
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 2, 30);

            level2Waves[0] = wave1;
            level2Waves[1] = wave2;
            level2Waves[2] = wave3;

            //*************

            LevelModel level2 = new LevelModel(level2Waves, "Level 2", 20, 40);

            //******

            return level2;
        }

        private LevelModel CreateLevel3()
        {
            //WAVES1
            WaveModel[] level3Waves = new WaveModel[3];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 2, 30);

            level3Waves[0] = wave1;
            level3Waves[1] = wave2;
            level3Waves[2] = wave3;

            //*************

            LevelModel level3 = new LevelModel(level3Waves, "Level 3", 20, 20);

            //******

            //level3.UnlockLevel();

            return level3;
        }


        private LevelModel CreateLevel4()
        {
            WaveModel[] level4Waves = new WaveModel[3];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY,
            }, FollowingPath.MAIN_PATH, 0.75f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 2, 30);

            level4Waves[0] = wave1;
            level4Waves[1] = wave2;
            level4Waves[2] = wave3;

            //*************

            LevelModel level4 = new LevelModel(level4Waves, "Level 4", 50, 20);

            //******

            return level4;
        }

       /* private LevelModel CreateLevel6()
        {
            WaveModel[] level6Waves = new WaveModel[3];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 1.0f, 0, 10);

            WaveModel wave2 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY,
            }, FollowingPath.MAIN_PATH, 0.75f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 2, 30);

            level6Waves[0] = wave1;
            level6Waves[1] = wave2;
            level6Waves[2] = wave3;

            //*************

            LevelModel level6 = new LevelModel(level6Waves, "Level 6", 50, 20);

            //******

            return level6;
        } */

        public LevelModel GetLevel(Level level) {
            return _LevelCollection[level];
        }

        public LevelModel GetNextLevel(Level level)
        {
            Level l = level + 1;

            if (_LevelCollection.ContainsKey(l))
            {
                return _LevelCollection[l];
            }
            return null;
        }

        public int  GetLevelNumber() {
            return _LevelCollection.Count;
        }

        public WaveModel GetWave(Level level, int waveNumber) {
            return _LevelCollection[level].GetWaveModel(waveNumber);
        }

        public bool CanLaunchAnotherWave(Level level, int waveNumber) {
            Debug.Log(GetLevel(level).GetWavesNumber());
            Debug.Log("WaveNumber :" + waveNumber);
            if (GetLevel(level).GetWavesNumber() > waveNumber)
            {
                return true;
            }else{
                return false;
            }           
        }

        public void UnlockNextLevel(Level currentLevel) {
            Level l = currentLevel + 1;

            if (_LevelCollection.ContainsKey(l))
            {
                _LevelCollection[l].UnlockLevel();
            }
        }

        public void LaunchWave(Level level, int waveNumber) {
            StartCoroutine(CreateWave(GetWave(level, waveNumber)));
        }

        private IEnumerator CreateWave(WaveModel wave) {
            
            for (int i = 0; i < wave._enemyCollections.Length; ++i)
            {
                GameObject go = EnemyManagerScript.Instance.CreateEnemy(wave._enemyCollections[i], wave.Path);

                go.GetComponent<Enemy>().Create();

                yield return new WaitForSeconds(wave.WaitingTime);

            }
        }
    }

}