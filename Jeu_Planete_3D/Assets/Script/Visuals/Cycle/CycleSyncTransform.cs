using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSyncTransform : CycleSync
{
    [SerializeField] protected Transform cyclingObject;

    protected override bool CanBeEnabled()
    {
        return base.CanBeEnabled() && cyclingObject != null;
    }
    
    protected override void SyncWithCycle()
    {
        if (cycle.UsePosition())
        {
            cyclingObject.localPosition = cycle.GetPosition();
        }

        if (cycle.UseRotation())
        {
            cyclingObject.localRotation = cycle.GetRotation();
        }
    }
    
}
