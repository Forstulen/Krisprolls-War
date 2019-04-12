using System;
using UnityEngine;
using System.Collections;

namespace TowerDefense
{

    public class UserPropertiesModel : SingletonScript<UserPropertiesModel>
    {

        //Delegate
        public delegate void PropertiesEvent(UserPropertiesModel script, System.EventArgs arg);

        ///Events
        public event PropertiesEvent OnPropertiesLoaded;

        #region Properties

        float _musicVolume;
        float _soundVolume;
        bool _level1Unlocked;
        bool _level2Unlocked;
        bool _level3Unlocked;
        bool _level4Unlocked;
        bool _level5Unlocked;

        private const string VOLUME_KEY = "MusicVolume";
        private const string SOUND_KEY = "SoundVolume";

        public float MusicVolume
        {
            get { return _musicVolume; }
            set
            {
                _musicVolume = value;
                PlayerPrefs.SetFloat(VOLUME_KEY, _musicVolume);
                PlayerPrefs.Save();
            }
        }

        public float SoundVolume
        {
            get { return _soundVolume; }
            set
            {
                _soundVolume = value;
                PlayerPrefs.SetFloat(SOUND_KEY, _soundVolume);
                PlayerPrefs.Save();
            }
        }

        public bool Level_1
        {
            get { return _level1Unlocked; }
            set
            {
                _level1Unlocked = value;
                PlayerPrefs.SetInt(Level.LEVEL_1.ToString(), _level1Unlocked ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Level_2
        {
            get { return _level2Unlocked; }
            set
            {
                _level2Unlocked = value;
                PlayerPrefs.SetInt(Level.LEVEL_2.ToString(), _level2Unlocked ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Level_3
        {
            get { return _level3Unlocked; }
            set
            {
                _level3Unlocked = value;
                PlayerPrefs.SetInt(Level.LEVEL_3.ToString(), _level3Unlocked ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Level_4
        {
            get { return _level4Unlocked; }
            set
            {
                _level4Unlocked = value;
                PlayerPrefs.SetInt(Level.LEVEL_4.ToString(), _level4Unlocked ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        public bool Level_5
        {
            get { return _level5Unlocked; }
            set
            {
                _level5Unlocked = value;
                PlayerPrefs.SetInt(Level.LEVEL_5.ToString(), _level5Unlocked ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

   
        #endregion

        // Use this for initialization
        void Start()
        {
            this.LoadProperties ();
        }

        public void LoadProperties()
        {
            //Properties
            MusicVolume = PlayerPrefs.GetFloat(UserPropertiesModel.VOLUME_KEY, 1.0f);
            SoundVolume = PlayerPrefs.GetFloat(UserPropertiesModel.SOUND_KEY, 1.0f);
            Level_1 = PlayerPrefs.GetInt(Level.LEVEL_1.ToString(), 1) == 1 ? true : false ;
            Level_2 = PlayerPrefs.GetInt(Level.LEVEL_2.ToString(), 0) == 1 ? true : false;
            Level_3 = PlayerPrefs.GetInt(Level.LEVEL_3.ToString(), 0) == 1 ? true : false;
            Level_4 = PlayerPrefs.GetInt(Level.LEVEL_4.ToString(), 0) == 1 ? true : false;
            Level_5 = PlayerPrefs.GetInt(Level.LEVEL_5.ToString(), 0) == 1 ? true : false;

            if (OnPropertiesLoaded != null)
            {
                OnPropertiesLoaded(this, null);
            }
        }

        public void SetLevel(Level level, bool unlocked) {
            PlayerPrefs.SetInt(level.ToString(), unlocked ? 1 : 0);
            PlayerPrefs.Save();

            LoadProperties();
        }
    }
}
