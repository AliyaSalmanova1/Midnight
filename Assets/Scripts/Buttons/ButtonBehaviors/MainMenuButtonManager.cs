using UnityEngine;
using FMODUnity;


public class MainMenuButtonManager : MonoBehaviour
{

    public EventReference uiClickSound; 

    [SerializeField] private SceneSwitchManager sceneSwitchManager;

    [SerializeField] private GameObject mainMenuCanvas;

    [SerializeField] private GameObject volumeCanvas;

    [SerializeField] private GameObject creditsCanvas;

    [SerializeField] private SaveSystem saveSystem;


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

    public void StartNewGame()
    {
        saveSystem.ResetGameStats();
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
        
    }

    public void ContinueGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.StartInterlude();
    }

    public virtual void OpenMainMenu()
    {
        DisableAllCanvases();
        ClickNewCanvasButton(mainMenuCanvas);
    }

    public void ClickNewCanvasButton(GameObject canvasToOpen)
    {
        PlayOnClickSound();
        DisableAllCanvases();
        canvasToOpen.SetActive(true);
        
    }

    void DisableAllCanvases()
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

    void PlayOnClickSound()
    {
        RuntimeManager.PlayOneShot(uiClickSound);
    }


}