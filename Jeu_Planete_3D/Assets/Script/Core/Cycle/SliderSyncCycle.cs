using UnityEngine;
using UnityEngine.UI;


public class SliderSyncCycle : MonoBehaviour, IdentifiableRestrictable
{
    [SerializeField] private Cycle sliderValue;
    [SerializeField] private Slider _slider;

    // Interface implementation ---------------
    [SerializeField] private string identifier = "None";
    public bool activationRestricted { get; set; }
    [SerializeField] private bool _defaultActivation = true;

    
    public void Activate(bool activation)
    {
        enabled = activation;
    }

    public string GetIdentifier()
    {
        return identifier;
    }
    
    public bool GetDefaultActivation()
    {
        return _defaultActivation;
    }
    
    // ----------------------------------------------
    
    // Start is called before the first frame update
    void Start()
    {
        if (_slider == null)
        {
            _slider = gameObject.GetComponent<Slider>();
        }
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
