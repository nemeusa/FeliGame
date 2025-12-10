using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthContainer : MonoBehaviour
{
    [SerializeField] HearthUI[] _hearths;

    public void HearthsActive(int actualLife)
    {
        for (int i = 0; i < _hearths.Length; i++)
        {
            if (i < actualLife) _hearths[i].ActiveHearth();
            
            else _hearths[i].DesactiveHearth();
        }
    }
}
