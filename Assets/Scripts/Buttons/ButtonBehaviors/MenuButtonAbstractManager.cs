using UnityEngine;
using FMODUnity;


public class MenuButtonAbstractManager : MonoBehaviour
{
    public EventReference uiClickSound; 

    [SerializeField] private SceneSwitchManager sceneSwitchManager;


    [SerializeField] private GameObject volumeCanvas;

    [SerializeField] private GameObject creditsCanvas;


    void Start()
    {
        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }
    }

    public void StartNewGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
    }

    public void ContinueGame()
    {
        PlayOnClickSound();
        //to write
    }

    public virtual void ClickNewCanvasButton(GameObject canvasToOpen)
    {
        PlayOnClickSound();
  
        canvasToOpen.SetActive(true);
        
    }

    public virtual void DisableAllCanvases()
    {
        
        volumeCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.ExitGame();
    }

    void PlayOnClickSound()
    {
        RuntimeManager.PlayOneShot(uiClickSound);
    }

}