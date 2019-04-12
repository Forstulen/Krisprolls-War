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

    public enum SpecialWave
    {
        NUCLEAR = 0,
        NONE
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
            //_LevelCollection.Add(Level.LEVEL_5, CreateLevel5());

            UserPropertiesModel.Instance.OnPropertiesLoaded += (UserPropertiesModel script, System.EventArgs arg) =>
            {
                if (UserPropertiesModel.Instance.Level_1)
                    _LevelCollection[Level.LEVEL_1].UnlockLevel();
                if (UserPropertiesModel.Instance.Level_2)
                    _LevelCollection[Level.LEVEL_2].UnlockLevel();
                if (UserPropertiesModel.Instance.Level_3)
                    _LevelCollection[Level.LEVEL_3].UnlockLevel();
                if (UserPropertiesModel.Instance.Level_4)
                    _LevelCollection[Level.LEVEL_4].UnlockLevel();
                //if (UserPropertiesModel.Instance.Level_5)
                //_LevelCollection[Level.LEVEL_5].UnlockLevel();
            };

#if DEVELOPMENT_BUILD
            foreach (LevelModel lm in _LevelCollection.Values)
            {
                lm.UnlockLevel();
            }
#endif
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.MAIN_PATH, 0.5f, 3, 50);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 4, 20);

            tutorialWaves[0] = wave1;
            tutorialWaves[1] = wave2;
            tutorialWaves[2] = wave3;
            tutorialWaves[3] = wave4;
            tutorialWaves[4] = wave5;

            //*************

            LevelModel tutorial = new LevelModel(tutorialWaves, "Tutorial", 1.0f, 5, 30);

            //******

            tutorial.UnlockLevel();

            return tutorial;
        }

        private LevelModel CreateLevel1()
        {
            //WAVES1
            WaveModel[] level1Waves = new WaveModel[10];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 1, 10);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 2, 30);

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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 3, 50);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.25f, 4, 10);

            WaveModel wave6 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.10f, 5, 50);

            WaveModel wave7 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 6, 20);

            WaveModel wave8 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 7, 40);

            WaveModel wave9 = new WaveModel(new EnemyType[] {
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
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 8, 30);

            WaveModel wave10 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 9, 50);

            level1Waves[0] = wave1;
            level1Waves[1] = wave2;
            level1Waves[2] = wave3;
            level1Waves[3] = wave4;
            level1Waves[4] = wave5;
            level1Waves[5] = wave6;
            level1Waves[6] = wave7;
            level1Waves[7] = wave8;
            level1Waves[8] = wave9;
            level1Waves[9] = wave10;

            //*************

            LevelModel level1 = new LevelModel(level1Waves, "Level 1", 1.0f, 5, 20, new Dictionary<TowerType, int> { { TowerType.AOE, 2 } });

            //******

            level1.UnlockLevel();

            return level1;
        }

        private LevelModel CreateLevel2() {
            WaveModel[] level2Waves = new WaveModel[15];

            WaveModel wave1 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 0, 5);

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
            }, FollowingPath.ALTERNATIVE_PATH1, 0.5f, 1, 10);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 2, 10);

            WaveModel wave4 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 1.0f, 3, 20);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 0.25f, 4, 20);

            WaveModel wave6 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 0.25f, 5, 20);

            WaveModel wave7 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 6, 20);

            WaveModel wave8 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 0.75f, 7, 5);

            WaveModel wave9 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 0.0f, 8, 10);


            WaveModel wave10 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
            }, FollowingPath.ALTERNATIVE_PATH2, 0.5f, 9, 20);

            WaveModel wave11 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 0.5f, 10, 20);

            WaveModel wave12 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 11, 40);

            WaveModel wave13 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 12, 50);

            WaveModel wave14 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.1f, 13, 100);

            WaveModel wave15 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 14, 50);



            level2Waves[0] = wave1;
            level2Waves[1] = wave2;
            level2Waves[2] = wave3;
            level2Waves[3] = wave4;
            level2Waves[4] = wave5;
            level2Waves[5] = wave6;
            level2Waves[6] = wave7;
            level2Waves[7] = wave8;
            level2Waves[8] = wave9;
            level2Waves[9] = wave10;
            level2Waves[10] = wave11;
            level2Waves[11] = wave12;
            level2Waves[12] = wave13;
            level2Waves[13] = wave14;
            level2Waves[14] = wave15;

            //*************

            LevelModel level2 = new LevelModel(level2Waves, "Level 2", 1.0f, 10, 20, new Dictionary<TowerType, int> { { TowerType.AOE, 2 } });

            //******

            if (UserPropertiesModel.Instance.Level_2)
                level2.UnlockLevel();

            return level2;
        }

        private LevelModel CreateLevel3()
        {
            //WAVES1
            WaveModel[] level3Waves = new WaveModel[20];

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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 1, 10);

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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 2, 20);

            WaveModel wave4 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 3, 10);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 1.0f, 4, 20);

            WaveModel wave6 = new WaveModel(new EnemyType[] {
                EnemyType.SPEED_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 5, 5);

            WaveModel wave7 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 6, 30);

            WaveModel wave8 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.SPEED_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 7, 20);

            WaveModel wave9 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 1.5f, 8, 40);

            WaveModel wave10 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 9, 10);

            WaveModel wave11 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 10, 40);

            WaveModel wave12 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.5f, 11, 50);

            WaveModel wave13 = new WaveModel(new EnemyType[] {
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
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 12, 50);

            WaveModel wave14 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
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
                EnemyType.HEAVY_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
            }, FollowingPath.ALTERNATIVE_PATH1, 0.75f, 13, 50);

            WaveModel wave15 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 14, 100);

            WaveModel wave16 = new WaveModel(new EnemyType[] {
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
            }, FollowingPath.MAIN_PATH, 1.5f, 15, 0);

            WaveModel wave17 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH2, 1.5f, 16, 10);

            WaveModel wave18 = new WaveModel(new EnemyType[] {
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.5f, 17, 10);

            WaveModel wave19 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 1.0f, 18, 50);

            WaveModel wave20 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.ALTERNATIVE_PATH1, 0.5f, 19, 100);
            
            level3Waves[0] = wave1;
            level3Waves[1] = wave2;
            level3Waves[2] = wave3;
            level3Waves[3] = wave4;
            level3Waves[4] = wave5;
            level3Waves[5] = wave6;
            level3Waves[6] = wave7;
            level3Waves[7] = wave8;
            level3Waves[8] = wave9;
            level3Waves[9] = wave10;
            level3Waves[10] = wave11;
            level3Waves[11] = wave12;
            level3Waves[12] = wave13;
            level3Waves[13] = wave14;
            level3Waves[14] = wave15;
            level3Waves[15] = wave16;
            level3Waves[16] = wave17;
            level3Waves[17] = wave18;
            level3Waves[18] = wave19;
            level3Waves[19] = wave20;

            //*************

            LevelModel level3 = new LevelModel(level3Waves, "Level 3", 1.75f, 10, 40, new Dictionary<TowerType, int> { { TowerType.AOE, 2 } });

            //******


            if (UserPropertiesModel.Instance.Level_3)
                level3.UnlockLevel();

            return level3;
        }


        private LevelModel CreateLevel4()
        {
            WaveModel[] level4Waves = new WaveModel[20];

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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 1, 20);

            WaveModel wave3 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 2, 20);

            WaveModel wave4 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 3, 30);

            WaveModel wave5 = new WaveModel(new EnemyType[] {
                EnemyType.FROST_ENEMY,
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 4, 20);

            WaveModel wave6 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 5, 20);

            WaveModel wave7 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 6, 40);

            WaveModel wave8 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 7, 30);

            WaveModel wave9 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.25f, 8, 30);

            WaveModel wave10 = new WaveModel(new EnemyType[] {
                EnemyType.POISON_KNIGHT,
                EnemyType.POISON_KNIGHT,
                EnemyType.POISON_KNIGHT,
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
                EnemyType.SPEED_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 9, 15);

            WaveModel wave11 = new WaveModel(new EnemyType[] {
            }, FollowingPath.MAIN_PATH, 1.0f, 10, 0, SpecialWave.NUCLEAR);

            WaveModel wave12 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 11, 10);


            WaveModel wave13 = new WaveModel(new EnemyType[] {
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
            }, FollowingPath.MAIN_PATH, 1.0f, 12, 10);

            WaveModel wave14 = new WaveModel(new EnemyType[] {
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
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 13, 20);

            WaveModel wave15 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 14, 20);

            WaveModel wave16 = new WaveModel(new EnemyType[] {
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 1.0f, 15, 80);

            WaveModel wave17 = new WaveModel(new EnemyType[] {
                EnemyType.FROST_ENEMY,
                EnemyType.FROST_ENEMY,
                EnemyType.FROST_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 16, 30);

            WaveModel wave18 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.POISON_KNIGHT,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 17, 50);

            WaveModel wave19 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
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
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.5f, 18, 100);

            WaveModel wave20 = new WaveModel(new EnemyType[] {
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.POISON_KNIGHT,
                EnemyType.POISON_KNIGHT,
                EnemyType.POISON_KNIGHT,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.MEDIUM_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.SPEED_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.HEAVY_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.FROST_ENEMY,
                EnemyType.FROST_ENEMY,
                EnemyType.FROST_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.HEAVY_KNIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.LIGHT_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
                EnemyType.HEAVY_BERSERK_ENEMY,
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
                EnemyType.LIGHT_ENEMY
            }, FollowingPath.MAIN_PATH, 0.75f, 19, 150);

          


            level4Waves[0] = wave1;
            level4Waves[1] = wave2;
            level4Waves[2] = wave3;
            level4Waves[3] = wave4;
            level4Waves[4] = wave5;
            level4Waves[5] = wave6;
            level4Waves[6] = wave7;
            level4Waves[7] = wave8;
            level4Waves[8] = wave9;
            level4Waves[9] = wave10;
            level4Waves[10] = wave11;
            level4Waves[11] = wave12;
            level4Waves[12] = wave13;
            level4Waves[13] = wave14;
            level4Waves[14] = wave15;
            level4Waves[15] = wave16;
            level4Waves[16] = wave17;
            level4Waves[17] = wave18;
            level4Waves[18] = wave19;
            level4Waves[19] = wave20;

            //*************

            LevelModel level4 = new LevelModel(level4Waves, "Level 4", 1.25f, 15, 40, new Dictionary<TowerType, int> { { TowerType.AOE, 2 } });

            //******


            if (UserPropertiesModel.Instance.Level_4)
                level4.UnlockLevel();

            return level4;
        }

        private LevelModel CreateLevel5()
        {
            WaveModel[] level5Waves = new WaveModel[3];

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

            level5Waves[0] = wave1;
            level5Waves[1] = wave2;
            level5Waves[2] = wave3;

            //*************

            LevelModel level5 = new LevelModel(level5Waves, "Level 5", 1.0f, 50, 20);

            //******


            if (UserPropertiesModel.Instance.Level_5)
                level5.UnlockLevel();

            return level5;
        }

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
                UserPropertiesModel.Instance.SetLevel(l, true);
            }
        }

        public void LaunchWave(Level level, int waveNumber) {
            StartCoroutine(CreateWave(GetWave(level, waveNumber), _LevelCollection[level].GetLevelEnemyCoeff()));
        }

        private IEnumerator CreateWave(WaveModel wave, float coeff) {

            SpecialWaveManagerScript.Instance.ApplySpecialEffect(wave.SpecialWaveType);
            
            for (int i = 0; i < wave._enemyCollections.Length; ++i)
            {
                GameObject go = EnemyManagerScript.Instance.CreateEnemy(wave._enemyCollections[i], wave.Path, coeff);

                go.GetComponent<Enemy>().Create();

                yield return new WaitForSeconds(wave.WaitingTime);

            }
        }
    }

}