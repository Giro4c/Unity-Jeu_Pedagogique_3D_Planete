using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Orbit : Cycle
{
    [SerializeField] private Ellipse orbitPath;
    
    public override void SetPositionAndRotationInCycle()
    {
        Vector2 orbitPos = orbitPath.Evaluate(progress);
        _cyclePosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    public Ellipse GetOrbitPath()
    {
        return orbitPath;
    }
    
}
