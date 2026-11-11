using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class HealthSystem : MonoBehaviour
{
    public float playerHealth = 1f;

    public float sliderUpwardMovementSpeed = .3f;

    public Slider healthSlider;

    public SceneSwitchManager sceneSwitchManager;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WeatherObstacle"))
        {

            playerHealth -= .1f;
            healthSlider.value = playerHealth;

            if (playerHealth <= 0)
            {
    
                sceneSwitchManager.StartFlyingGameplay();
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
        while (healthSlider.value < 1f)
        {
            healthSlider.value += sliderUpwardMovementSpeed * Time.deltaTime;
            yield return null;
        }
        ResetHealth();
    }



}