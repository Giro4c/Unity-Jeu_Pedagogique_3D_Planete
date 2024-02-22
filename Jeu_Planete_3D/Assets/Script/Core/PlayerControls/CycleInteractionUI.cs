
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CycleInteractionUI : CycleInteraction
{

    [SerializeField] protected EventSystem _eventSys;
    
    public override bool IsTriggered()
    {
        return base.IsTriggered() && _eventSys.IsPointerOverGameObject();
    }

    public override bool IsControlActive()
    {
        throw new System.NotImplementedException();
    }


}
