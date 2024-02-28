using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Cycle : MonoBehaviour
{
    
    [SerializeField] protected Transform cyclingObject;
    [Range(0f, 1f)] [SerializeField] protected float progress = 0f;
    [SerializeField] protected float period = 1f;
    [SerializeField] protected const float DEFAULT_PERIOD = 1f;
    
    public abstract void SetOrbitingObjectInCycle();

    public Transform GetCyclingObject()
    {
        return cyclingObject;
    }
    
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
    

}