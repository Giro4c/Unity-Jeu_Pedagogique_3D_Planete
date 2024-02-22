using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CycleInteraction : PlayerControl
{

    [SerializeField] protected Cycle cycleAffected;

    public float GetValue()
    {
        return cycleAffected.GetProgress();
    }
    
}
