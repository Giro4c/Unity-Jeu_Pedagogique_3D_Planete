using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CycleSyncRenderer : CycleSync
{
    
    [SerializeField] protected Renderer renderer;
    private MaterialPropertyBlock mpb;

    protected override bool CanBeEnabled()
    {
        mpb = new MaterialPropertyBlock ();
        if (renderer == null) return false;
        return base.CanBeEnabled();
    }
    
    protected override void SyncWithCycle()
    {
        float adjustedProgress = Remap(cycle.GetProgress(), 0f, 1f, -1f, 1f);
        renderer.GetPropertyBlock (mpb);
        mpb.SetFloat ("_RotationProgress", adjustedProgress);
        renderer.SetPropertyBlock (mpb);
    }
    
        // Fonction pour remapper une valeur d'une plage à une autre
    private float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
