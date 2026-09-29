using System.Collections;
using UnityEngine;

public class LightningSpawnBehavior : MonoBehaviour
{
    [SerializeField] GameObject lightningStrikePrefab;

    [SerializeField] float secondsBetweenLightningStrikeMin = 1f;

    [SerializeField] float secondsBetweenLightningStrikeMax = 3f;

    void Start()
    {
        StartCoroutine(SpawnLightningStrike());
    }


    void Update()
    {

    }

    IEnumerator SpawnLightningStrike()
    {

        while (true)
        {
            GameObject rainDrop = Instantiate(lightningStrikePrefab, gameObject.transform);

            float randomAmountOfSecs = Random.Range(secondsBetweenLightningStrikeMin, secondsBetweenLightningStrikeMax);

            yield return new WaitForSeconds(randomAmountOfSecs);
        }
    }
}
