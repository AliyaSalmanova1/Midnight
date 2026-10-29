using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;


public class LevelManager : MonoBehaviour
{


    public int currentLevel = 0;



    public SceneSwitchManager sceneSwitchManager;

    public FlyingGameplayStarter flyingGameplayStarter;

    public WeatherSystemManager weatherSystemManager;

    public HealthSystem healthSystem;

    public LevelUI levelUI;

    
    void Start()
    {
        if (!levelUI)
        {
            levelUI = FindAnyObjectByType<LevelUI>();
        }
        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }
        if (!weatherSystemManager)
        {
            weatherSystemManager = FindAnyObjectByType<WeatherSystemManager>();
        }
        if (!flyingGameplayStarter)
        {
            flyingGameplayStarter = FindAnyObjectByType<FlyingGameplayStarter>();
        }
        

        

        if (SceneManager.GetActiveScene().name == Config.flyingGameplayScene)
        {

            StartLevelTimeCountCoroutine();
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        
    }



    public void StartLevelTimeCountCoroutine()
    {
        StopCoroutine(StartLevelTimeCount());
        StartCoroutine(StartLevelTimeCount());
    }



    IEnumerator StartLevelTimeCount()
    {
        levelUI.levelText.text = "Level " + Config.levelNames[PlayerPrefs.GetInt("CurrentLevel")];
        levelUI.miniLevelText.text = "Mini Level " + (PlayerPrefs.GetInt("CurrentMiniLevel") + 1);
        yield return new WaitForSeconds(Config.generalLevelTime);
        Debug.Log("in StartLevelTimeCount");
        
        IncrementMiniLevel();
        
        
    }

    public void IncrementMiniLevel()
    {
        int miniLevel = PlayerPrefs.GetInt("CurrentMiniLevel");

        miniLevel++;

        Debug.Log("Current Mini Level: " + miniLevel);

        PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);

        healthSystem.ResetHealth();

        if (miniLevel >= Config.maxMiniLevelIndex)
        {
            miniLevel = 0;

            PlayerPrefs.SetInt("CurrentMiniLevel", miniLevel);

            IncrementLevel();
            sceneSwitchManager.StartInterlude();
        }
        else
        {

            Debug.Log("Starting next mini level");
            StartLevelTimeCountCoroutine();
        }

        
    }


    public void IncrementLevel()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");

        level++;



        levelUI.levelText.text = "Level " + Config.levelNames[level];
        levelUI.miniLevelText.text = "Mini Level " + PlayerPrefs.GetInt("CurrentMiniLevel");

        PlayerPrefs.SetInt("CurrentLevel", level);
    }

    public void IncrementInterlude()
    {
        Config.currentInterlude++;
        PlayerPrefs.SetInt("CurrentInterlude", Config.currentInterlude);
    }


    
}