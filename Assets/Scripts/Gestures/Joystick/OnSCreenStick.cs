using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnSCreenStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image JoystickParent;
    public Image Stick;

    public Vector2 JoystickVector;

    private GameObject Character;
    private float CharacterSpeed;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 locPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickParent.rectTransform, eventData.position, eventData.pressEventCamera, out locPos))
        {
            //Debug.Log(locPos);
            float half_w = JoystickParent.rectTransform.rect.width / 2;
            float half_h = JoystickParent.rectTransform.rect.height / 2;
            float x = locPos.x / half_w;
            float y = locPos.y / half_h;

            JoystickVector = new Vector2(x, y);
            if (JoystickVector.magnitude > 1) JoystickVector.Normalize();
            Stick.rectTransform.localPosition = new Vector2(JoystickVector.x * half_w, JoystickVector.y * half_h);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JoystickVector = Vector2.zero;
        Stick.rectTransform.localPosition = Vector2.zero;
    }

    private void Start()
    {
        Character = PlayerManager.Instance.Character;
        CharacterSpeed = PlayerManager.Instance.CharacterSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 stickValue = JoystickVector;
        stickValue.x = 0;

        Vector2 ClampPos = PlayerManager.Instance.Character.transform.position;
        ClampPos.y = Mathf.Clamp(ClampPos.y, -2.5f, 0);
        PlayerManager.Instance.Character.transform.position = ClampPos;

        Vector3 changed = stickValue * PlayerManager.Instance.CharacterSpeed * Time.deltaTime;
        PlayerManager.Instance.CharacterMove(changed);
    }
}
