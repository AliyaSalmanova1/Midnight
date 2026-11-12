
using System;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;



public class LightningMovementBehavior : WeatherMovementBehavior
{


    public SpriteRenderer spriteRenderer;

    public override void Start()
    {
        base.Start(); 

        spriteRenderer = GetComponent<SpriteRenderer>();

        Color tempColor = spriteRenderer.color;
        tempColor.a = .2f;
        spriteRenderer.color = tempColor;

        StartCoroutine(MakeLightningStrike());

    }

    IEnumerator MakeLightningStrike()
    {

        yield return new WaitForSeconds(Config.config.timeBetweenLightningStrikes);

        Color tempColor = spriteRenderer.color;
        tempColor.a = 1f;
        spriteRenderer.color = tempColor;


        Destroy(gameObject, Config.config.timeToDestroyLightningStrike);

    }


}
