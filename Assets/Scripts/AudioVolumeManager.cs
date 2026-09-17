using UnityEngine;
using FMOD;
using FMODUnity;
using UnityEngine.UI;


public class AudioVolumeManager : MonoBehaviour
{

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private string masterVCAPath = "vca:/MasterVCA";
    [SerializeField] private string musicVCAPath = "vca:/MusicVCA";
    [SerializeField] private string sfxVCAPath = "vca:/SFXVCA";

    private FMOD.Studio.VCA masterVCA;
    private FMOD.Studio.VCA musicVCA;
    private FMOD.Studio.VCA sfxVCA;


    void Start()
    {

        masterVCA = RuntimeManager.GetVCA(masterVCAPath);
        musicVCA = RuntimeManager.GetVCA(musicVCAPath);
        sfxVCA = RuntimeManager.GetVCA(sfxVCAPath);

        masterVCA.getVolume(out float currentMasterVolume);
        musicVCA.getVolume(out float currentMusicVolume);
        sfxVCA.getVolume(out float currentSFXVolume);

            
        masterSlider.value = Mathf.Sqrt(currentMasterVolume);
        musicSlider.value = currentMusicVolume;
        sfxSlider.value = currentSFXVolume;
            
    }

    public void SetMasterVolume()
    {
        masterVCA.setVolume(masterSlider.value);

    }

    public void SetMusicVolume()
    {

        musicVCA.setVolume(musicSlider.value);

    }

    public void SetSFXVolume()
    {
        sfxVCA.setVolume(sfxSlider.value);


    }



    
}