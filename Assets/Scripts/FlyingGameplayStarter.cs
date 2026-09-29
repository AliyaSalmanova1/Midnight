using System;
using UnityEngine;

public class FlyingGameplayStarter : MonoBehaviour
{

    public SceneSwitchManager sceneSwitchManager;

    public LevelManager levelManager;

    public event Action OnFlyingLevelStart;
    

    void Start()
    {
        sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();

        if (!levelManager)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Girl"))
        {
            int currentInterludeIndex = PlayerPrefs.GetInt("CurrentInterlude");

            if (currentInterludeIndex == 3)
            {
                sceneSwitchManager.GoToMainMenu();
            }
            else
            {
                currentInterludeIndex++;
                PlayerPrefs.SetInt("CurrentInterlude", currentInterludeIndex);
                sceneSwitchManager.StartFlyingGameplay(); 
            }
                
        }
    }
}
