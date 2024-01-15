using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Orbit : MonoBehaviour
{
    
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)] public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    
    public void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }
    

    
}
