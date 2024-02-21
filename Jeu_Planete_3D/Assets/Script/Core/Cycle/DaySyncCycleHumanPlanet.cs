using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySyncCycleHumanPlanet : CycleAutoMotion
{
    [SerializeField] private Cycle rotationPlanet;
    [SerializeField] private Cycle orbitPlanet;
    
    public override bool CanBeEnabled()
    {
        if (rotationPlanet == null || orbitPlanet == null) return false;
        return base.CanBeEnabled();
    }
    
    public override void UpdateProgress()
    {
        float newProgress = rotationPlanet.GetProgress() - orbitPlanet.GetProgress();
        if (newProgress < 0)
        {
            newProgress += 1;
        }
        newProgress %= 1f;
        cycle.SetProgress(newProgress);
    }
    
}
