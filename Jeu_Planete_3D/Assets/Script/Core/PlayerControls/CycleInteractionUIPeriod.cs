
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CycleInteractionUIPeriod : CycleInteractionUI
{

    protected override void ProcessingInput()
    {
        cycleAffected.SetPeriod(NewPeriod());
    }

    protected abstract float NewPeriod();


}
