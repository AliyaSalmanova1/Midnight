using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WeatherSystemManager : MonoBehaviour
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


    public IEnumerator ActivateWeatherSpawners(float weatherSpawnerActivationInterval,
        float weatherActionIntervalMin,
        float weatherActionIntervalMax,
        float weatherActionLeftSpeed,
        float weatherActionFallSpeed)

        
    {

        foreach(Transform child in transform)
        {
            weatherSpawners.Add(child.gameObject);
        }

        while (weatherSpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, weatherSpawners.Count);

            weatherSpawners[randomIndex].SetActive(true);

            GameObject weatherSpawnerInstance = weatherSpawners[randomIndex];

            StartCoroutine(weatherSpawnerInstance.GetComponent<WeatherSpawnerBehavior>().SpawnWeatherPiece(
                weatherActionIntervalMin,
                weatherActionIntervalMax,
                weatherActionLeftSpeed,
                weatherActionFallSpeed,
                weatherSpawnerActivationInterval,
                weatherSpawnerInstance));

            weatherSpawners.RemoveAt(randomIndex);

            

            yield return new WaitForSeconds(weatherSpawnerActivationInterval);

            
        }
        
    }

    public IEnumerator DeactivateWeatherSpawners(float weatherSpawnerDeactivationInterval)
    {
        Debug.Log("Deactivating weather spawners");
        StopAllCoroutines();

        
 
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<WeatherSpawnerBehavior>().StopSpawning(); 
            for (int j = child.childCount - 1; j >= 0; j--)
            {
                Transform grandChild = child.GetChild(j);
                Destroy(grandChild.gameObject);
            }
            

            child.gameObject.SetActive(false);

            yield return new WaitForSeconds(weatherSpawnerDeactivationInterval);
        }

    }

    
    
}