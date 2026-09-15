using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ButtonBehavior : MonoBehaviour
{


    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private Color hoverColor;

    [SerializeField] private Color originalColor;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnHover()
    {
        
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