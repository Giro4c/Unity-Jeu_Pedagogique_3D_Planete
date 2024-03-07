using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CycleInteractionPlanetXRRotation : CycleInteractionPlanetXR
{
    protected override void ProcessingInput()
    {
        float newProgress = ((RotationCycle) cycleAffected).GetRevolutionSelf().FindProgress(collider.transform.localRotation);
        cycleAffected.SetProgress(newProgress);
    }
}
