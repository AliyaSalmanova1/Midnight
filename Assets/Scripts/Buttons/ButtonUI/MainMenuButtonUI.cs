using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using FMOD;
using FMODUnity;


public class MainMenuButtonBehavior : MenuButtonAbstractUI
{

    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private Color hoverColor = Color.white;

    private Color originalColor;
    

    void Start()
    {
        originalColor = buttonText.color; 

    }

    public override void OnHover()
    {
        SetToHoverColor();
        base.OnHover();
    }

    public override void OnUnhover()
    {
        SetToOriginalColor();
        base.OnUnhover();
    }

    void SetToHoverColor()
    {
        buttonText.color = hoverColor;
    }

    void SetToOriginalColor()
    {
        buttonText.color = originalColor;
    }

}