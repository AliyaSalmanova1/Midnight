using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;





public class LevelUI : MonoBehaviour
{
    public TMP_Text levelText;

    public TMP_Text miniLevelText;

    public void UpdateLevelUI()
    {
        Debug.Log("Updating level UI");
        levelText.text = Config.levels[PlayerPrefs.GetInt("CurrentLevel", 0)].name;
    }
    public void UpdateMiniLevelUI()
    {
        Debug.Log("Updating mini level UI: " + PlayerPrefs.GetInt("CurrentMiniLevel", 1));
        miniLevelText.text = "Mini level: " + PlayerPrefs.GetInt("CurrentMiniLevel", 1);
    }

    public void ClearMiniLevelUI(){

        miniLevelText.text = "";
    }


}