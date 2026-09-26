using UnityEngine;

public class DialogueSystemStarter : MonoBehaviour
{
    public GameObject dialogueSystem;

    void Start()
    {
        dialogueSystem.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Girl"))
        {
            Debug.Log("on trigger enter");
            dialogueSystem.SetActive(true);
        }
    }
    

}
