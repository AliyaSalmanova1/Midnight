using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System.Collections.Generic;

public class ScrollingBgBehavior : MonoBehaviour
{

    [SerializeField] List<RawImage> rawBgImages = new List<RawImage>();
 
    void Update()
    {
        for (int i = 0; i < rawBgImages.Count; i++)
        {
            rawBgImages[i].uvRect = new Rect(rawBgImages[i].uvRect.position + new Vector2(Config.config.scrollSpeed, 0) * Time.deltaTime, rawBgImages[i].uvRect.size);
        }
    }
}
