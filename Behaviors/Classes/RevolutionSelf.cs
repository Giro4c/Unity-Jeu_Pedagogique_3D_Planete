using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RevolutionSelf
{
    public Vector3 initialRotation;
    public Vector3 axis;

    public RevolutionSelf()
    {
        initialRotation = Vector3.zero;
        axis = Vector3.up;
    }
    
    public RevolutionSelf(Vector3 initialRotation)
    {
        this.initialRotation = initialRotation;
        axis = Vector3.up;
    }
    
    public RevolutionSelf(Vector3 initialRotation, Vector3 axis)
    {
        this.initialRotation = initialRotation;
        this.axis = axis;
    }

    public Quaternion Evaluate(float progress)
    {
        float angle = progress * 360;
        
        Quaternion combiner = Quaternion.AngleAxis(angle, axis);
        Quaternion result = Quaternion.Euler(initialRotation) * combiner;
        
        return result;
    }

    public float FindProgress(Quaternion rotation)
    {
        Quaternion trueRotation = rotation * Quaternion.Inverse(Quaternion.Euler(initialRotation));
        
        float angle = Quaternion.Angle(Quaternion.AngleAxis(0, axis), trueRotation);
        float newProgress = angle / 360;
        newProgress %= 1f;
        
        if (rotation != Evaluate(newProgress))
        {
            newProgress = 1 - newProgress;
        }
        
        return newProgress;
    }
}
