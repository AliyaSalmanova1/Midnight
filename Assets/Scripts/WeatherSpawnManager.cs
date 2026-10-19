using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class WeatherSpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> weatherSpawners = new List<GameObject>();

    [SerializeField] float secondsBetweenWeatherSpawnerActivation = 2f;
    
    void Awake()
    {
        foreach (GameObject weatherSpawner in weatherSpawners)
        {
            weatherSpawner.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(ActivateWeatherSpawners());
    }

    IEnumerator ActivateWeatherSpawners()
    {
        while (weatherSpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, weatherSpawners.Count);

            weatherSpawners[randomIndex].SetActive(true);

            weatherSpawners.RemoveAt(randomIndex);

            yield return new WaitForSeconds(secondsBetweenWeatherSpawnerActivation);
        }
       
        
    }

}
