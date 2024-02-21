using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class CycleInteractionPlanetXR : CycleInteractionPlanet
{

    protected XRRayInteractor rayInteractor;

    public override bool IsTriggered()
    {
        RaycastHit hit;
        return base.IsTriggered() && rayInteractor.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(collider);
    }
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }
    
}
