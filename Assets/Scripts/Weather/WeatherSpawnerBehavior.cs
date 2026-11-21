using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WeatherSpawnerBehavior : MonoBehaviour
{
    public GameObject weatherPiecePrefab;

    public IEnumerator SpawnWeatherPiece(float weatherActionIntervalMin = 0f,
        float weatherActionIntervalMax = 0f,
        float weatherActionLeftSpeed = 0f,
        float weatherActionFallSpeed = 0f,
        float weatherSpawnerActivationInterval = 0f,
        GameObject weatherSpawner = null)
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(weatherPiecePrefab, weatherSpawner.transform);

            int currentMiniLevel = PlayerPrefs.GetInt("CurrentMiniLevel");

            float randomAmountOfSecs = Random.Range(weatherActionIntervalMin, weatherActionIntervalMax);

            WeatherMovementBehavior moveWeatherAction = rainDrop.GetComponent<WeatherMovementBehavior>();

            StartCoroutine(moveWeatherAction.MoveWeatherAction(weatherActionLeftSpeed, weatherActionFallSpeed));
     
            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}