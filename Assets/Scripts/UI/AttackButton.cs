using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] PlayerAttack _playerAttack;

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerAttack.Press();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _playerAttack.PressEnd();
    }
}
