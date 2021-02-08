using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickHolder : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image Hitbox;
    public OnSCreenStick Joystick;

    RectTransform r_trans;

    private void Start()
    {
        r_trans = Joystick.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Joystick.OnDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 locPos;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Hitbox.rectTransform, eventData.position, eventData.pressEventCamera, out locPos))
        {
            Joystick.gameObject.SetActive(true);
            r_trans.localPosition = locPos;
            Joystick.OnPointerDown(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Joystick.gameObject.SetActive(false);
        Joystick.OnPointerUp(eventData);
    }
}
