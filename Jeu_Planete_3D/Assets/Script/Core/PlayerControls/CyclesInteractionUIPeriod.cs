
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CyclesInteractionUIPeriod : CyclesInteractionUI
{

    protected override void ProcessingInput()
    {
        foreach (Cycle cycle in cyclesAffected)
        {
            cycle.SetPeriod(NewPeriod(cycle.GetDefaultPeriod()));
        }
    }

    protected abstract float NewPeriod(float initialPeriod);


}
