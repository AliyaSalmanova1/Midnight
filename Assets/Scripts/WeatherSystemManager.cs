using UnityEngine;
using UnityEngine.SceneManagement;


public class WeatherSystemManager : MonoBehaviour
{
    public GameObject rainSystem;
    public GameObject lightningSystem;

    public GameObject windSystem;

    public LevelManager levelManager;

    public FlyingGameplayStarter flyingGameplayStarter;


    void Start()
    {
        if (levelManager)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }
        if (flyingGameplayStarter)
        {
            flyingGameplayStarter = FindAnyObjectByType<FlyingGameplayStarter>();
        }

        SetWeatherSystem();
    }



    void SetWeatherSystem()
    {
        
        switch (PlayerPrefs.GetInt("CurrentLevel"))
        {
            case 0:
                rainSystem.SetActive(true);
                lightningSystem.SetActive(false);
                windSystem.SetActive(false);
                break;
            case 1:
                lightningSystem.SetActive(true);
                rainSystem.SetActive(false);
                windSystem.SetActive(false);
                break;
            case 2:
                windSystem.SetActive(true);
                rainSystem.SetActive(false);
                lightningSystem.SetActive(false);
                break;
            default:
                break;

        }
    }
    
}