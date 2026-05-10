using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteSwap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image image;
    public Sprite pressedSprite;
    public Sprite originalSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pressedSprite; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = originalSprite; 
    }
}
