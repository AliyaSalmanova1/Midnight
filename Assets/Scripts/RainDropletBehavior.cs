
using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class RainDropletBehavior : MonoBehaviour
{



    [SerializeField] private Rigidbody2D rigidbody2D;



    [SerializeField] private float dropDownSpeed = 3f;

    [SerializeField] private float dropMoveLeftSpeed = 1f;

    void Start()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    

    

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(-dropMoveLeftSpeed * Time.deltaTime, -dropDownSpeed * Time.deltaTime);
    }




}
