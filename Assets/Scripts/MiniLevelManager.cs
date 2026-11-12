using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;


public class MiniLevelManager : MonoBehaviour
{
    public LevelManager levelManager;
    public WeatherSystemManager weatherSpawnManager;

    public HealthSystem healthSystem;
    public SceneSwitchManager sceneSwitchManager;

    public LevelUI levelUI;

    public void IncrementMiniLevel()
    {
        int miniLevel = PlayerPrefs.GetInt("CurrentMiniLevel", 0);

        LevelConfig currentLevel = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel", 0)];

        if (miniLevel >= currentLevel.miniLevels.Count)
        {
            miniLevel = 0;

            PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);

            levelManager.IncrementLevel();
            sceneSwitchManager.StartInterlude();
            return ;
        }

        miniLevel++;


        PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);




        StartCoroutine(StartMiniLevelBreakTimeCount());
        
        
        
    }

    public IEnumerator StartMiniLevelBreakTimeCount()
    {
        
        yield return StartCoroutine(weatherSpawnManager.DeactivateWeatherSpawners(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel", 1)].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel", 1)].weatherSpawnerActivationInterval));
        levelUI.ClearMiniLevelUI();
        healthSystem.StartCoroutine(healthSystem.SlideHealthBarToMax());
        yield return new WaitForSeconds(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel", 1)].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel", 1)].intervalAfter);
        
        
        StopCoroutine(StartMiniLevelTimeCount());
        StartCoroutine(StartMiniLevelTimeCount());
        
        
    }

    

    public IEnumerator StartMiniLevelTimeCount()
    {
        levelUI.UpdateMiniLevelUI();

        float weatherActionIntervalMin = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionIntervalMin;
        float weatherActionIntervalMax = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionIntervalMax;
        float weatherActionLeftSpeed = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionLeftSpeed;
        float weatherActionFallSpeed = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherActionFallSpeed;
        float weatherSpawnerActivationInterval = Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].weatherSpawnerActivationInterval;   
        StartCoroutine(weatherSpawnManager.ActivateWeatherSpawners(
            weatherSpawnerActivationInterval,
            weatherActionIntervalMin,
            weatherActionIntervalMax,
            weatherActionLeftSpeed,
            weatherActionFallSpeed));
        yield return new WaitForSeconds(Config.config.levels[PlayerPrefs.GetInt("CurrentLevel")].miniLevels[PlayerPrefs.GetInt("CurrentMiniLevel")].duration);
        
        IncrementMiniLevel();
        
        
    }
}
