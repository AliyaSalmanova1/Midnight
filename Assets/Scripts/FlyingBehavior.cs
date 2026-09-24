using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class FlyingBehavior : MonoBehaviour
{

    [SerializeField] private InputActionReference flyAction;

    [SerializeField] private Rigidbody2D rigidbody2D;

    float flyInput = 0;

    [SerializeField] private float flySpeed = 3f;
    
    private void OnEnable()
    {
        flyAction.action.Enable();
    }

    

    void Update()
    {
        GetFlyInput();
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(0f, flyInput * flySpeed);
    }

    void GetFlyInput()
    {

        flyInput = flyAction.action.ReadValue<float>();

        Debug.Log("fly input: " + flyInput);
    }

    private void OnDisable()
    {
        flyAction.action.Disable();
    }
}