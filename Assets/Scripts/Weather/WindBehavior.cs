

using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;



[RequireComponent(typeof(Rigidbody2D))]
public class WindBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;




    void Start()
    {
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    

    

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(-Config.windMoveLeftSpeed, 0f);
    }
}
