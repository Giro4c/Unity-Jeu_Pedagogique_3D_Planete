using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSyncRotation : MonoBehaviour
{
    public RotationCycle sliderValue;
    private Slider _slider;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        if (! canBeEnabled())
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Slider is not clicked on -> Sync value with orbit
        _slider.value = sliderValue.rotateProgress;
    }

    private void OnEnable()
    {
        enabled = canBeEnabled();
    }

    private bool canBeEnabled()
    {
        return sliderValue != null || _slider != null;
    }
}
