using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.
using TMPro;

public class Example : MonoBehaviour 
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Slider textSlider;
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

    private void SliderAuto()
    {
        float sliderValue = valueSlider.orbitProgress;
        UpdateTextFromSliderValue(sliderValue);
    }

    private void SliderDrag()
    {
        float sliderValue = textSlider.value;
        valueSlider.orbitProgress = sliderValue;
        UpdateTextFromSliderValue(sliderValue);
    }

    private void UpdateTextFromSliderValue(float sliderValue)
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