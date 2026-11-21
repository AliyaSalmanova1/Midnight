using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;



public class HealthSystem : MonoBehaviour
{
    public float playerHealth = 1f;

    public float sliderUpwardMovementSpeed = .3f;

    public Slider healthSlider;

    public SceneSwitchManager sceneSwitchManager;

    public PlayerFallBehavior playerFallBehavior;
    

    public MiniLevelManager miniLevelManager;

    void Start()
    {
        if (!miniLevelManager)
        {
            miniLevelManager = FindAnyObjectByType<MiniLevelManager>();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WeatherObstacle"))
        {

            playerHealth -= .1f;
            healthSlider.value = playerHealth;

            if (playerHealth <= 0)
            {


                //miniLevelManager.StopAllMiniLevelCoroutines();

  
                playerFallBehavior.StartPlayerFall(() =>
                {

                    
                    sceneSwitchManager.StartFlyingGameplay();
                });
            }
        }
    }

    public void ResetHealth()
    {
        playerHealth = 1f;
        healthSlider.value = playerHealth;
    }

    public IEnumerator SlideHealthBarToMax()
    {
        float time = Config.config.levels[Config.config.currentLevel].miniLevels[Config.config.currentMiniLevel].intervalAfter;

        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            healthSlider.value += Mathf.Lerp(healthSlider.value, 1f, sliderUpwardMovementSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ResetHealth();
    }



}