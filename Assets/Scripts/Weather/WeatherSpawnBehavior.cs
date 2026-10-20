using System.Collections;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

public class WeatherSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject weatherPiecePrefab;

    [System.Serializable]
    public class SecondsBetweenWeatherPieces
    {
        public float min = 1f;
        public float max = 3f;
    }
    [SerializeField] List<SecondsBetweenWeatherPieces> secondsBetweenWeatherPieces = new List<SecondsBetweenWeatherPieces>();
    
    void Start()
    {
        StartCoroutine(SpanWeatherPiece());
    }

    
    IEnumerator SpanWeatherPiece()
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(weatherPiecePrefab, gameObject.transform);

            int currentMiniLevel = PlayerPrefs.GetInt("CurrentMiniLevel");

            float randomAmountOfSecs = Random.Range(secondsBetweenWeatherPieces[currentMiniLevel].min, secondsBetweenWeatherPieces[currentMiniLevel].max);
     
            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }
}
