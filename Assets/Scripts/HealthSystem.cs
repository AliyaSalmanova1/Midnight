using System;
using UnityEngine;
using UnityEngine.UI;



public class HealthSystem : MonoBehaviour
{
    public float playerHealth = 1f;

    public Slider healthSlider;

    public event Action OnStartLevelOver;

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

}