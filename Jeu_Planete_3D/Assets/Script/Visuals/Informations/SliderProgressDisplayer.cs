using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgressDisplayer : InformationDisplayer
{

    [SerializeField] protected Slider slider;

    public override void Display()
    {
        int progress = Mathf.FloorToInt(slider.value * 100);
        displayText.text = progress.ToString() + " %";
    }
}
