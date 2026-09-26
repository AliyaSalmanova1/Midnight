using UnityEngine;

public class FlyingGameplayStarter : MonoBehaviour
{

    public SceneSwitchManager sceneSwitchManager;


    

    void Start()
    {
        sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Girl"))
        {
            Debug.Log("on trigger enter");
            sceneSwitchManager.StartFlyingGameplay();
        }
    }
}
