
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CyclesInteractionUIPeriodSlider : CyclesInteractionUIPeriod
{

    [SerializeField] protected Slider slider;

    protected override float NewPeriod(float initialPeriod)
    {
        return initialPeriod / slider.value;
    }

    public override bool IsTriggered()
    {
        return base.IsTriggered() && slider.gameObject.Equals(_eventSys.currentSelectedGameObject);
    }
    
    
}
