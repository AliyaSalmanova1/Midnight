using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    public int playerHealth = 100;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WeatherObstacle"))
        {
            playerHealth -= 10;
        }
    }

}