using System.Collections;
using UnityEngine;

public class RainSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject rainDropPrefab;

    [SerializeField] float secondsBetweenRainDrops = 2f;
    
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
     
            yield return new WaitForSeconds(secondsBetweenRainDrops);
        }
    }
}
