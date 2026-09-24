using UnityEngine;
using UnityEngine.UI;

public class ScrollingBgBehavior : MonoBehaviour
{

    [SerializeField] float scrollSpeed = 0.1f;

    [SerializeField] RawImage rawBgImage;

    void Update()
    {
        rawBgImage.uvRect = new Rect(rawBgImage.uvRect.position + new Vector2(scrollSpeed, 0) * Time.deltaTime, rawBgImage.uvRect.size);
    }
}
