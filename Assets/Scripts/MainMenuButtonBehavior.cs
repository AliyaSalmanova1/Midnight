using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using FMOD;
using FMODUnity;


public class MainMenuButtonBehavior : MonoBehaviour
{

    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private Color hoverColor;

    public EventReference uiHoverSound; 

    private Color originalColor;





    void Start()
    {
        originalColor = buttonText.color; 

    }


    public void OnHover()
    {
        SetToHoverColor();
        PlayOnHoverSound();
    }

    public void OnUnhover()
    {
        SetToOriginalColor();
    }

    void SetToHoverColor()
    {
        buttonText.color = hoverColor;
    }

    void PlayOnHoverSound()
    {
        RuntimeManager.PlayOneShot(uiHoverSound);
    }

    void SetToOriginalColor()
    {
        buttonText.color = originalColor;
    }





}