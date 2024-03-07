
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CycleInteractionUIProgressSlider : CycleInteractionUIProgress
{

    [SerializeField] protected Slider slider;

    protected override float NewProgress()
    {
        return slider.value;
    }

    public override bool IsTriggered()
    {
        // print(slider.gameObject);
        // print(_eventSys.currentSelectedGameObject);
        // print(slider.gameObject.Equals(_eventSys.currentSelectedGameObject));
        return base.IsTriggered() && slider.gameObject.Equals(_eventSys.currentSelectedGameObject);
    }
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }
    
}
