using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Assets.Scripts;


public class SceneSwitchManager : MonoBehaviour
{

    
    public void StartInterlude()
    {
        Debug.Log("in start interlude");
        SceneManager.LoadScene(Config.interludeScene);
    }

    public void StartFlyingGameplay()
    {
        Debug.Log("in start flying gameplay");
        SceneManager.LoadScene(Config.flyingGameplayScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(Config.mainmenuScene);
    }



    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a standalone build
        Application.Quit();
        #endif
    }


}