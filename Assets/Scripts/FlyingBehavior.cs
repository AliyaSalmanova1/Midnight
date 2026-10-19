using System;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;


[RequireComponent(typeof(Rigidbody2D))]
public class FlyingBehavior : MonoBehaviour
{

    [SerializeField] private InputActionReference flyVerticalAction;

    [SerializeField] private InputActionReference flyHorizontalAction;

    [SerializeField] private Rigidbody2D rigidbody2D;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    float flyVerticalInput;
    float flyHorizontalInput;



    
    
    private void OnEnable()
    {
        flyVerticalAction.action.Enable();
        flyHorizontalAction.action.Enable();
    }

    private void Start()
    {
        

        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
 
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;

    }

    

    void Update()
    {
        GetFlyInput();
    }

    void FixedUpdate()
    {
        if (transform.position.y > maxY && flyVerticalInput > 0 ||
        transform.position.y < minY && flyVerticalInput < 0) flyVerticalInput = 0;

        if (transform.position.x > maxX && flyHorizontalInput > 0 ||
        transform.position.x < minX && flyHorizontalInput < 0) flyHorizontalInput = 0;

        rigidbody2D.linearVelocity = new Vector2(flyHorizontalInput * Config.flySpeed, flyVerticalInput * Config.flySpeed);
    }

    void GetFlyInput()
    {

        flyVerticalInput = flyVerticalAction.action.ReadValue<float>();
        flyHorizontalInput = flyHorizontalAction.action.ReadValue<float>();
        

    }

    private void OnDisable()
    {
        flyVerticalAction.action.Disable();
        flyHorizontalAction.action.Disable();
    }
}