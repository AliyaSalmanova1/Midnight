using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> lightningSpawners = new List<GameObject>();

    
    
    void Awake()
    {
        foreach (GameObject lightningSpawner in lightningSpawners)
        {
            lightningSpawner.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(ActivateLightningSpawners());
    }

    IEnumerator ActivateLightningSpawners()
    {
        while (lightningSpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, lightningSpawners.Count);

            lightningSpawners[randomIndex].SetActive(true);

            lightningSpawners.RemoveAt(randomIndex);

            yield return new WaitForSeconds(1f);
        }
        
            
        
    }
}
