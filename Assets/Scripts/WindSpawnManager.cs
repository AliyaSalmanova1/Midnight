using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> windSpawners = new List<GameObject>();

    
    
    void Awake()
    {
        foreach (GameObject windSpawner in windSpawners)
        {
            windSpawner.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(ActivateWindSpawners());
    }

    IEnumerator ActivateWindSpawners()
    {
        while (windSpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, windSpawners.Count);

            windSpawners[randomIndex].SetActive(true);

            windSpawners.RemoveAt(randomIndex);

            yield return new WaitForSeconds(1f);
        }
       
        
    }

}
