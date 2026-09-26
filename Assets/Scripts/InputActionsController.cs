using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionsController : MonoBehaviour
{
    public PlayerInput playerInput;




    [SerializeField] string girlInterludeMovementsActions = "GirlInterludeMovements";

    [SerializeField] string girlFlyingActions = "GirlFlying";

    [SerializeField] string emptyAction = "Empty";



    void Start()
    {
        playerInput.SwitchCurrentActionMap(girlInterludeMovementsActions);
    }

    public void DisableInputActions()
    {
        playerInput.SwitchCurrentActionMap(emptyAction);
    }

    public void EnableGirlInterludeMovements()
    {
        playerInput.SwitchCurrentActionMap(girlInterludeMovementsActions);
    }

    public void EnableGirlFlying()
    {
        playerInput.SwitchCurrentActionMap(girlFlyingActions);
    }
    
}