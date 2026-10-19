
using System;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;



public class LightningStrikeBehavior : MonoBehaviour
{


    public SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        Color tempColor = spriteRenderer.color;
        tempColor.a = .2f;
        spriteRenderer.color = tempColor;

        StartCoroutine(MakeLightningStrike());

    }

    IEnumerator MakeLightningStrike()
    {

        yield return new WaitForSeconds(Config.timeBetweenLightningStrikes);

        Color tempColor = spriteRenderer.color;
        tempColor.a = 1f;
        spriteRenderer.color = tempColor;


        Destroy(gameObject, Config.timeToDestroyLightningStrike);

    }


}
