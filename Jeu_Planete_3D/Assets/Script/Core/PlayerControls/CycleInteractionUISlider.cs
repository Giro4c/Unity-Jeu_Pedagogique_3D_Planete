
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CycleInteractionUISlider : CycleInteractionUI
{

    [SerializeField] protected Slider slider;
    
    protected override void ProcessingInput()
    {
        cycleAffected.SetProgress(slider.value);
        cycleAffected.SetOrbitingObjectInCycle();
    }

    public override bool IsTriggered()
    {
        return base.IsTriggered() && slider.gameObject.Equals(_eventSys.currentSelectedGameObject);
    }
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }
    
}