using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool shoot = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        shoot = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shoot = false;
    }

    private void FixedUpdate()
    {
        if (shoot)
        {
            PlayerManager.Instance.Shoot();
        }
    }
}
