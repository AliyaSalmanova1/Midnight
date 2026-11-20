using UnityEngine;
using FMODUnity;


public class MainMenuButtonManager : MenuButtonAbstractManager
{




    [SerializeField] protected GameObject mainMenuCanvas;





    [SerializeField] protected SaveSystem saveSystem;


    void Start()
    {
        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }
        if (!saveSystem)
        {
            saveSystem = FindAnyObjectByType<SaveSystem>();
        }

        OpenMainMenu();

    }

    public override void StartNewGame()
    {
        saveSystem.ResetGameStats();
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
        
    }

    public override void ContinueGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
    }

    public virtual void OpenMainMenu()
    {
        DisableAllCanvases();
        ClickNewCanvasButton(mainMenuCanvas);
    }

    public override void ClickNewCanvasButton(GameObject canvasToOpen)
    {
        PlayOnClickSound();
        DisableAllCanvases();
        canvasToOpen.SetActive(true);
        
    }

    public override void DisableAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
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