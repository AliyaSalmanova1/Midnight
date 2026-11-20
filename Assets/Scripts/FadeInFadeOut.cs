
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class FadeInFadeOut : MonoBehaviour
{
    
    
    public Volume volume; 

    private float elapsedTime = 0f;
    private float duration = 0.5f;

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
        elapsedTime = 0f;
        StopAllCoroutines();
        StartCoroutine(VignetteClose());

        
    }

    public IEnumerator VignetteClose()
    {
        
        vignette.intensity.overrideState = true;
        vignette.active = true;
        elapsedTime = 0f;
        vignette.intensity.value = 0f;

        while (elapsedTime < duration)
        {
            Debug.Log("Vignette closing: " + vignette.intensity.value);
            elapsedTime += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(0f, 1f, Mathf.Clamp01(elapsedTime / duration));

            yield return null;
        }
        vignette.intensity.value = 1f;

        
    }

    public IEnumerator VignetteClose(Action callback)
    {
        vignette.intensity.overrideState = true;
        vignette.active = true;
        elapsedTime = 0f;
        vignette.intensity.value = 0f;

        while (elapsedTime < duration)
        {
            Debug.Log("Vignette closing: " + vignette.intensity.value);
            elapsedTime += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(0f, 1f, Mathf.Clamp01(elapsedTime / duration));

            yield return null;
        }
        vignette.intensity.value = 1f;

        callback?.Invoke();

        
    }


    public IEnumerator VignetteOpen()
    {

        // Stopping a freshly created IEnumerator does nothing, so stop everything instead
        //StopAllCoroutines();

        vignette.intensity.overrideState = true;
        vignette.active = true;
        elapsedTime = 0f;
        vignette.intensity.value = 1f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            Debug.Log("Vignette opening: " + vignette.intensity.value);
            vignette.intensity.value = Mathf.Lerp(1f, 0f, Mathf.Clamp01(elapsedTime / duration));
            yield return null;
        }

        vignette.intensity.value = 0f;

    }
}