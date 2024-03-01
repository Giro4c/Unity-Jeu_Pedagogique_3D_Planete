using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Orbit : Cycle
{
    [SerializeField] private Ellipse orbitPath;
    
    public override void SetOrbitingObjectInCycle()
    {
        Vector2 orbitPos = orbitPath.Evaluate(progress);
        cyclingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    public Ellipse GetOrbitPath()
    {
        return orbitPath;
    }
    
}
