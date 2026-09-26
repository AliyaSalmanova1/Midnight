using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitchManager : MonoBehaviour
{

    [SerializeField] private string mainmenuScene = "MainMenu";

    [SerializeField] private string flyingGameplayScene = "FlyingGameplay";

    [SerializeField] private string interludeScene = "Interlude";
    
    public void StartInterlude()
    {
        SceneManager.LoadScene(interludeScene);
    }

    public void StartFlyingGameplay()
    {
        SceneManager.LoadScene(flyingGameplayScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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