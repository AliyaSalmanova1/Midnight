


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
        if (!rigidbody2D)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
    

    
    public IEnumerator MoveWeatherAction(float weatherActionLeftSpeed, float weatherActionFallSpeed)
    {
        while (true)
        {
            rigidbody2D.linearVelocity = new Vector2(weatherActionLeftSpeed, weatherActionFallSpeed);
            yield return null;
        }
    }
}
