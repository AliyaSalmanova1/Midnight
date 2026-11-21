using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;




public class ConfigSingleton : MonoBehaviour
{

    public static ConfigSingleton instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

        
    #region GameProgress
    public  int currentInterlude = 0;
    public  int currentLevel = 0;

    public  int currentMiniLevel = 0;

    public  int maxInterludeIndex = 3;

    public  int maxMiniLevelIndex = 3;

    #endregion

    #region LevelNames

    public  List<string> levelNames = new List<string>()
    {
        "Level 1: Sadness",
        "Level 2: Anger",
        "Level 3: Anxiety"

    };

    #endregion

    #region LevelTimes

    public  float rainLevelTime = 3f;

    public  float generalLevelTime = 5f;

    #endregion

    #region Scene Names
    public  string mainmenuScene = "MainMenu";

    public  string flyingGameplayScene = "FlyingGameplay";

    public  string interludeScene = "Interludes";

    #endregion

    #region Movement Config
    public  float flySpeed = 5f;

    public  float walkSpeed = 10f;

    public  float scrollSpeed = 1f;
    
    #endregion

    #region Wind Level
    public  float secondsBetweenWindMin = 1f;

    public  float secondsBetweenWindMax = 3f;

    public  float windMoveLeftSpeed = 1f;

    public  float secondsBetweenWindSpawnerActivation = 1f;

    #endregion

    #region Rain Level


    public  float secondsBetweenRainDropsMin = 1f;

    public  float secondsBetweenRainDropsMax = 3f;
    public  float rainDropFallSpeed = 1f;

    public  float secondsBetweenRainDropSpawnerActivation = 1f;

    public  float dropMoveLeftSpeed = 1f;
    
    #endregion

    #region Lightning Level
    public  float secondsBetweenLightningStrikeMin = 1f;

    public  float secondsBetweenLightningStrikeMax = 3f;

    public  float secondsBetweenLightningSpawnerActivation = 1f;

    public  float timeBetweenLightningStrikes = 1f;

    public  float timeToDestroyLightningStrike = 0.2f;

    #endregion

    #region Dialogue System

    public  float dialogueSwitcherSpeed = 2f;

    #endregion



    #region Level Configuration



    [SerializeField]
    public  List<LevelConfig> levels = new List<LevelConfig>()
    {
        new LevelConfig("Level 1: Sadness", new List<MiniLevelConfig>()
        {
            new MiniLevelConfig(20f, 4f, 2f, 4f, 10f, 4f, 1f),
            new MiniLevelConfig(20f, 4f, 1f, 3f, 10f, 4f, 1f),
            new MiniLevelConfig(35f, 4f, 2f, 4f, 10f, 4f, 1f)
        }),

        new LevelConfig("Level 2: Anxiety", new List<MiniLevelConfig>()
        {
            new MiniLevelConfig(5f, 4f, 1f, 3f, 5f, 1f, 1f),
            new MiniLevelConfig(10f, 4f, 1f, 3f, -5f, -1f, 1f),
            new MiniLevelConfig(15f, 4f, 1f, 3f, -5f, -1f, 1f)
        }),

        new LevelConfig("Level 3: Anger", new List<MiniLevelConfig>()
        {
            new MiniLevelConfig(5f, 4f, 1f, 3f, 1f, 1f, 1f),
            new MiniLevelConfig(10f, 4f, 1f, 3f, 1f, 1f, 1f),
            new MiniLevelConfig(15f, 4f, 1f, 3f, 1f, 1f, 1f)
        })
    };
    #endregion



}

[System.Serializable]
public class WeatherSystemManagers
{
    public WeatherSystemManager rainWeatherSystemManager;
    public WeatherSystemManager windWeatherSystemManager;
    public WeatherSystemManager lightningWeatherSystemManager;
}



[System.Serializable]
public class MiniLevelConfig
{
    public float duration;
    public float intervalAfter;

    public float weatherActionIntervalMin;

    public float weatherActionIntervalMax;
    

    public float weatherActionLeftSpeed;

    public float weatherActionFallSpeed;

    public float weatherSpawnerActivationInterval;

    

    public MiniLevelConfig(float duration, float intervalAfter, float weatherActionIntervalMin, float weatherActionIntervalMax, float weatherActionLeftSpeed, float weatherActionFallSpeed, float weatherSpawnerActivationInterval)
    {
        this.duration = duration;
        this.intervalAfter = intervalAfter;
        this.weatherActionIntervalMin = weatherActionIntervalMin;
        this.weatherActionIntervalMax = weatherActionIntervalMax;
        this.weatherActionLeftSpeed = weatherActionLeftSpeed;
        this.weatherActionFallSpeed = weatherActionFallSpeed;
        this.weatherSpawnerActivationInterval = weatherSpawnerActivationInterval;
    }
}

[System.Serializable]
public class LevelConfig
{
    public string name;

    public List<MiniLevelConfig> miniLevels;

    public LevelConfig(string name, List<MiniLevelConfig> miniLevels)
    {
        this.name = name;
        this.miniLevels = miniLevels;

    }
}




