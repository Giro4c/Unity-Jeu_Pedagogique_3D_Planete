using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class CycleInteractionPlanetMouseRotation : CycleInteractionPlanetMouse
{
    [SerializeField] protected float speedRotation = 11f;
    
    protected override void ProcessingInput()
    {
        // Find angle to add to the rotation
        float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);
        xRotate %= 360f;
            
        // Calculate newProgress
        float newProgress = cycleAffected.GetProgress() + xRotate / 360f;
            
        if (newProgress < 0)
        {
            newProgress += 1;
        }
        else if (newProgress >= 1)
        {
            newProgress %= 1f;
        }
        cycleAffected.SetProgress(newProgress);
            
        // Change object's rotation
        cycleAffected.SetOrbitingObjectInCycle();
    }
}
