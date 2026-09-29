using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitchManager : MonoBehaviour
{

    public string mainmenuScene = "MainMenu";

    public string flyingGameplayScene = "FlyingGameplay";

    public string interludeScene = "Interludes";

    public FlyingGameplayStarter flyingGameplayStarter;

    public HealthSystem healthSystem;

    void Awake()
    {
        if (!healthSystem)
        {
            healthSystem = FindAnyObjectByType<HealthSystem>();
        }
    }

    void OnEnable()
    {
        healthSystem.OnStartLevelOver += StartFlyingGameplay;
    }


    void Start()
    {
        if (!flyingGameplayStarter)
        {
            flyingGameplayStarter = FindAnyObjectByType<FlyingGameplayStarter>();
        }
    }


    
    public void StartInterlude()
    {
        Debug.Log("in start interlude");
        SceneManager.LoadScene(interludeScene);
    }

    public void StartFlyingGameplay()
    {
        Debug.Log("in start flying gameplay");
        SceneManager.LoadScene(flyingGameplayScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnDisable()
    {
        healthSystem.OnStartLevelOver -= StartFlyingGameplay;
    }



    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a standalone build
        Application.Quit();
        #endif
    }


}