using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Cycle : MonoBehaviour
{
    
    // [SerializeField] protected Transform cyclingObject;
    protected Vector3 _cyclePosition = Vector3.zero;
    [SerializeField] protected bool usePosition = false;
    protected Quaternion _cycleRotation = new Quaternion(0, 0, 0, 0);
    [SerializeField] protected bool useRotation = false;
    [Range(0f, 1f)] [SerializeField] protected float progress = 0f;
    [SerializeField] protected float period = 1f;
    [SerializeField] protected float DEFAULT_PERIOD = 1f;
    
    public abstract void SetPositionAndRotationInCycle();

    // public Transform GetCyclingObject()
    // {
    //     return cyclingObject;
    // }
    
    public float GetProgress()
    {
        return progress;
    }

    public void SetProgress(float val)
    {
        progress = val;
    }
    
    public float GetPeriod()
    {
        return period;
    }
    
    public float GetDefaultPeriod()
    {
        return DEFAULT_PERIOD;
    }

    public void SetPeriod(float val)
    {
        period = val;
    }

    public Vector3 GetPosition()
    {
        return _cyclePosition;
    }

    public Quaternion GetRotation()
    {
        return _cycleRotation;
    }

    public bool UsePosition()
    {
        return usePosition;
    }

    public bool UseRotation()
    {
        return useRotation;
    }

}