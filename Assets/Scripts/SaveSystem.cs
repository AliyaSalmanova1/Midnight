using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;


public class SaveSystem : MonoBehaviour
{


    
    public void ResetGameStats()
    {
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.SetInt("CurrentInterlude", 0);
        PlayerPrefs.SetInt("CurrentMiniLevel", 0);
    }

    


}