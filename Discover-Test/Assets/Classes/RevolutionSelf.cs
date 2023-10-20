using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RevolutionSelf
{
    public Vector3 initialRotation;
    //private Quaternion initialQuaternion;
    public Vector3 axis;

    /*public RevolutionSelf()
    {
        initialRotation = Vector3.zero;
        axis = Vector3.up;
        initialQuaternion = Quaternion.Euler(this.initialRotation);
    }*/
    
    /*public RevolutionSelf(Vector3 initialRotation)
    {
        this.initialRotation = initialRotation;
        axis = Vector3.up;
        initialQuaternion = Quaternion.Euler(this.initialRotation);
    }*/
    
    public RevolutionSelf(Vector3 initialRotation, Vector3 axis)
    {
        this.initialRotation = initialRotation;
        this.axis = axis;
        //initialQuaternion = Quaternion.Euler(this.initialRotation);
    }

    public Quaternion Evaluate(float progress)
    {
        //Debug.Log("Initial Rotation : " + initialRotation);
        //Debug.Log("Initial Quaternion should be : " + Quaternion.Euler(initialRotation));
        float angle = progress * 360;
        //Debug.Log("Initial Quaternion Euler is : " + Quaternion.Euler(initialRotation).eulerAngles);
        Quaternion combiner = Quaternion.AngleAxis(angle, axis);
        //Debug.Log("Add Quaternion Euler : " + combiner.eulerAngles);
        Quaternion result = Quaternion.Euler(initialRotation) * combiner;
        //Debug.Log("Result Quaternion Euler : " + result.eulerAngles);
        return result;
    }

    public float FindProgress(Quaternion rotation)
    {
        Quaternion trueRotation = rotation * Quaternion.Inverse(Quaternion.Euler(initialRotation));
        float angle = Quaternion.Angle(Quaternion.AngleAxis(0, axis), trueRotation);
        //Debug.Log("Found angle : " + angle);
        float newProgress = angle / 360;
        newProgress %= 1;
        if (rotation != Evaluate(newProgress))
        {
            newProgress = 1 - newProgress;
        }
        return newProgress%1f;
    }
}
