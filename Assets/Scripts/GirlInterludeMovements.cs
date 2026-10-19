using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;



public class GirlInterludeMovements : MonoBehaviour
{
    
    [SerializeField] private InputActionReference girlMovementAction;



    [SerializeField] private new Rigidbody2D rigidbody2D;



    float walkInput;



    
    
    private void OnEnable()
    {
        girlMovementAction.action.Enable();
  
    }

    void Update()
    {
        GetWalkInput();
    }

    void FixedUpdate()
    {

        rigidbody2D.linearVelocity = new Vector2(walkInput * Config.walkSpeed, 0f);
    }

    void GetWalkInput()
    {

        walkInput = girlMovementAction.action.ReadValue<float>();


    }

    private void OnDisable()
    {
        girlMovementAction.action.Disable();

    }



}