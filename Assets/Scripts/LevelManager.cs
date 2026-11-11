using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;


public class LevelManager : MonoBehaviour
{
    public MiniLevelManager miniLevelManager;


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

            StopCoroutine(miniLevelManager.StartMiniLevelTimeCount());
            levelUI.UpdateLevelUI();
            PlayerPrefs.SetInt("CurrentMiniLevel", 0);
            StartCoroutine(miniLevelManager.StartMiniLevelTimeCount());
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        
    }






    public void IncrementLevel()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");

        level++;


        levelUI.UpdateLevelUI();
        

        PlayerPrefs.SetInt("CurrentLevel", level);
    }

    public void IncrementInterlude()
    {
        Config.currentInterlude++;
        PlayerPrefs.SetInt("CurrentInterlude", Config.currentInterlude);
    }


    
}