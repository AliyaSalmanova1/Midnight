using UnityEngine;

public class FatherDisappearingBehavior : MonoBehaviour
{
    
    public GameObject father;

    public void DestroyFather()
    {
        Destroy(father);
    }
}