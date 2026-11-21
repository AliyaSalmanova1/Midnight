using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;


public class MiniLevelManager : MonoBehaviour
{
    public LevelManager levelManager;


    public HealthSystem healthSystem;
    public SceneSwitchManager sceneSwitchManager;

    public WeatherSystemConfig weatherSystemConfig;

    public LevelUI levelUI;

    void Start()
    {
        if (!levelManager)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }

        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }

        if (!weatherSystemConfig)
        {
            weatherSystemConfig = FindAnyObjectByType<WeatherSystemConfig>();
        }

        if (!levelUI)
        {
            levelUI = FindAnyObjectByType<LevelUI>();
        }
    }

    public void IncrementMiniLevel()
    {
        int miniLevel = PlayerPrefs.GetInt("CurrentMiniLevel", 0);

        LevelConfig currentLevel = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel", 0)];

        if (miniLevel >= currentLevel.miniLevels.Count - 1)
        {
            miniLevel = 0;

            PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);

            levelManager.IncrementLevel();
            sceneSwitchManager.StartInterlude();
            return ;
        }

        miniLevel++;


        PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);


        StartCoroutine(StartMiniLevelTimeCount());
        
        
        
    }

    public IEnumerator StartMiniLevelBreakTimeCount()
    {
        
        yield return StartCoroutine(weatherSystemConfig.weatherSystemManagers[PlayerPrefs.GetInt("CurrentLevel", 0)].DeactivateWeatherSpawners(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherSpawnerActivationInterval));
        levelUI.ClearMiniLevelUI();
        healthSystem.StartCoroutine(healthSystem.SlideHealthBarToMax());
        yield return new WaitForSeconds(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].intervalAfter);
        
        
        IncrementMiniLevel();
        
        
    }

    

    public IEnumerator StartMiniLevelTimeCount()
    {
        levelUI.UpdateMiniLevelUI();

        float weatherActionIntervalMin = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionIntervalMin;
        float weatherActionIntervalMax = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionIntervalMax;
        float weatherActionLeftSpeed = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionLeftSpeed;
        float weatherActionFallSpeed = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionFallSpeed;
        float weatherSpawnerActivationInterval = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherSpawnerActivationInterval;   
        StartCoroutine(weatherSystemConfig.weatherSystemManagers[PlayerPrefs.GetInt("CurrentLevel", 0)].GetComponent<WeatherSystemManager>().ActivateWeatherSpawners(
            weatherSpawnerActivationInterval,
            weatherActionIntervalMin,
            weatherActionIntervalMax,
            weatherActionLeftSpeed,
            weatherActionFallSpeed));
        yield return new WaitForSeconds(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].duration);
        
        StartCoroutine(StartMiniLevelBreakTimeCount());
        
        
    }

    public void StopAllMiniLevelCoroutines()
    {
        StopAllCoroutines();
    }
}
