using UnityEngine;
using UnityEngine.InputSystem;



public class GirlInterludeMovements : MonoBehaviour
{
    
    [SerializeField] private InputActionReference girlMovementAction;



    [SerializeField] private new Rigidbody2D rigidbody2D;



    float walkInput = 0;



    [SerializeField] private float walkSpeed = 3f;
    
    private void OnEnable()
    {
        girlMovementAction.action.Enable();
  
    }

    void Update()
    {
        GetFlyInput();
    }

    void FixedUpdate()
    {

        rigidbody2D.linearVelocity = new Vector2(walkInput * walkSpeed, 0f);
    }

    void GetFlyInput()
    {

        walkInput = girlMovementAction.action.ReadValue<float>();


    }

    private void OnDisable()
    {
        girlMovementAction.action.Disable();

    }



}