using System.Collections;
using UnityEngine;

public class RainSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject rainDropPrefab;

    [SerializeField] float secondsBetweenRainDropsMin = 1f;

    [SerializeField] float secondsBetweenRainDropsMax = 3f;
    
    void Start()
    {
        StartCoroutine(SpanRainDrop());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpanRainDrop()
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(rainDropPrefab, gameObject.transform);

            float randomAmountOfSecs = Random.Range(secondsBetweenRainDropsMin, secondsBetweenRainDropsMax);
     
            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }
}
