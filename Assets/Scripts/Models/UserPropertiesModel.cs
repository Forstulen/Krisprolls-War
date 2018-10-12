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

        #region Statistics

        int _totalPoints;
        int _totalUsedHintsGame;
        int _totalUsedHintsLife;
        int _questionsStreakRound;
        int _questionsStreakGame;
        int _askedQuestionsRound;
        int _askedQuestionsGame;
        int _answeredQuestionsRound;
        int _answeredQuestionsGame;
        int _answeredQuestionsLife;
        int _bestScoreRound;
        int _bestScoreGame;
        int _playedGames;
        int _wonGames;
        int _lostGames;
        int _abandonnedGames;
        int _openApp;

        float _beatRoundScoreLevel1;
        float _beatRoundScoreLevel2;
        float _beatRoundScoreLevel3;
        float _beatRoundScoreLevel4;
        float _useHintsLevel1;
        float _useHintsLevel2;
        float _useHintsLevel3;
        float _winMatchLevel1;
        float _winMatchLevel2;
        float _winMatchLevel3;
        float _winMatchLevel4;
        float _perfectRound;
        float _getBackInTheAppLevel1;
        float _getBackInTheAppLevel2;
        float _getBackInTheAppLevel3;
        float _playedMatchLevel1;
        float _playedMatchLevel2;
        float _playedMatchLevel3;
        float _playedMatchLevel4;
        float _submitQuestion;
        float _playTrainingMode;
        float _playSimulteanouslyMatchesLevel1;
        float _playSimulteanouslyMatchesLevel2;
        float _playSimulteanouslyMatchesLevel3;
        float _purchasePremiumVersion;
        float _sendFacebookRequest;
        float _watchVideo;
        float _addFriend;
        int _character1;
        int _character2;
        int _character3;
        int _character4;
        int _character5;
        int _character6;
        int _character7;
        int _character8;
        int _musicActivated;
        int _premiumVersion;
        int _statsAndLeads;
        int _noAdds;
        string _tokenAccount;
        string _usernameAccount;
        string _emailAccount;
        string _deviceToken;
        string _passwordAccount;
        int _selectedCharacter;
        string _installDate;
        string _updateDate;
        //SOOMLA IS FUCKED UP ON MOBILE...
        int _hintsNumber;
        int _resultDisplayed;


        public int totalPoints
        {
            get { return _totalPoints; }
            set
            {
                _totalPoints = value;
                PlayerPrefs.SetInt("totalPoints" + tokenAccount, _totalPoints);
                PlayerPrefs.Save();
            }
        }

        public int totalUsedHintsGame
        {
            get { return _totalUsedHintsGame; }
            set
            {
                _totalUsedHintsGame = value;
                PlayerPrefs.SetInt("totalUsedHintsGame" + tokenAccount, _totalUsedHintsGame);
                PlayerPrefs.Save();
            }
        }

        public int totalUsedHintsLife
        {
            get { return _totalUsedHintsLife; }
            set
            {
                _totalUsedHintsLife = value;
                PlayerPrefs.SetInt("totalUsedHintsLife" + tokenAccount, _totalUsedHintsLife);
                PlayerPrefs.Save();
            }
        }

        public int questionsStreakRound
        {
            get { return _questionsStreakRound; }
            set
            {
                _questionsStreakRound = value;
                PlayerPrefs.SetInt("questionsStreakRound" + tokenAccount, _questionsStreakRound);
                PlayerPrefs.Save();
            }
        }

        public int questionsStreakGame
        {
            get { return _questionsStreakGame; }
            set
            {
                _questionsStreakGame = value;
                PlayerPrefs.SetInt("questionsStreakGame" + tokenAccount, _questionsStreakGame);
                PlayerPrefs.Save();
            }
        }


        public int askedQuestionsRound
        {
            get { return _askedQuestionsRound; }
            set
            {
                _askedQuestionsRound = value;
                PlayerPrefs.SetInt("askedQuestionsRound" + tokenAccount, _askedQuestionsRound);
                PlayerPrefs.Save();
            }
        }

        public int askedQuestionsGame
        {
            get { return _askedQuestionsGame; }
            set
            {
                _askedQuestionsGame = value;
                PlayerPrefs.SetInt("askedQuestionsGame" + tokenAccount, _askedQuestionsGame);
                PlayerPrefs.Save();
            }
        }

        public int answeredQuestionsRound
        {
            get { return _answeredQuestionsRound; }
            set
            {
                _answeredQuestionsRound = value;
                PlayerPrefs.SetInt("answeredQuestionsRound" + tokenAccount, _answeredQuestionsRound);
                PlayerPrefs.Save();
            }
        }

        public int answeredQuestionsGame
        {
            get { return _answeredQuestionsGame; }
            set
            {
                _answeredQuestionsGame = value;
                PlayerPrefs.SetInt("answeredQuestionsGame" + tokenAccount, _answeredQuestionsGame);
                PlayerPrefs.Save();
            }
        }

        public int answeredQuestionsLife
        {
            get { return _answeredQuestionsLife; }
            set
            {
                _answeredQuestionsLife = value;
                PlayerPrefs.SetInt("answeredQuestionsLife" + tokenAccount, _answeredQuestionsLife);
                PlayerPrefs.Save();
            }
        }

        public int bestScoreRound
        {
            get { return _bestScoreRound; }
            set
            {
                _bestScoreRound = value;
                PlayerPrefs.SetInt("bestScoreRound" + tokenAccount, _bestScoreRound);
                PlayerPrefs.Save();
            }
        }

        public int bestScoreGame
        {
            get { return _bestScoreGame; }
            set
            {
                _bestScoreGame = value;
                PlayerPrefs.SetInt("bestScoreGame" + tokenAccount, _bestScoreGame);
                PlayerPrefs.Save();
            }
        }

        public int playedGames
        {
            get { return _playedGames; }
            set
            {
                _playedGames = value;
                PlayerPrefs.SetInt("playedGames" + tokenAccount, _playedGames);
                PlayerPrefs.Save();
            }
        }

        public int wonGames
        {
            get { return _wonGames; }
            set
            {
                _wonGames = value;
                PlayerPrefs.SetInt("wonGames" + tokenAccount, _wonGames);
                PlayerPrefs.Save();
            }
        }

        public int lostGames
        {
            get { return _lostGames; }
            set
            {
                _lostGames = value;
                PlayerPrefs.SetInt("lostGames" + tokenAccount, _lostGames);
                PlayerPrefs.Save();
            }
        }

        public int abandonnedGames
        {
            get { return _abandonnedGames; }
            set
            {
                _abandonnedGames = value;
                PlayerPrefs.SetInt("abandonnedGames" + tokenAccount, _abandonnedGames);
                PlayerPrefs.Save();
            }
        }

        public int openApp
        {
            get { return _openApp; }
            set
            {
                _openApp = value;
                PlayerPrefs.SetInt("openApp" + tokenAccount, _openApp);
                PlayerPrefs.Save();
            }
        }
        #endregion

        #region Achievements
        public float beatRoundScoreLevel1
        {
            get { return _beatRoundScoreLevel1; }
            set
            {
                _beatRoundScoreLevel1 = value;
                PlayerPrefs.SetFloat("beatRoundScoreLevel1" + tokenAccount, _beatRoundScoreLevel1);
                PlayerPrefs.Save();
            }
        }

        public float beatRoundScoreLevel2
        {
            get { return _beatRoundScoreLevel2; }
            set
            {
                _beatRoundScoreLevel2 = value;
                PlayerPrefs.SetFloat("beatRoundScoreLevel2" + tokenAccount, _beatRoundScoreLevel2);
                PlayerPrefs.Save();
            }
        }

        public float beatRoundScoreLevel3
        {
            get { return _beatRoundScoreLevel3; }
            set
            {
                _beatRoundScoreLevel3 = value;
                PlayerPrefs.SetFloat("beatRoundScoreLevel3" + tokenAccount, _beatRoundScoreLevel3);
                PlayerPrefs.Save();
            }
        }

        public float beatRoundScoreLevel4
        {
            get { return _beatRoundScoreLevel4; }
            set
            {
                _beatRoundScoreLevel4 = value;
                PlayerPrefs.SetFloat("beatRoundScoreLevel4" + tokenAccount, _beatRoundScoreLevel4);
                PlayerPrefs.Save();
            }
        }

        public float useHintsLevel1
        {
            get { return _useHintsLevel1; }
            set
            {
                _useHintsLevel1 = value;
                PlayerPrefs.SetFloat("useHintsLevel1" + tokenAccount, _useHintsLevel1);
                PlayerPrefs.Save();
            }
        }

        public float useHintsLevel2
        {
            get { return _useHintsLevel2; }
            set
            {
                _useHintsLevel2 = value;
                PlayerPrefs.SetFloat("useHintsLevel2" + tokenAccount, _useHintsLevel2);
                PlayerPrefs.Save();
            }
        }

        public float useHintsLevel3
        {
            get { return _useHintsLevel3; }
            set
            {
                _useHintsLevel3 = value;
                PlayerPrefs.SetFloat("useHintsLevel3" + tokenAccount, _useHintsLevel3);
                PlayerPrefs.Save();
            }
        }

        public float winMatchLevel1
        {
            get { return _winMatchLevel1; }
            set
            {
                _winMatchLevel1 = value;
                PlayerPrefs.SetFloat("winMatchLevel1" + tokenAccount, _winMatchLevel1);
                PlayerPrefs.Save();
            }
        }

        public float winMatchLevel2
        {
            get { return _winMatchLevel2; }
            set
            {
                _winMatchLevel2 = value;
                PlayerPrefs.SetFloat("winMatchLevel2" + tokenAccount, _winMatchLevel2);
                PlayerPrefs.Save();
            }
        }

        public float winMatchLevel3
        {
            get { return _winMatchLevel3; }
            set
            {
                _winMatchLevel3 = value;
                PlayerPrefs.SetFloat("winMatchLevel3" + tokenAccount, _winMatchLevel3);
                PlayerPrefs.Save();
            }
        }

        public float winMatchLevel4
        {
            get { return _winMatchLevel4; }
            set
            {
                _winMatchLevel4 = value;
                PlayerPrefs.SetFloat("winMatchLevel4" + tokenAccount, _winMatchLevel4);
                PlayerPrefs.Save();
            }
        }

        public float perfectRound
        {
            get { return _perfectRound; }
            set
            {
                _perfectRound = value;
                PlayerPrefs.SetFloat("perfectRound" + tokenAccount, _perfectRound);
                PlayerPrefs.Save();
            }
        }

        public float getBackInTheAppLevel1
        {
            get { return _getBackInTheAppLevel1; }
            set
            {
                _getBackInTheAppLevel1 = value;
                PlayerPrefs.SetFloat("getBackInTheAppLevel1" + tokenAccount, _getBackInTheAppLevel1);
                PlayerPrefs.Save();
            }
        }

        public float getBackInTheAppLevel2
        {
            get { return _getBackInTheAppLevel2; }
            set
            {
                _getBackInTheAppLevel2 = value;
                PlayerPrefs.SetFloat("getBackInTheAppLevel2" + tokenAccount, _getBackInTheAppLevel2);
                PlayerPrefs.Save();
            }
        }

        public float getBackInTheAppLevel3
        {
            get { return _getBackInTheAppLevel3; }
            set
            {
                _getBackInTheAppLevel3 = value;
                PlayerPrefs.SetFloat("getBackInTheAppLevel3" + tokenAccount, _getBackInTheAppLevel3);
                PlayerPrefs.Save();
            }
        }

        public float playedMatchLevel1
        {
            get { return _playedMatchLevel1; }
            set
            {
                _playedMatchLevel1 = value;
                PlayerPrefs.SetFloat("playedMatchLevel1" + tokenAccount, _playedMatchLevel1);
                PlayerPrefs.Save();
            }
        }

        public float playedMatchLevel2
        {
            get { return _playedMatchLevel2; }
            set
            {
                _playedMatchLevel2 = value;
                PlayerPrefs.SetFloat("playedMatchLevel2" + tokenAccount, _playedMatchLevel2);
                PlayerPrefs.Save();
            }
        }

        public float playedMatchLevel3
        {
            get { return _playedMatchLevel3; }
            set
            {
                _playedMatchLevel3 = value;
                PlayerPrefs.SetFloat("playedMatchLevel3" + tokenAccount, _playedMatchLevel3);
                PlayerPrefs.Save();
            }
        }

        public float playedMatchLevel4
        {
            get { return _playedMatchLevel4; }
            set
            {
                _playedMatchLevel4 = value;
                PlayerPrefs.SetFloat("playedMatchLevel4" + tokenAccount, _playedMatchLevel4);
                PlayerPrefs.Save();
            }
        }

        public float submitQuestion
        {
            get { return _submitQuestion; }
            set
            {
                _submitQuestion = value;
                PlayerPrefs.SetFloat("submitQuestion" + tokenAccount, _submitQuestion);
                PlayerPrefs.Save();
            }
        }

        public float playTrainingMode
        {
            get { return _playTrainingMode; }
            set
            {
                _playTrainingMode = value;
                PlayerPrefs.SetFloat("playTrainingMode" + tokenAccount, _playTrainingMode);
                PlayerPrefs.Save();
            }
        }

        public float playSimulteanouslyMatchesLevel1
        {
            get { return _playSimulteanouslyMatchesLevel1; }
            set
            {
                _playSimulteanouslyMatchesLevel1 = value;
                PlayerPrefs.SetFloat("playSimulteanouslyMatchesLevel1" + tokenAccount, _playSimulteanouslyMatchesLevel1);
                PlayerPrefs.Save();
            }
        }

        public float playSimulteanouslyMatchesLevel2
        {
            get { return _playSimulteanouslyMatchesLevel2; }
            set
            {
                _playSimulteanouslyMatchesLevel2 = value;
                PlayerPrefs.SetFloat("playSimulteanouslyMatchesLevel2" + tokenAccount, _playSimulteanouslyMatchesLevel2);
                PlayerPrefs.Save();
            }
        }

        public float playSimulteanouslyMatchesLevel3
        {
            get { return _playSimulteanouslyMatchesLevel3; }
            set
            {
                _playSimulteanouslyMatchesLevel3 = value;
                PlayerPrefs.SetFloat("playSimulteanouslyMatchesLevel3" + tokenAccount, _playSimulteanouslyMatchesLevel3);
                PlayerPrefs.Save();
            }
        }

        public float purchasePremiumVersion
        {
            get { return _purchasePremiumVersion; }
            set
            {
                _purchasePremiumVersion = value;
                PlayerPrefs.SetFloat("purchasePremiumVersion" + tokenAccount, _purchasePremiumVersion);
                PlayerPrefs.Save();
            }
        }

        public float sendFacebookRequest
        {
            get { return _sendFacebookRequest; }
            set
            {
                _sendFacebookRequest = value;
                PlayerPrefs.SetFloat("sendFacebookRequest" + tokenAccount, _sendFacebookRequest);
                PlayerPrefs.Save();
            }
        }

        public float watchVideo
        {
            get { return _watchVideo; }
            set
            {
                _watchVideo = value;
                PlayerPrefs.SetFloat("watchVideo" + tokenAccount, _watchVideo);
                PlayerPrefs.Save();
            }
        }

        public float addFriend
        {
            get { return _addFriend; }
            set
            {
                _addFriend = value;
                PlayerPrefs.SetFloat("addFriend" + tokenAccount, _addFriend);
                PlayerPrefs.Save();
            }
        }
        #endregion

        #region Characters
        public int character1
        {
            get { return _character1; }
            set
            {
                _character1 = value;
                PlayerPrefs.SetInt("character1" + tokenAccount, _character1);
                PlayerPrefs.Save();
            }
        }

        public int character2
        {
            get { return _character2; }
            set
            {
                _character2 = value;
                PlayerPrefs.SetInt("character2" + tokenAccount, _character2);
                PlayerPrefs.Save();
            }
        }

        public int character3
        {
            get { return _character3; }
            set
            {
                _character3 = value;
                PlayerPrefs.SetInt("character3" + tokenAccount, _character3);
                PlayerPrefs.Save();
            }
        }

        public int character4
        {
            get { return _character4; }
            set
            {
                _character4 = value;
                PlayerPrefs.SetInt("character4" + tokenAccount, _character4);
                PlayerPrefs.Save();
            }
        }

        public int character5
        {
            get { return _character5; }
            set
            {
                _character5 = value;
                PlayerPrefs.SetInt("character5" + tokenAccount, _character5);
                PlayerPrefs.Save();
            }
        }

        public int character6
        {
            get { return _character6; }
            set
            {
                _character6 = value;
                PlayerPrefs.SetInt("character6" + tokenAccount, _character6);
                PlayerPrefs.Save();
            }
        }

        public int character7
        {
            get { return _character7; }
            set
            {
                _character7 = value;
                PlayerPrefs.SetInt("character7" + tokenAccount, _character7);
                PlayerPrefs.Save();
            }
        }

        public int character8
        {
            get { return _character8; }
            set
            {
                _character8 = value;
                PlayerPrefs.SetInt("character8" + tokenAccount, _character8);
                PlayerPrefs.Save();
            }
        }
        #endregion

        #region Properties
        public int musicActivated
        {
            get { return _musicActivated; }
            set
            {
                _musicActivated = value;
                PlayerPrefs.SetInt("musicActivated", _musicActivated);
                PlayerPrefs.Save();
            }
        }

        public int premiumVersion
        {
            get { return _premiumVersion; }
            set
            {
                _premiumVersion = value;
                PlayerPrefs.SetInt("premiumVersion" + tokenAccount, _premiumVersion);
                PlayerPrefs.Save();
            }
        }

        public int statsAndLeads
        {
            get { return _statsAndLeads; }
            set
            {
                _statsAndLeads = value;
                PlayerPrefs.SetInt("statsAndLeads" + tokenAccount, _statsAndLeads);
                PlayerPrefs.Save();
            }
        }

        public int noAdds
        {
            get { return _noAdds; }
            set
            {
                _noAdds = value;
                PlayerPrefs.SetInt("noAdds" + tokenAccount, _noAdds);
                PlayerPrefs.Save();
            }
        }

        public string tokenAccount
        {
            get { return _tokenAccount; }
            set
            {
                _tokenAccount = value;
                PlayerPrefs.SetString("tokenAccount", _tokenAccount);
                PlayerPrefs.Save();
            }
        }

        public string usernameAccount
        {
            get { return _usernameAccount; }
            set
            {
                _usernameAccount = value;
                PlayerPrefs.SetString("usernameAccount", _usernameAccount);
                PlayerPrefs.Save();
            }
        }

        public string emailAccount
        {
            get { return _emailAccount; }
            set
            {
                _emailAccount = value;
                PlayerPrefs.SetString("emailAccount", _emailAccount);
                PlayerPrefs.Save();
            }
        }

        public string deviceToken
        {
            get { return _deviceToken; }
            set
            {
                _deviceToken = value;
                PlayerPrefs.SetString("deviceToken", _deviceToken);
                PlayerPrefs.Save();
            }
        }

        public string passwordAccount
        {
            get { return _passwordAccount; }
            set
            {
                _passwordAccount = value;
                PlayerPrefs.SetString("passwordAccount", _passwordAccount);
                PlayerPrefs.Save();
            }
        }

        public int selectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                PlayerPrefs.SetInt("selectedCharacter" + tokenAccount, _selectedCharacter);
                PlayerPrefs.Save();
            }
        }

        public string installDate
        {
            get { return _installDate; }
            set
            {
                _installDate = value;
                PlayerPrefs.SetString("installDate" + tokenAccount, _installDate);
                PlayerPrefs.Save();
            }
        }

        public string updateDate
        {
            get { return _updateDate; }
            set
            {
                _updateDate = value;
                PlayerPrefs.SetString("updateDate" + tokenAccount, _updateDate);
                PlayerPrefs.Save();
            }
        }

        public int hintsNumber
        {
            get { return _hintsNumber; }
            set
            {
                _hintsNumber = value;
                PlayerPrefs.SetInt("hintsNumber" + tokenAccount, _hintsNumber);
                PlayerPrefs.Save();
            }
        }

        public int resultDisplayed
        {
            get { return _resultDisplayed; }
            set
            {
                _resultDisplayed = value;
                PlayerPrefs.SetInt("resultDisplayed", _resultDisplayed);
                PlayerPrefs.Save();
            }
        }
        #endregion

        // Use this for initialization
        void Awake()
        {
            //this.LoadProperties ();
        }

        public void LoadProperties()
        {
            //Statistics
            totalPoints = PlayerPrefs.GetInt("totalPoints" + tokenAccount, 0);
            totalUsedHintsGame = PlayerPrefs.GetInt("totalUsedHintsGame" + tokenAccount, 0);
            totalUsedHintsLife = PlayerPrefs.GetInt("totalUsedHintsLife" + tokenAccount, 0);
            askedQuestionsRound = PlayerPrefs.GetInt("askedQuestionsRound" + tokenAccount, 0);
            askedQuestionsGame = PlayerPrefs.GetInt("askedQuestionsGame" + tokenAccount, 0);
            questionsStreakRound = PlayerPrefs.GetInt("questionsStreakRound" + tokenAccount, 0);
            questionsStreakGame = PlayerPrefs.GetInt("questionsStreakGame" + tokenAccount, 0);
            answeredQuestionsRound = PlayerPrefs.GetInt("answeredQuestionsRound" + tokenAccount, 0);
            answeredQuestionsGame = PlayerPrefs.GetInt("answeredQuestionsGame" + tokenAccount, 0);
            answeredQuestionsLife = PlayerPrefs.GetInt("answeredQuestionsLife" + tokenAccount, 0);
            bestScoreRound = PlayerPrefs.GetInt("bestScoreRound" + tokenAccount, 0);
            bestScoreGame = PlayerPrefs.GetInt("bestScoreGame" + tokenAccount, 0);
            playedGames = PlayerPrefs.GetInt("playedGames" + tokenAccount, 0);
            wonGames = PlayerPrefs.GetInt("wonGames" + tokenAccount, 0);
            lostGames = PlayerPrefs.GetInt("lostGames" + tokenAccount, 0);
            abandonnedGames = PlayerPrefs.GetInt("abandonnedGames" + tokenAccount, 0);
            openApp = PlayerPrefs.GetInt("openApp" + tokenAccount, 0);
            //Achievements
            beatRoundScoreLevel1 = PlayerPrefs.GetFloat("beatRoundScoreLevel1" + tokenAccount, 0);
            beatRoundScoreLevel2 = PlayerPrefs.GetFloat("beatRoundScoreLevel2" + tokenAccount, 0);
            beatRoundScoreLevel3 = PlayerPrefs.GetFloat("beatRoundScoreLevel3" + tokenAccount, 0);
            beatRoundScoreLevel4 = PlayerPrefs.GetFloat("beatRoundScoreLevel4" + tokenAccount, 0);
            useHintsLevel1 = PlayerPrefs.GetFloat("useHintsLevel1" + tokenAccount, 0);
            useHintsLevel2 = PlayerPrefs.GetFloat("useHintsLevel2" + tokenAccount, 0);
            useHintsLevel3 = PlayerPrefs.GetFloat("useHintsLevel3" + tokenAccount, 0);
            winMatchLevel1 = PlayerPrefs.GetFloat("winMatchLevel1" + tokenAccount, 0);
            winMatchLevel2 = PlayerPrefs.GetFloat("winMatchLevel2" + tokenAccount, 0);
            winMatchLevel3 = PlayerPrefs.GetFloat("winMatchLevel3" + tokenAccount, 0);
            winMatchLevel4 = PlayerPrefs.GetFloat("winMatchLevel4" + tokenAccount, 0);
            perfectRound = PlayerPrefs.GetFloat("perfectRound" + tokenAccount, 0);
            getBackInTheAppLevel1 = PlayerPrefs.GetFloat("getBackInTheAppLevel1" + tokenAccount, 0);
            getBackInTheAppLevel2 = PlayerPrefs.GetFloat("getBackInTheAppLevel2" + tokenAccount, 0);
            getBackInTheAppLevel3 = PlayerPrefs.GetFloat("getBackInTheAppLevel3" + tokenAccount, 0);
            playedMatchLevel1 = PlayerPrefs.GetFloat("playedMatchLevel1" + tokenAccount, 0);
            playedMatchLevel2 = PlayerPrefs.GetFloat("playedMatchLevel2" + tokenAccount, 0);
            playedMatchLevel3 = PlayerPrefs.GetFloat("playedMatchLevel3" + tokenAccount, 0);
            playedMatchLevel4 = PlayerPrefs.GetFloat("playedMatchLevel4" + tokenAccount, 0);
            submitQuestion = PlayerPrefs.GetFloat("submitQuestion" + tokenAccount, 0);
            playTrainingMode = PlayerPrefs.GetFloat("playTrainingMode" + tokenAccount, 0);
            playSimulteanouslyMatchesLevel1 = PlayerPrefs.GetFloat("playSimulteanouslyMatchesLevel1" + tokenAccount, 0);
            playSimulteanouslyMatchesLevel2 = PlayerPrefs.GetFloat("playSimulteanouslyMatchesLevel2" + tokenAccount, 0);
            playSimulteanouslyMatchesLevel3 = PlayerPrefs.GetFloat("playSimulteanouslyMatchesLevel3" + tokenAccount, 0);
            purchasePremiumVersion = PlayerPrefs.GetFloat("purchasePremiumVersion" + tokenAccount, 0);
            sendFacebookRequest = PlayerPrefs.GetFloat("sendFacebookRequest" + tokenAccount, 0);
            watchVideo = PlayerPrefs.GetFloat("watchVideo" + tokenAccount, 0);
            addFriend = PlayerPrefs.GetFloat("addFriend" + tokenAccount, 0);
            //Characters
            character1 = PlayerPrefs.GetInt("character1" + tokenAccount, 1);
            character2 = PlayerPrefs.GetInt("character2" + tokenAccount, 0);
            character3 = PlayerPrefs.GetInt("character3" + tokenAccount, 0);
            character4 = PlayerPrefs.GetInt("character4" + tokenAccount, 0);
            character5 = PlayerPrefs.GetInt("character5" + tokenAccount, 0);
            character6 = PlayerPrefs.GetInt("character6" + tokenAccount, 0);
            character7 = PlayerPrefs.GetInt("character7" + tokenAccount, 0);
            character8 = PlayerPrefs.GetInt("character8" + tokenAccount, 0);
            //Properties
            musicActivated = PlayerPrefs.GetInt("musicActivated", 1);
            premiumVersion = PlayerPrefs.GetInt("premiumVersion", 0);
            statsAndLeads = PlayerPrefs.GetInt("statsAndLeads", 0);
            noAdds = PlayerPrefs.GetInt("noAdds", 0);
            usernameAccount = PlayerPrefs.GetString("usernameAccount", "Anonymous");
            deviceToken = PlayerPrefs.GetString("deviceToken", "");
            emailAccount = PlayerPrefs.GetString("emailAccount", "...@...");
            passwordAccount = PlayerPrefs.GetString("passwordAccount", "");
            selectedCharacter = PlayerPrefs.GetInt("selectedCharacter" + tokenAccount, 0);
            installDate = PlayerPrefs.GetString("installDate" + tokenAccount, DateTime.Now.ToString());
            updateDate = PlayerPrefs.GetString("updateDate" + tokenAccount, DateTime.Now.ToString());
            resultDisplayed = PlayerPrefs.GetInt("resultDisplayed", 0);
            hintsNumber = PlayerPrefs.GetInt("hintsNumber" + tokenAccount, 3);

            if (OnPropertiesLoaded != null) OnPropertiesLoaded(this, null);
        }
    }
}
