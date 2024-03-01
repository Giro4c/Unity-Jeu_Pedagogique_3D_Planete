
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CyclesInteractionUI : CyclesInteraction
{

    [SerializeField] protected EventSystem _eventSys;
    
    public override bool IsTriggered()
    {
        return base.IsTriggered() && _eventSys.IsPointerOverGameObject();
    }


}
