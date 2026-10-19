using UnityEngine;
using TMPro;
using FMODUnity;


public abstract class MenuButtonAbstractUI : MonoBehaviour
{

    [SerializeField] public TMP_Text buttonText;


    public EventReference uiHoverSound; 

    void Start()
    {

    }

    public virtual void OnHover()
    {
       
        PlayOnHoverSound();
    }

    public virtual void OnUnhover()
    {
        
    }

    void PlayOnHoverSound()
    {
        RuntimeManager.PlayOneShot(uiHoverSound);
    }

}