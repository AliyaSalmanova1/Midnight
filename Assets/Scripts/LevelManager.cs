using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;


public class LevelManager : MonoBehaviour
{


    public int currentLevel = 0;

    int currentinterlude = 0;

    public SceneSwitchManager sceneSwitchManager;

    public FlyingGameplayStarter flyingGameplayStarter;

    public WeatherSystemManager weatherSystemManager;

    public HealthSystem healthSystem;

    
    void Start()
    {
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
        StartCoroutine(StartLevelTimeCount());
    }



    IEnumerator StartLevelTimeCount()
    {
        yield return new WaitForSeconds(Config.generalLevelTime);
        Debug.Log("in StartLevelTimeCount");
        IncrementLevel();
        sceneSwitchManager.StartInterlude();
    }

    public void IncrementLevel()
    {
        int level = PlayerPrefs.GetInt("CurrentLevel");

        level++;

        PlayerPrefs.SetInt("CurrentLevel", level);
    }

    public void IncrementInterlude()
    {
        currentinterlude++;
        PlayerPrefs.SetInt("CurrentInterlude", currentinterlude);
    }


    
}