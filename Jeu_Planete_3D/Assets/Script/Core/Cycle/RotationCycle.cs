using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RotationCycle : Cycle
{
    [SerializeField] private RevolutionSelf revolutionSelf;
    
    public override void SetOrbitingObjectInCycle()
    {
        cyclingObject.localRotation = revolutionSelf.Evaluate(progress);
    }

    public RevolutionSelf GetRevolutionSelf()
    {
        return revolutionSelf;
    }
    
}
