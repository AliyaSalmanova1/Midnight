using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using FMOD;
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

        sceneSwitchManager = FindAnyObjectByType<SceneSwitchManager>();

        DisableAllCanvases();

        mainMenuCanvas.SetActive(true);
    }



    public void StartNewGame()
    {
        PlayOnClickSound();
        sceneSwitchManager.StartGameplay();
    }

    public void ContinueGame()
    {
        PlayOnClickSound();
        //to write
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
    }

    void PlayOnClickSound()
    {
        RuntimeManager.PlayOneShot(uiClickSound);
    }

    



}