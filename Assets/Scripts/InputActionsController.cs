using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputActionsController : MonoBehaviour
{
    public PlayerInput playerInput;




    [SerializeField] string girlInterludeMovementsActions = "GirlInterludeMovements";

    [SerializeField] string girlFlyingActions = "GirlFlying";

    [SerializeField] string emptyAction = "Empty";



    void Start()
    {
        if (SceneManager.GetActiveScene().name == "InterludeScene")
        {
            playerInput.SwitchCurrentActionMap(girlInterludeMovementsActions);
        }else if (SceneManager.GetActiveScene().name == "FlyingScene")
        {
            playerInput.SwitchCurrentActionMap(girlFlyingActions);
        }
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