using UnityEngine;
using FMODUnity;


public class MenuButtonAbstractManager : MonoBehaviour
{
    [SerializeField] protected EventReference uiClickSound; 

    [SerializeField] protected SceneSwitchManager sceneSwitchManager;


    [SerializeField] protected GameObject volumeCanvas;

    [SerializeField] protected GameObject creditsCanvas;


    void Start()
    {
        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }
    }

    public virtual void StartNewGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
    }

    public virtual void ContinueGame()
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

    protected void PlayOnClickSound()
    {
        RuntimeManager.PlayOneShot(uiClickSound);
    }

}