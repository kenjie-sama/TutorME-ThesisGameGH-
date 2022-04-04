using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuBackgroundEndless : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Vector2 offset;
    [SerializeField] private GameObject rawImage_parent;

    private void LateUpdate()
    {
        if (rawImage_parent.activeInHierarchy) 
            rawImage.uvRect = new Rect(rawImage.uvRect.position + offset * Time.deltaTime, rawImage.uvRect.size);
    }
}