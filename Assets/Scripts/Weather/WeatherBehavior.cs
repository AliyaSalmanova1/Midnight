
using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;


[RequireComponent(typeof(Rigidbody2D))]
public class WeatherBehavior : MonoBehaviour
{



    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private float weatherMoveLeftSpeed;

    [SerializeField] private float weatherDropFallSpeed;



    

    void Start()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    

    

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(-weatherMoveLeftSpeed, -weatherDropFallSpeed);
    }




}
