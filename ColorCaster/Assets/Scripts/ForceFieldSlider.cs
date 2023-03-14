using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceFieldSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    

    public void SetMaxForceField(int Value)
    {
        slider.maxValue = Value;
        slider.value = Value;

        //Debug.Log("Slider Value: %i", slider.maxValue);
    }

    public void SetForceFieldValue(int Value)
    {
        slider.value = Value;
    }

}
