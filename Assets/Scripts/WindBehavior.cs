

using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class WindBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;




    [SerializeField] private float windMoveLeftSpeed = 1f;

    void Start()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    

    

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(-windMoveLeftSpeed, 0f);
    }
}
