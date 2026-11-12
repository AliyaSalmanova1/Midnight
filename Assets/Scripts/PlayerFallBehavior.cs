using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System;


public class PlayerFallBehavior : MonoBehaviour
{
    
    public float playerRotationSpeed = 100f;
    public InputActionsController inputActionsController;

    public GameObject player;

    void Start()
    {
        if (inputActionsController == null)
        {
            inputActionsController = FindObjectOfType<InputActionsController>();
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Girl");
        }
    }

    public void StartPlayerFall(Action onFallComplete)
    {
        StartCoroutine(RotatePlayer(onFallComplete));
    }

    public IEnumerator RotatePlayer(Action onRotationComplete)
    {
        inputActionsController.DisableInputActions();
        while (player.transform.eulerAngles.z < 90f)
        {
            player.transform.Rotate(Vector3.forward * Time.deltaTime * playerRotationSpeed);
            yield return null;
        }
        StartCoroutine(PlayerFall(onRotationComplete));
    }

    public IEnumerator PlayerFall(Action onFallComplete)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 11f;
        while(player.transform.position.y > -10f)
        {
            yield return null;
        }
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        onFallComplete?.Invoke();
    }

    

}