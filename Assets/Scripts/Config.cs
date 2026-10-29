using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Config
    {
        
        #region GameProgress
        public static int currentInterlude = 0;
        public static int currentLevel = 0;

        public static int currentMiniLevel = 0;

        public static int maxInterludeIndex = 3;

        public static int maxMiniLevelIndex = 3;

        #endregion

        #region LevelNames

        public static List<string> levelNames = new List<string>()
        {
            "Level 1: Sadness",
            "Level 2: Anger",
            "Level 3: Anxiety"

        };

        #endregion

        #region LevelTimes

        public static float rainLevelTime = 3f;

        public static float generalLevelTime = 5f;

        #endregion

        #region Scene Names
        public static string mainmenuScene = "MainMenu";

        public static string flyingGameplayScene = "FlyingGameplay";

        public static string interludeScene = "Interludes";

        #endregion

        #region Movement Config
        public static float flySpeed = 3f;

        public static float walkSpeed = 10f;

        public static float scrollSpeed = 1f;
        
        #endregion

        #region Wind Level
        public static float secondsBetweenWindMin = 1f;

        public static float secondsBetweenWindMax = 3f;

        public static float windMoveLeftSpeed = 1f;

        public static float secondsBetweenWindSpawnerActivation = 1f;

        #endregion

        #region Rain Level
        public static float secondsBetweenRainDropsMin = 1f;

        public static float secondsBetweenRainDropsMax = 3f;
        public static float rainDropFallSpeed = 1f;

        public static float secondsBetweenRainDropSpawnerActivation = 1f;

        public static float dropMoveLeftSpeed = 1f;
        
        #endregion

        #region Lightning Level
        public static float secondsBetweenLightningStrikeMin = 1f;

        public static float secondsBetweenLightningStrikeMax = 3f;

        public static float secondsBetweenLightningSpawnerActivation = 1f;

        public static float timeBetweenLightningStrikes = 1f;

        public static float timeToDestroyLightningStrike = 0.2f;

        #endregion

        #region Dialogue System

        public static float dialogueSwitcherSpeed = 2f;

        #endregion

    }
}
