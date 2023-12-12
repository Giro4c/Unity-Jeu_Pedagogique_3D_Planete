using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Globalization;
using UnityEngine.UI;


public class CurrentMonth : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] public Slider textSlider;
    public Orbit valueSlider;
    private bool isTrue;
    public string[] mois;


    private void Update()
    {
        isTrue = Input.GetMouseButton(0);

        if (isTrue)
        {
            SliderDrag();
        }
        else
        {
            SliderAuto();
        }
    }

    public void SliderAuto()
    {
        textSlider.value = valueSlider.orbitProgress;
        UpdateTextFromSliderValue(textSlider.value);
    }

    public void SliderDrag()
    {
        float sliderValue = textSlider.value;
        valueSlider.orbitProgress = sliderValue;
        UpdateTextFromSliderValue(sliderValue);
    }

    public void UpdateTextFromSliderValue(float sliderValue)
    {
        textSlider.value = sliderValue;

        for (int i = 0; i < mois.Length; i++)
        {
            float lowerBound = i / (float)mois.Length;
            float upperBound = (i + 1) / (float)mois.Length;

            if (sliderValue >= lowerBound && sliderValue <= upperBound)
            {
                displayText.text = mois[i];
                break;
            }
        }
    }
}
