using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthUI : MonoBehaviour
{
    private Image _hearthImg;
    [SerializeField] bool _isTurnOn;

    private void Awake()
    {
        _hearthImg = GetComponent<Image>();
    }
    public void ActiveHearth()
    {
        _hearthImg.enabled = true;
        _isTurnOn = true;
    }

    public void DesactiveHearth()
    {
        _hearthImg.enabled = false;
        _isTurnOn = false;
    }

    public bool IsTurnOn() => _isTurnOn;
}
