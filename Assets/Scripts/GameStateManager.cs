using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class GameStateManager : MonoBehaviour
{

    public PlayerInput playerInput;

    public enum GameState
    {
        INTERLUDE,
        FLYING
    }
    
    [SerializeField] GameState gameState = GameState.INTERLUDE;


    [SerializeField] string girlInterludeMovements;

    [SerializeField] InputActionReference girlFlying;

    void Start()
    {
        playerInput.SwitchCurrentActionMap(girlInterludeMovements);
    }

    




}