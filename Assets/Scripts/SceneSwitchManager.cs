
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
            fadeInFadeOut = FindAnyObjectByType<FadeInFadeOut>();
        }
    }

    
    public void StartInterlude()
    {
        Debug.Log("in start interlude");
        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.config.interludeScene)));
        
    }

    public void StartFlyingGameplay()
    {
        Debug.Log("in start flying gameplay");

        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.config.flyingGameplayScene)));
    }

    public void GoToMainMenu()
    {
        fadeInFadeOut.StartCoroutine(fadeInFadeOut.VignetteClose(() => SceneManager.LoadScene(Config.config.mainmenuScene)));
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