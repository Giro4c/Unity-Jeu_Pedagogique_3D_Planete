using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleSyncTransform : CycleSync, IdentifiableRestrictable
{
    [SerializeField] protected Transform cyclingObject;

    // Interface implementation ---------------
    [SerializeField] private string identifier = "None";
    public bool activationRestricted { get; set; }
    [SerializeField] private bool _defaultActivation = true;

    
    public void Activate(bool activation)
    {
        enabled = activation;
    }

    public string GetIdentifier()
    {
        return identifier;
    }
    
    public bool GetDefaultActivation()
    {
        return _defaultActivation;
    }
    
    // ----------------------------------------------
    
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
