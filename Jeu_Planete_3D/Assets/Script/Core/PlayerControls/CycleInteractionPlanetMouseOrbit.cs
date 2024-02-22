using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class CycleInteractionPlanetMouseOrbit : CycleInteractionPlanetMouse
{

    [SerializeField] protected Collider planeOrbit;
    
    protected override void ProcessingInput()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (planeOrbit.Raycast(ray, out hit, 50))
        {
            SetOrbitToHitPoint(hit);
        }
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Changes the orbit progress and the position of the orbiting object based on the hit point of a Raycast with the orbit plane collider.
    /// </summary>
    /// <param name="hit">The RaycastHit containing all infos on the raycast collision.</param>
    private void SetOrbitToHitPoint(RaycastHit hit)
    {
        // Calculates the local position of the collision point based on the transform of the orbit plane's collider.
        Vector3 hitPoint = hit.point;
        Vector3 orbitPos = planeOrbit.transform.InverseTransformPoint(hitPoint);
        
        // Determines new orbit progress and update value
        float newProgress = ((Orbit) cycleAffected).GetOrbitPath().FindProgress(orbitPos.x, orbitPos.z);
        cycleAffected.SetProgress(newProgress);

        // Changes the position of the orbiting object
        cycleAffected.SetOrbitingObjectInCycle();
        
    }
    
}
