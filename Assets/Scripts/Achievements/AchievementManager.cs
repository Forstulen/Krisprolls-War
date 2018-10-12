using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TowerDefense
{

    public class AchievementManager : SingletonScript<AchievementManager>
    {

        public List<AchievementModel> achievementList { get; private set; }

        public class AchievementArgs : System.EventArgs
        {
            public List<AchievementModel> achievementList;
        }

        //Delegates
        public delegate void AchievementEvent(AchievementManager script, AchievementArgs e);

        //Events
        public AchievementEvent onUnlockedAchievement;
        public AchievementEvent onLoadAchievements;
        public AchievementEvent onGetError;

        public AchievementEvent onRetrieveAchievementsFinished;
        public AchievementEvent onRetrieveAchievementsRejected;

        public AchievementEvent onReportAchievementFinished;
        public AchievementEvent onReportAchievementRejected;

        public const string RETRIEVE_ACHIEVEMENTS = "/achievements/user/";
        public const string REPORT_ACHIEVEMENT = "/achievement/report";

        void Awake()
        {
            //ScoringManager scoringManager = ScoringManager.Instance;
            UserPropertiesModel userProperties = UserPropertiesModel.Instance;

            userProperties.LoadProperties();

            achievementList = new List<AchievementModel>();
            //**************************************BEAT ROUND SCORE LEVEL1**********************************
            AchievementModel beatRoundScoreLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.beatRoundScoreLevel1,
                achievementIdentifier = "1",
                achievementName = ("1000 points on a round"),
                achievementDescription = ("1000 points on a round"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            beatRoundScoreLevel1.achievementBlock = (bool notify) =>
            {
                if (userProperties.bestScoreRound >= 1000)
                {
                    beatRoundScoreLevel1.achievementPercent = 100.0f;
                }

                userProperties.beatRoundScoreLevel1 = beatRoundScoreLevel1.achievementPercent;

                if (notify && beatRoundScoreLevel1.achievementUnlocked)
                {
                    beatRoundScoreLevel1.ReportAchievement();
                }
            };
            achievementList.Add(beatRoundScoreLevel1);

            //**************************************BEAT ROUND SCORE LEVEL2**********************************
            AchievementModel beatRoundScoreLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.beatRoundScoreLevel2,
                achievementIdentifier = "2",
                achievementName = ("2000 points on a round"),
                achievementDescription = ("2000 points on a round"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            beatRoundScoreLevel2.achievementBlock = (bool notify) =>
            {
                if (userProperties.bestScoreRound >= 2000)
                {
                    beatRoundScoreLevel2.achievementPercent = 100.0f;
                }

                userProperties.beatRoundScoreLevel2 = beatRoundScoreLevel2.achievementPercent;

                if (notify && beatRoundScoreLevel2.achievementUnlocked)
                {
                    beatRoundScoreLevel2.ReportAchievement();
                }
            };
            achievementList.Add(beatRoundScoreLevel2);

            //**************************************BEAT ROUND SCORE LEVEL3**********************************
            AchievementModel beatRoundScoreLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.beatRoundScoreLevel3,
                achievementIdentifier = "3",
                achievementName = ("3000 points on a round"),
                achievementDescription = ("3000 points on a round"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            beatRoundScoreLevel3.achievementBlock = (bool notify) =>
            {
                if (userProperties.bestScoreRound >= 3000)
                {
                    beatRoundScoreLevel3.achievementPercent = 100.0f;
                }

                userProperties.beatRoundScoreLevel3 = beatRoundScoreLevel3.achievementPercent;

                if (notify && beatRoundScoreLevel3.achievementUnlocked)
                {
                    beatRoundScoreLevel3.ReportAchievement();
                }
            };
            achievementList.Add(beatRoundScoreLevel3);

            //**************************************BEAT ROUND SCORE LEVEL4**********************************
            AchievementModel beatRoundScoreLevel4 = new AchievementModel()
            {
                achievementPercent = userProperties.beatRoundScoreLevel4,
                achievementIdentifier = "4",
                achievementName = ("4000 points on a round"),
                achievementDescription = ("4000 points on a round"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            beatRoundScoreLevel4.achievementBlock = (bool notify) =>
            {
                if (userProperties.bestScoreRound >= 4000)
                {
                    beatRoundScoreLevel4.achievementPercent = 100.0f;
                }

                userProperties.beatRoundScoreLevel4 = beatRoundScoreLevel4.achievementPercent;

                if (notify && beatRoundScoreLevel4.achievementUnlocked)
                {
                    beatRoundScoreLevel4.ReportAchievement();
                }
            };
            achievementList.Add(beatRoundScoreLevel4);

            //**************************************Use Hint Level1**********************************
            AchievementModel useHintsLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.useHintsLevel1,
                achievementIdentifier = "5",
                achievementName = ("Use 5 clues"),
                achievementDescription = ("Use 5 clues"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            useHintsLevel1.achievementBlock = (bool notify) =>
            {
                if (useHintsLevel1.achievementPercent != 100.0f)
                {
                    useHintsLevel1.achievementPercent = Mathf.Min(100.0f / 5.0f * userProperties.totalUsedHintsLife, 100.0f);
                }
                userProperties.useHintsLevel1 = useHintsLevel1.achievementPercent;

                if (notify && useHintsLevel1.achievementUnlocked)
                {
                    useHintsLevel1.ReportAchievement();
                }
            };
            achievementList.Add(useHintsLevel1);

            //**************************************Use Hint Level2**********************************
            AchievementModel useHintsLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.useHintsLevel2,
                achievementIdentifier = "6",
                achievementName = ("Use 20 clues"),
                achievementDescription = ("Use 20 clues"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            useHintsLevel2.achievementBlock = (bool notify) =>
            {
                if (useHintsLevel2.achievementPercent != 100.0f)
                {
                    useHintsLevel2.achievementPercent = Mathf.Min(100.0f / 20.0f * userProperties.totalUsedHintsLife, 100.0f);
                }

                userProperties.useHintsLevel2 = useHintsLevel2.achievementPercent;

                if (notify && useHintsLevel2.achievementUnlocked)
                {
                    useHintsLevel2.ReportAchievement();
                }
            };
            achievementList.Add(useHintsLevel2);

            //**************************************Use Hint Level3**********************************
            AchievementModel useHintsLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.useHintsLevel3,
                achievementIdentifier = "7",
                achievementName = ("Use 50 clues"),
                achievementDescription = ("Use 50 clues"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeInGame
            };
            useHintsLevel3.achievementBlock = (bool notify) =>
            {
                if (useHintsLevel3.achievementPercent != 100.0f)
                {
                    useHintsLevel3.achievementPercent = Mathf.Min(100.0f / 50.0f * userProperties.totalUsedHintsLife, 100.0f);
                }

                userProperties.useHintsLevel3 = useHintsLevel3.achievementPercent;

                if (notify && useHintsLevel3.achievementUnlocked)
                {
                    useHintsLevel3.ReportAchievement();
                }
            };
            achievementList.Add(useHintsLevel3);

            //**************************************Win Match Level1**********************************
            AchievementModel winMatchLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.winMatchLevel1,
                achievementIdentifier = "8",
                achievementName = ("Win 1 game"),
                achievementDescription = ("Win 1 game"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            winMatchLevel1.achievementBlock = (bool notify) =>
            {
                if (winMatchLevel1.achievementPercent != 100.0f)
                {
                    winMatchLevel1.achievementPercent = Mathf.Min(100.0f / 1.0f * userProperties.wonGames, 100.0f);
                }

                userProperties.winMatchLevel1 = winMatchLevel1.achievementPercent;

                if (notify && winMatchLevel1.achievementUnlocked)
                {
                    winMatchLevel1.ReportAchievement();
                }
            };
            achievementList.Add(winMatchLevel1);

            //**************************************Win Match Level2**********************************
            AchievementModel winMatchLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.winMatchLevel2,
                achievementIdentifier = "9",
                achievementName = ("Win 5 game"),
                achievementDescription = ("Win 5 game"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            winMatchLevel2.achievementBlock = (bool notify) =>
            {
                if (winMatchLevel2.achievementPercent != 100.0f)
                {
                    winMatchLevel2.achievementPercent = Mathf.Min(100.0f / 5.0f * userProperties.wonGames, 100.0f);
                }

                userProperties.winMatchLevel2 = winMatchLevel2.achievementPercent;

                if (notify && winMatchLevel2.achievementUnlocked)
                {
                    winMatchLevel2.ReportAchievement();
                }
            };
            achievementList.Add(winMatchLevel2);

            //**************************************Win Match Level3**********************************
            AchievementModel winMatchLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.winMatchLevel3,
                achievementIdentifier = "10",
                achievementName = ("Win 20 game"),
                achievementDescription = ("Win 20 game"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            winMatchLevel3.achievementBlock = (bool notify) =>
            {
                if (winMatchLevel3.achievementPercent != 100.0f)
                {
                    winMatchLevel3.achievementPercent = Mathf.Min(100.0f / 20.0f * userProperties.wonGames, 100.0f);
                }

                userProperties.winMatchLevel3 = winMatchLevel3.achievementPercent;

                if (notify && winMatchLevel3.achievementUnlocked)
                {
                    winMatchLevel3.ReportAchievement();
                }
            };
            achievementList.Add(winMatchLevel3);

            //**************************************Win Match Level4**********************************
            AchievementModel winMatchLevel4 = new AchievementModel()
            {
                achievementPercent = userProperties.winMatchLevel4,
                achievementIdentifier = "11",
                achievementName = ("Win 50 game"),
                achievementDescription = ("Win 50 game"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            winMatchLevel4.achievementBlock = (bool notify) =>
            {
                if (winMatchLevel4.achievementPercent != 100.0f)
                {
                    winMatchLevel4.achievementPercent = Mathf.Min(100.0f / 50.0f * userProperties.wonGames, 100.0f);
                }

                userProperties.winMatchLevel4 = winMatchLevel4.achievementPercent;

                if (notify && winMatchLevel4.achievementUnlocked)
                {
                    winMatchLevel4.ReportAchievement();
                }
            };
            achievementList.Add(winMatchLevel4);

            //**************************************Perfect Round**********************************
            AchievementModel perfectRound = new AchievementModel()
            {
                achievementPercent = userProperties.perfectRound,
                achievementIdentifier = "12",
                achievementName = ("Clean game"),
                achievementDescription = ("Clean game"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            perfectRound.achievementBlock = (bool notify) =>
            {
                /*if (perfectRound.achievementPercent != 100.0f && scoringManager.answeredQuestions == scoringManager.askedQuestions && scoringManager.askedQuestions >= 5)
                {
                    perfectRound.achievementPercent = 100.0f;
                }

                userProperties.perfectRound = perfectRound.achievementPercent;

                if (notify && perfectRound.achievementUnlocked)
                {
                    perfectRound.ReportAchievement();
                }*/
            };
            achievementList.Add(perfectRound);

            //**************************************Get back in the app level1**********************************
            AchievementModel getBackInTheAppLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.getBackInTheAppLevel1,
                achievementIdentifier = "13",
                achievementName = ("Relaunch 1 time the app"),
                achievementDescription = ("Relaunch 1 time the app"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            getBackInTheAppLevel1.achievementBlock = (bool notify) =>
            {
                if (getBackInTheAppLevel1.achievementPercent != 100.0f)
                {
                    getBackInTheAppLevel1.achievementPercent = Mathf.Min(100.0f / 2.0f * userProperties.openApp, 100.0f);
                }

                userProperties.getBackInTheAppLevel1 = getBackInTheAppLevel1.achievementPercent;

                if (notify && getBackInTheAppLevel1.achievementUnlocked)
                {
                    getBackInTheAppLevel1.ReportAchievement();
                }
            };
            achievementList.Add(getBackInTheAppLevel1);

            //**************************************Get back in the app level2**********************************
            AchievementModel getBackInTheAppLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.getBackInTheAppLevel2,
                achievementIdentifier = "14",
                achievementName = ("Relaunch 3 times the app"),
                achievementDescription = ("Relaunch 3 times the app"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            getBackInTheAppLevel2.achievementBlock = (bool notify) =>
            {
                if (getBackInTheAppLevel2.achievementPercent != 100.0f)
                {
                    getBackInTheAppLevel2.achievementPercent = Mathf.Min(100.0f / 4.0f * userProperties.openApp, 100.0f);
                }

                userProperties.getBackInTheAppLevel2 = getBackInTheAppLevel2.achievementPercent;

                if (notify && getBackInTheAppLevel2.achievementUnlocked)
                {
                    getBackInTheAppLevel2.ReportAchievement();
                }
            };
            achievementList.Add(getBackInTheAppLevel2);

            //**************************************Get back in the app level1**********************************
            AchievementModel getBackInTheAppLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.getBackInTheAppLevel3,
                achievementIdentifier = "15",
                achievementName = ("Relaunch 5 times the app"),
                achievementDescription = ("Relaunch 5 times the app"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            getBackInTheAppLevel3.achievementBlock = (bool notify) =>
            {
                if (getBackInTheAppLevel3.achievementPercent != 100.0f)
                {
                    getBackInTheAppLevel3.achievementPercent = Mathf.Min(100.0f / 6.0f * userProperties.openApp, 100.0f);
                }

                userProperties.getBackInTheAppLevel3 = getBackInTheAppLevel3.achievementPercent;

                if (notify && getBackInTheAppLevel3.achievementUnlocked)
                {
                    getBackInTheAppLevel3.ReportAchievement();
                }
            };
            achievementList.Add(getBackInTheAppLevel3);

            //**************************************Played match level1**********************************
            AchievementModel playedMatchLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.playedMatchLevel1,
                achievementIdentifier = "16",
                achievementName = ("Play 3 games"),
                achievementDescription = ("Play 3 games"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            playedMatchLevel1.achievementBlock = (bool notify) =>
            {
                if (playedMatchLevel1.achievementPercent != 100.0f)
                {
                    playedMatchLevel1.achievementPercent = Mathf.Min(100.0f / 3.0f * userProperties.playedGames, 100.0f);
                }

                userProperties.playedMatchLevel1 = playedMatchLevel1.achievementPercent;

                if (notify && playedMatchLevel1.achievementUnlocked)
                {
                    playedMatchLevel1.ReportAchievement();
                }
            };
            achievementList.Add(playedMatchLevel1);

            //**************************************Played match level2**********************************
            AchievementModel playedMatchLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.playedMatchLevel2,
                achievementIdentifier = "17",
                achievementName = ("Play 5 games"),
                achievementDescription = ("Play 5 games"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            playedMatchLevel2.achievementBlock = (bool notify) =>
            {
                if (playedMatchLevel2.achievementPercent != 100.0f)
                {
                    playedMatchLevel2.achievementPercent = Mathf.Min(100.0f / 5.0f * userProperties.playedGames, 100.0f);
                }

                userProperties.playedMatchLevel2 = playedMatchLevel2.achievementPercent;

                if (notify && playedMatchLevel2.achievementUnlocked)
                {
                    playedMatchLevel2.ReportAchievement();
                }
            };
            achievementList.Add(playedMatchLevel2);

            //**************************************Played match level3**********************************
            AchievementModel playedMatchLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.playedMatchLevel3,
                achievementIdentifier = "18",
                achievementName = ("Play 10 games"),
                achievementDescription = ("Play 10 games"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            playedMatchLevel3.achievementBlock = (bool notify) =>
            {
                if (playedMatchLevel3.achievementPercent != 100.0f)
                {
                    playedMatchLevel3.achievementPercent = Mathf.Min(100.0f / 10.0f * userProperties.playedGames, 100.0f);
                }

                userProperties.playedMatchLevel3 = playedMatchLevel3.achievementPercent;

                if (notify && playedMatchLevel3.achievementUnlocked)
                {
                    playedMatchLevel3.ReportAchievement();
                }
            };
            achievementList.Add(playedMatchLevel3);

            //**************************************Played match level4**********************************
            AchievementModel playedMatchLevel4 = new AchievementModel()
            {
                achievementPercent = userProperties.playedMatchLevel4,
                achievementIdentifier = "19",
                achievementName = ("Play 20 games"),
                achievementDescription = ("Play 20 games"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeEndGame
            };
            playedMatchLevel4.achievementBlock = (bool notify) =>
            {
                if (playedMatchLevel4.achievementPercent != 100.0f)
                {
                    playedMatchLevel4.achievementPercent = Mathf.Min(100.0f / 20.0f * userProperties.playedGames, 100.0f);
                }

                userProperties.playedMatchLevel4 = playedMatchLevel4.achievementPercent;

                if (notify && playedMatchLevel4.achievementUnlocked)
                {
                    playedMatchLevel4.ReportAchievement();
                }
            };
            achievementList.Add(playedMatchLevel4);

            //**************************************Submit Question**********************************
            AchievementModel submitQuestion = new AchievementModel()
            {
                achievementPercent = userProperties.submitQuestion,
                achievementIdentifier = "20",
                achievementName = ("Submit a question achievement"),
                achievementDescription = ("Submit a question achievement"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            submitQuestion.achievementBlock = (bool notify) =>
            {
                if (submitQuestion.achievementPercent != 100.0f)
                {
                    submitQuestion.achievementPercent = userProperties.submitQuestion;
                }
                else
                {
                    userProperties.submitQuestion = submitQuestion.achievementPercent;
                }

                if (notify && submitQuestion.achievementUnlocked)
                {
                    submitQuestion.ReportAchievement();
                }
            };
            achievementList.Add(submitQuestion);

            //**************************************Play training mode**********************************
            AchievementModel playTrainingMode = new AchievementModel()
            {
                achievementPercent = userProperties.playTrainingMode,
                achievementIdentifier = "21",
                achievementName = ("Training mode"),
                achievementDescription = ("Training mode"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            playTrainingMode.achievementBlock = (bool notify) =>
            {
                if (playTrainingMode.achievementPercent != 100.0f)
                {
                    playTrainingMode.achievementPercent = userProperties.playTrainingMode;
                }
                else
                {
                    userProperties.playTrainingMode = playTrainingMode.achievementPercent;
                }

                if (notify && playTrainingMode.achievementUnlocked)
                {
                    playTrainingMode.ReportAchievement();
                }
            };
            achievementList.Add(playTrainingMode);

            //**************************************Play simulteanously Matches level1**********************************
            AchievementModel playSimulteanouslyMatchesLevel1 = new AchievementModel()
            {
                achievementPercent = userProperties.playSimulteanouslyMatchesLevel1,
                achievementIdentifier = "22",
                achievementName = ("2 games simultaneous"),
                achievementDescription = ("2 games simultaneous"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            playSimulteanouslyMatchesLevel1.achievementBlock = (bool notify) =>
            {
                /*if (playSimulteanouslyMatchesLevel1.achievementPercent != 100.0f && MultiplayerManager.Instance.GetActiveGamesNumber() >= 2)
                {
                    playSimulteanouslyMatchesLevel1.achievementPercent = 100.0f;
                }

                userProperties.playSimulteanouslyMatchesLevel1 = playSimulteanouslyMatchesLevel1.achievementPercent;

                if (notify && playSimulteanouslyMatchesLevel1.achievementUnlocked)
                {
                    playSimulteanouslyMatchesLevel1.ReportAchievement();
                }*/
            };
            achievementList.Add(playSimulteanouslyMatchesLevel1);

            //**************************************Play simulteanously Matches level2**********************************
            AchievementModel playSimulteanouslyMatchesLevel2 = new AchievementModel()
            {
                achievementPercent = userProperties.playSimulteanouslyMatchesLevel2,
                achievementIdentifier = "23",
                achievementName = ("4 games simultaneous"),
                achievementDescription = ("4 games simultaneous"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            playSimulteanouslyMatchesLevel2.achievementBlock = (bool notify) =>
            {
                /*if (playSimulteanouslyMatchesLevel2.achievementPercent != 100.0f && MultiplayerManager.Instance.GetActiveGamesNumber() >= 4)
                {
                    playSimulteanouslyMatchesLevel2.achievementPercent = 100.0f;
                }

                userProperties.playSimulteanouslyMatchesLevel2 = playSimulteanouslyMatchesLevel2.achievementPercent;

                if (notify && playSimulteanouslyMatchesLevel2.achievementUnlocked)
                {
                    playSimulteanouslyMatchesLevel2.ReportAchievement();
                }*/
            };
            achievementList.Add(playSimulteanouslyMatchesLevel2);

            //**************************************Play simulteanously Matches level3**********************************
            AchievementModel playSimulteanouslyMatchesLevel3 = new AchievementModel()
            {
                achievementPercent = userProperties.playSimulteanouslyMatchesLevel3,
                achievementIdentifier = "24",
                achievementName = ("10 games simultaneous"),
                achievementDescription = ("10 games simultaneous"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            playSimulteanouslyMatchesLevel3.achievementBlock = (bool notify) =>
            {
                /*if (playSimulteanouslyMatchesLevel3.achievementPercent != 100.0f && MultiplayerManager.Instance.GetActiveGamesNumber() >= 10)
                {
                    playSimulteanouslyMatchesLevel3.achievementPercent = 100.0f;
                }

                userProperties.playSimulteanouslyMatchesLevel3 = playSimulteanouslyMatchesLevel3.achievementPercent;

                if (notify && playSimulteanouslyMatchesLevel3.achievementUnlocked)
                {
                    playSimulteanouslyMatchesLevel3.ReportAchievement();
                }*/
            };
            achievementList.Add(playSimulteanouslyMatchesLevel3);

            //**************************************Purchase premium version**********************************
            AchievementModel purchasePremiumVersion = new AchievementModel()
            {
                achievementPercent = userProperties.purchasePremiumVersion,
                achievementIdentifier = "25",
                achievementName = ("Get premium version"),
                achievementDescription = ("Get premium version"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            purchasePremiumVersion.achievementBlock = (bool notify) =>
            {
                if (purchasePremiumVersion.achievementPercent != 100.0f)
                {
                    purchasePremiumVersion.achievementPercent = userProperties.purchasePremiumVersion;
                }
                else
                {
                    userProperties.purchasePremiumVersion = purchasePremiumVersion.achievementPercent;
                }

                if (notify && purchasePremiumVersion.achievementUnlocked)
                {
                    purchasePremiumVersion.ReportAchievement();
                }
            };
            achievementList.Add(purchasePremiumVersion);

            //**************************************Send facebook request**********************************
            AchievementModel sendFacebookRequest = new AchievementModel()
            {
                achievementPercent = userProperties.sendFacebookRequest,
                achievementIdentifier = "26",
                achievementName = ("Facebook request"),
                achievementDescription = ("Facebook request"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            sendFacebookRequest.achievementBlock = (bool notify) =>
            {
                if (sendFacebookRequest.achievementPercent != 100.0f)
                {
                    sendFacebookRequest.achievementPercent = userProperties.sendFacebookRequest;
                }
                else
                {
                    userProperties.sendFacebookRequest = sendFacebookRequest.achievementPercent;
                }

                if (notify && sendFacebookRequest.achievementUnlocked)
                {
                    sendFacebookRequest.ReportAchievement();
                }
            };
            achievementList.Add(sendFacebookRequest);

            //**************************************Watch video**********************************
            AchievementModel watchVideo = new AchievementModel()
            {
                achievementPercent = userProperties.watchVideo,
                achievementIdentifier = "27",
                achievementName = ("Watch a video"),
                achievementDescription = ("Watch a video"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            watchVideo.achievementBlock = (bool notify) =>
            {
                if (watchVideo.achievementPercent != 100.0f)
                {
                    watchVideo.achievementPercent = userProperties.watchVideo;
                }
                else
                {
                    userProperties.watchVideo = watchVideo.achievementPercent;
                }

                if (notify && watchVideo.achievementUnlocked)
                {
                    watchVideo.ReportAchievement();
                }
            };
            achievementList.Add(watchVideo);

            //**************************************Add friend**********************************
            AchievementModel addFriend = new AchievementModel()
            {
                achievementPercent = userProperties.addFriend,
                achievementIdentifier = "28",
                achievementName = ("Add a friend"),
                achievementDescription = ("Add a friend"),
                achievementUpdateType = AchievementModel.AchievementUpdateType.AchievementUpdateTypeSpecialEvent
            };
            addFriend.achievementBlock = (bool notify) =>
            {
                if (addFriend.achievementPercent != 100.0f)
                {
                    addFriend.achievementPercent = userProperties.addFriend;
                }
                else
                {
                    userProperties.addFriend = addFriend.achievementPercent;
                }

                if (notify && addFriend.achievementUnlocked)
                {
                    addFriend.ReportAchievement();
                }
            };
            achievementList.Add(addFriend);
        }

        // Use this for initialization
        void Start()
        {
            //AccountManager.Instance.onConnectAccountFinished += HandleOnConnecting;
            //AccountManager.Instance.onConnectFacebookAccountFinished += HandleOnConnecting;
            //AccountManager.Instance.onLogout += HandleOnLoggingOut;
        }

        //private void HandleOnConnecting(AccountManager script, System.EventArgs e)
        //{
        //    RetrieveAchievements();
        //    //UpdateAchievements (AchievementModel.AchievementUpdateType.AchievementUpdateTypeAll, false);
        //}

        //private void HandleOnLoggingOut(AccountManager script, System.EventArgs e)
        //{
        //    //ClearAchievements ();
        //}

        private void ClearAchievements()
        {
            PlayerPrefs.DeleteKey("beatRoundScoreLevel1");
            PlayerPrefs.DeleteKey("beatRoundScoreLevel2");
            PlayerPrefs.DeleteKey("beatRoundScoreLevel3");
            PlayerPrefs.DeleteKey("beatRoundScoreLevel4");
            PlayerPrefs.DeleteKey("useHintsLevel1");
            PlayerPrefs.DeleteKey("useHintsLevel2");
            PlayerPrefs.DeleteKey("useHintsLevel3");
            PlayerPrefs.DeleteKey("winMatchLevel1");
            PlayerPrefs.DeleteKey("winMatchLevel2");
            PlayerPrefs.DeleteKey("winMatchLevel3");
            PlayerPrefs.DeleteKey("winMatchLevel4");
            PlayerPrefs.DeleteKey("perfectRound");
            PlayerPrefs.DeleteKey("getBackInTheAppLevel1");
            PlayerPrefs.DeleteKey("getBackInTheAppLevel2");
            PlayerPrefs.DeleteKey("getBackInTheAppLevel3");
            PlayerPrefs.DeleteKey("playedMatchLevel1");
            PlayerPrefs.DeleteKey("playedMatchLevel2");
            PlayerPrefs.DeleteKey("playedMatchLevel3");
            PlayerPrefs.DeleteKey("playedMatchLevel4");
            PlayerPrefs.DeleteKey("submitQuestion");
            PlayerPrefs.DeleteKey("playTrainingMode");
            PlayerPrefs.DeleteKey("playSimulteanouslyMatchesLevel1");
            PlayerPrefs.DeleteKey("playSimulteanouslyMatchesLevel2");
            PlayerPrefs.DeleteKey("playSimulteanouslyMatchesLevel3");
            PlayerPrefs.DeleteKey("purchasePremiumVersion");
            PlayerPrefs.DeleteKey("sendFacebookRequest");
            PlayerPrefs.DeleteKey("watchVideo");
            PlayerPrefs.DeleteKey("addFriend");

            PlayerPrefs.Save();
        }

        public void OnDestroy()
        {

        }

        public void UpdateAchievements(AchievementModel.AchievementUpdateType type, bool notify)
        {
            StartCoroutine(UpdateAchievementsWithEnumerator(type, notify));
        }

        private IEnumerator UpdateAchievementsWithEnumerator(AchievementModel.AchievementUpdateType type, bool notify)
        {
            foreach (AchievementModel achievement in achievementList)
            {
                if (achievement != null &&
                    (achievement.achievementUpdateType == type || type == AchievementModel.AchievementUpdateType.AchievementUpdateTypeAll) &&
                    achievement.achievementPercent < 100.0f)
                {
                    achievement.Update(notify);
                    yield return 0;
                }
            }
        }

        public int GetUnlockedAchievementsNumber()
        {
            int total = 0;

            foreach (AchievementModel achievement in achievementList)
            {
                if (achievement.achievementUnlocked)
                {
                    ++total;
                }
            }
            return total;
        }

        public AchievementModel GetAchievement(string identifier)
        {
            foreach (AchievementModel achievement in achievementList)
            {
                if (achievement.achievementIdentifier == identifier)
                {
                    return achievement;
                }
            }
            return null;
        }

        public void ReportAchievement(string achievementIdentifier)
        {
            //if (AccountManager.Instance.isConnected)
            //{
            //    Dictionary<string, string> args = new Dictionary<string, string>();

            //    args.Add("user_token", AccountManager.Instance.userAccount.accountToken);
            //    args.Add("achievement_id", achievementIdentifier);

            //    APIManager.Instance.HttpPostRequest(REPORT_ACHIEVEMENT, args, (HTTPClient client) =>
            //    {
            //        IHTTPResponse response = client.Response;

            //        if (response != null)
            //        {
            //            Debug.Log(response.StatusCode + " " + response.ContentToString());
            //        }

            //        if (response != null && response.StatusCode == (long)APIManager.ReturnCodes.CREATED)
            //        {
            //            if (onReportAchievementFinished != null) onReportAchievementFinished(this, null);
            //        }
            //        else if (response != null && response.StatusCode == (long)APIManager.ReturnCodes.BAD_REQUEST)
            //        {
            //            if (onReportAchievementRejected != null) onReportAchievementRejected(this, null);
            //        }
            //        else
            //        {
            //            if (APIManager.Instance.onFailedConnection != null) APIManager.Instance.onFailedConnection(APIManager.Instance, null);
            //        }
            //    });
            //}
        }

        public void RetrieveAchievements()
        {
            //if (AccountManager.Instance.isConnected)
            //{
            //    APIManager.Instance.HttpGetRequest(RETRIEVE_ACHIEVEMENTS + AccountManager.Instance.userAccount.accountToken, (HTTPClient client) =>
            //    {
            //        IHTTPResponse response = client.Response;

            //        if (response != null)
            //        {
            //            Debug.Log(response.StatusCode + " " + response.ContentToString());
            //        }

            //        if (response != null && response.StatusCode == (long)APIManager.ReturnCodes.OK)
            //        {
            //            string content = client.Response.ContentToString();
            //            JSONNode node = JSONNode.Parse(content);

            //            foreach (JSONNode child in node.Childs)
            //            {
            //                AchievementModel model = GetAchievement(child["achievement_id"]);

            //                if (model != null)
            //                {
            //                    if (model.achievementPercent != 100.0f)
            //                    {
            //                        model.achievementPercent = 100.0f;
            //                        model.Update(false);
            //                    }
            //                }
            //            }
            //            if (onRetrieveAchievementsFinished != null) onRetrieveAchievementsFinished(this, null);
            //        }
            //        else if (response != null && response.StatusCode == (long)APIManager.ReturnCodes.BAD_REQUEST)
            //        {
            //            if (onRetrieveAchievementsRejected != null) onRetrieveAchievementsRejected(this, null);
            //        }
            //        else
            //        {
            //            if (APIManager.Instance.onFailedConnection != null) APIManager.Instance.onFailedConnection(APIManager.Instance, null);
            //        }
            //    });
            //}
        }

        public void UnlockedAchievement(AchievementModel model)
        {
            AchievementArgs args = new AchievementArgs();

            args.achievementList = new List<AchievementModel>();
            args.achievementList.Add(model);

            if (onUnlockedAchievement != null) onUnlockedAchievement(this, args);
        }
    }
}
