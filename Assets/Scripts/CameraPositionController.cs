using UnityEngine;




public class CameraPositionController : MonoBehaviour
{
    public GameObject newCameraPosition;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Girl"))
        {
            
            Camera.main.transform.position = newCameraPosition.transform.position;
        }
    }
}