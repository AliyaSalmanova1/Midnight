using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ScrollingBgBehavior : MonoBehaviour
{

    [SerializeField] RawImage rawBgImage;

    void Update()
    {
        rawBgImage.uvRect = new Rect(rawBgImage.uvRect.position + new Vector2(Config.config.scrollSpeed, 0) * Time.deltaTime, rawBgImage.uvRect.size);
    }
}
