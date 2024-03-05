using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class FaceSoleil : CycleAutoProgression
{
    
    [SerializeField] private Renderer render;
    private MaterialPropertyBlock mpb;
    

    public override bool CanBeEnabled()
    {
        if (render == null) return false;
        return base.CanBeEnabled();
    }

    protected override IEnumerator AnimateCycle()
    {
        mpb = new MaterialPropertyBlock ();
        while (_active)
        {
            float adjustedProgress = Remap(cycle.GetProgress(), 0f, 1f, -1f, 1f);
            render.GetPropertyBlock (mpb);
            mpb.SetFloat ("_RotationProgress", adjustedProgress);
            render.SetPropertyBlock (mpb);
            yield return null;
        }
    }
        // Fonction pour remapper une valeur d'une plage à une autre
    private float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    // void Update()
    // {
    //     // Utiliser la fonction LookAt pour faire tourner l'objet pour qu'il regarde vers le target
    //     // Transform tmp = new RectTransform();
    //     // tmp.position = rotationCycle.GetCyclingObject().position;
    //     // tmp.LookAt(target);
    //     // float offset = rotationCycle.GetRevolutionSelf().FindProgress(tmp.rotation);
    //     // offset -= rotationCycle.GetProgress();
    //     // offset %= 1f;
    //     
    //     // Reset rotation of object
    //     // rotationCycle.SetOrbitingObjectInCycle();
    //     
    //     // float face = -90f;
    //     // Vector3 rotationOffset = new Vector3(0f, face, 0f); // Décalage de rotation
    //     // transform.Rotate(rotationOffset);
    //        
    //      // Ajouter un décalage de rotation supplémentaire
    //     render.GetPropertyBlock (mpb);
    //     mpb.SetFloat ("_RotationProgress", cycle.GetProgress()/2);
    //     // mpb.SetFloat ("_RotationProgress", offset);
    //     render.SetPropertyBlock (mpb);
    // }

}
