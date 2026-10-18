using UnityEngine;
using FMODUnity;


public class PauseMenuButtonManager : MenuButtonAbstractManager
{

    [SerializeField] private SceneSwitchManager sceneSwitchManager;

    [SerializeField] private GameObject pauseMenuCanvas;

    void OnOpenPauseMenu()
    {
        Debug.Log("Pause menu opened");
        base.DisableAllCanvases();
        base.ClickNewCanvasButton(pauseMenuCanvas);
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {
        PlayOnClickSound();
        Time.timeScale = 1f;
        sceneSwitchManager.GoToMainMenu();
    }

    public void ResumeGame()
    {
        PlayOnClickSound();
        base.DisableAllCanvases();
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        
    }
    

    public override void DisableAllCanvases()
    {
        base.DisableAllCanvases();
        base.ClickNewCanvasButton(pauseMenuCanvas);
        Time.timeScale = 1f;
    }


    void PlayOnClickSound()
    {
        RuntimeManager.PlayOneShot(uiClickSound);
    }

}