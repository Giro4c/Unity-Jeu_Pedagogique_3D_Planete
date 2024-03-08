using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CycleInteractionPlanetXRRotation : CycleInteractionPlanetXR
{
    [SerializeField] protected Transform progressIndicator;
    
    protected override void ProcessingInput()
    {
        float newProgress = ((RotationCycle) cycleAffected).GetRevolutionSelf().FindProgress(progressIndicator.localRotation);
        cycleAffected.SetProgress(newProgress);
    }
}
