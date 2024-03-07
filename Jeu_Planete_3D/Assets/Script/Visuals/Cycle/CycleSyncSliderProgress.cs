using UnityEngine;
using UnityEngine.UI;


public class CycleSyncSliderProgress : CycleSync, IdentifiableRestrictable
{
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
    
    protected override bool CanBeEnabled()
    {
        return base.CanBeEnabled() && _slider != null;
    }
    
    protected override void SyncWithCycle()
    {
        _slider.value = cycle.GetProgress();
    }
    
}
