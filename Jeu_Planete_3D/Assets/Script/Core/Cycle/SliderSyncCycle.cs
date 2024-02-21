using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSyncCycle : MonoBehaviour, ActivationRestrictable
{
    [SerializeField] private Cycle sliderValue;
    private Slider _slider;

    public bool activationRestricted { get; set; }
    public void Activate(bool activation)
    {
        enabled = activation;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        if (! CanBeEnabled())
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Slider is not clicked on -> Sync value with orbit
        _slider.value = sliderValue.GetProgress();
    }

    private void OnEnable()
    {
        enabled = CanBeEnabled();
    }

    private bool CanBeEnabled()
    {
        return sliderValue != null || _slider != null;
    }
}
