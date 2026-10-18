using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawnManager : MonoBehaviour
{

    [SerializeField] List<GameObject> rainSpawners = new List<GameObject>();

    public float initialTime;

    public float currentTime;

    public float levelTime = 3f;

    public LevelManager levelManager;

    public SceneSwitchManager sceneSwitchManager;
    
    void Awake()
    {
        foreach (GameObject rainSpawner in rainSpawners)
        {
            rainSpawner.SetActive(false);
        }
    }

    void OnEnable()
    {
        currentTime = Time.time;
    }

    


    void Start()
    {
        StartCoroutine(ActivateRainSpawners());

        

        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }
        if (!levelManager)
        {
            levelManager = FindAnyObjectByType<LevelManager>();
        }
    }

    void Update()
    {

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

    

    



}
