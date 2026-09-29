using System.Collections;
using UnityEngine;

public class WindSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject windPrefab;

    [SerializeField] float secondsBetweenWindMin = 1f;

    [SerializeField] float secondsBetweenWindMax = 3f;

    void Start()
    {
        StartCoroutine(SpawnWind());
    }


    void Update()
    {

    }

    IEnumerator SpawnWind()
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(windPrefab, gameObject.transform);

            float randomAmountOfSecs = Random.Range(secondsBetweenWindMin, secondsBetweenWindMax);

            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }
}
