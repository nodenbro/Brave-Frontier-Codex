using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteOverlay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image overlayImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        overlayImage.enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        overlayImage.enabled = false;
    }
}
