using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitchManager : MonoBehaviour
{

    [SerializeField] private string mainmenuScene = "MainMenu";

    [SerializeField] private string gameplayScene = "Gameplay";
    
    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }


    void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a standalone build
        Application.Quit();
        #endif
    }


}