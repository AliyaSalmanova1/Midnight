using UnityEngine;
using FMODUnity;


public class MainMenuButtonManager : MonoBehaviour
{

    public EventReference uiClickSound; 

    [SerializeField] private SceneSwitchManager sceneSwitchManager;

    [SerializeField] private GameObject mainMenuCanvas;

    [SerializeField] private GameObject volumeCanvas;

    [SerializeField] private GameObject creditsCanvas;


    void Start()
    {
        if (!sceneSwitchManager)
        {
            sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();
        }

        OpenMainMenu();

        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.SetInt("CurrentInterlude", 0);
        PlayerPrefs.SetInt("CurrentMiniLevel", 0);
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