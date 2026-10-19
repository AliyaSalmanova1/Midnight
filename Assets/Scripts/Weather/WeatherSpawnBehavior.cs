using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class WeatherSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject weatherPiecePrefab;

    [SerializeField] float secondsBetweenWeatherPiecesMin = 1f;
    [SerializeField] float secondsBetweenWeatherPiecesMax = 3f;
    
    void Start()
    {
        StartCoroutine(SpanWeatherPiece());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpanWeatherPiece()
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(weatherPiecePrefab, gameObject.transform);

            float randomAmountOfSecs = Random.Range(secondsBetweenWeatherPiecesMin, secondsBetweenWeatherPiecesMax);
     
            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }
}
