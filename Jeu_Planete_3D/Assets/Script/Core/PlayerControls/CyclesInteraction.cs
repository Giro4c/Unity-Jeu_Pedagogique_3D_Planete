using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CyclesInteraction : PlayerControl
{

    [SerializeField] protected Cycle[] cyclesAffected;

    public float[] GetValuesProgress()
    {
        float[] progresses = new float[cyclesAffected.Length];
        for (int i = 0; i < cyclesAffected.Length; ++i)
        {
            progresses[i] = cyclesAffected[i].GetProgress();
        }
        return progresses;
    }
    
}
