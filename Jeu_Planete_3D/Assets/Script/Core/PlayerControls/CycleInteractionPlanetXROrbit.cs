using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CycleInteractionPlanetXROrbit : CycleInteractionPlanetXR
{

    [SerializeField] protected Collider planeOrbit;

    protected override void ProcessingInput()
    {
        RaycastHit hit;
        if (rayInteractor.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(planeOrbit))
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
