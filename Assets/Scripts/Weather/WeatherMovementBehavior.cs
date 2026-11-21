


using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts;
using System.Collections;



[RequireComponent(typeof(Rigidbody2D))]

public class WeatherMovementBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;




    public virtual void Start()
    {
        
    }
    

    
    public IEnumerator MoveWeatherAction(float weatherActionLeftSpeed, float weatherActionFallSpeed)
    {
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        while (true)
        {
            Debug.Log("Moving weather action with left speed: " + weatherActionLeftSpeed + " and fall speed: " + weatherActionFallSpeed);
            rigidbody2D.linearVelocity = new Vector2(weatherActionLeftSpeed, weatherActionFallSpeed);
            yield return null;
        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
