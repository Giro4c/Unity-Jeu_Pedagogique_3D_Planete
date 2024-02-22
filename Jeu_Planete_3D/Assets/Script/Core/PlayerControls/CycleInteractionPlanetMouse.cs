using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CycleInteractionPlanetMouse : CycleInteractionPlanet
{

    [SerializeField] protected Camera mainCam;

    public override bool IsTriggered()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return base.IsTriggered() &&  collider.Raycast(ray, out hit, 20);
    }
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }
    
    
}
