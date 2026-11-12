using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Assets.Scripts;


public class SceneSwitchManager : MonoBehaviour
{

    public FadeInFadeOut fadeInFadeOut;

    

    void Start()
    {
        if (fadeInFadeOut == null)
        {
            fadeInFadeOut = FindObjectOfType<FadeInFadeOut>();
        }
    }

    
    public void StartInterlude()
    {
        Debug.Log("in start interlude");
        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.interludeScene)));
        
    }

    public void StartFlyingGameplay()
    {
        Debug.Log("in start flying gameplay");

        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.flyingGameplayScene)));
    }

    public void GoToMainMenu()
    {
        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.mainmenuScene)));
    }



    public void ExitGame()
    {
        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => CloseGame()));
 
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a standalone build
        Application.Quit();
        #endif
    }


}