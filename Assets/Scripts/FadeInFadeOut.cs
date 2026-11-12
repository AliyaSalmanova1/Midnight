
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class FadeInFadeOut : MonoBehaviour
{
    
    
    public Volume volume; 



    Vignette vignette;

    void Start()
    {
        volume = FindFirstObjectByType<Volume>();


        volume.profile.TryGet<Vignette>(out var vignetteTemp);
        vignette = vignetteTemp;

        vignette.intensity.overrideState = true;

        StartCoroutine(VignetteOpen());
    }
  

    public void CloseVignette()
    {
        StartCoroutine(VignetteClose());

        
    }

    public IEnumerator VignetteClose()
    {
        
        while (vignette.intensity.value < 0.99f)
        {
            Debug.Log("Vignette closing: " + vignette.intensity.value);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, 0.01f);

            yield return null;
        }

        
    }

    public IEnumerator VignetteClose(Action callback)
    {
        
        while (vignette.intensity.value < 0.99f)
        {
            Debug.Log("Vignette closing: " + vignette.intensity.value);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, 0.1f);

            yield return new WaitForSeconds(0f);
        }
        callback?.Invoke();
        
    }


    public IEnumerator VignetteOpen()
    {
        StopCoroutine(VignetteClose());
        StopCoroutine(VignetteClose(() => { }));

        while (vignette.intensity.value > 0.01f)
        {

            Debug.Log("Vignette opening: " + vignette.intensity.value);
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

    }
}