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

        if (!flyingGameplayStarter)
        {
            flyingGameplayStarter = FindAnyObjectByType<FlyingGameplayStarter>();
        }
        

        

        if (SceneManager.GetActiveScene().name == Config.config.flyingGameplayScene)
        {

            StopCoroutine(miniLevelManager.StartMiniLevelTimeCount());
            levelUI.UpdateLevelUI();
          
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
        Config.config.currentInterlude++;
        PlayerPrefs.SetInt("CurrentInterlude", Config.config.currentInterlude);
    }


    
}