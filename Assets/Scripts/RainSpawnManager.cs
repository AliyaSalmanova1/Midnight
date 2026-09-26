using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawnManager : MonoBehaviour
{

    [SerializeField] List<GameObject> rainSpawners = new List<GameObject>();

    
    
    void Awake()
    {
        foreach (GameObject rainSpawner in rainSpawners)
        {
            rainSpawner.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(ActivateRainSpawners());
    }

    IEnumerator ActivateRainSpawners()
    {
        while (rainSpawners.Count > 0)
        {
            int randomIndex = Random.Range(0, rainSpawners.Count);

            rainSpawners[randomIndex].SetActive(true);

            rainSpawners.RemoveAt(randomIndex);

            yield return new WaitForSeconds(1f);
        }
        
            
        
    }

    void Update()
    {
        
    }

    



}
