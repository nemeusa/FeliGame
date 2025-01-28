using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider slider;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void MaxLife(float MaxLife)
    {
        slider.maxValue = MaxLife;
    }

    public void actuallyLife(float ActuallyLife)
    {
        slider.value = ActuallyLife;
    }

    public void _BarLife(float ActuallyLife)
    {
        MaxLife(ActuallyLife);
        actuallyLife(ActuallyLife);
    }


}
