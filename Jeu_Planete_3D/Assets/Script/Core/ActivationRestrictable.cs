using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public interface ActivationRestrictable
{
    
    public bool activationRestricted { get; set; }
    public void Activate(bool activation);
    
}
