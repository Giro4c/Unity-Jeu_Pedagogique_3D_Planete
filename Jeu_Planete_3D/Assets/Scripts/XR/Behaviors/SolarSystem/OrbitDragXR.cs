using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OrbitDragXR : MonoBehaviour
{

    private bool active = true;
    
    /**
     * Is the collider of the object model of the orbiting object.
     */
    [SerializeField] private Collider colliderPlaneOrbit;
    [SerializeField] private Orbit orbit;

    [Header("Ray Interactors")]
    [SerializeField] private XRRayInteractor rayInteractorRight;
    [SerializeField] private XRRayInteractor rayInteractorLeft;
    
    private void Start()
    {
        if (orbit == null)
        {
            orbit = gameObject.GetComponent<Orbit>();
            if (orbit == null || (rayInteractorRight == null && rayInteractorLeft == null))
            {
                active = false;
                enabled = false;
            }
        }
    }
    
    private void OnEnable()
    {
        if (orbit == null || (rayInteractorRight == null && rayInteractorLeft == null) || orbit.orbitingObject == null)
        {
            active = false;
            enabled = false;
            return;
        }
        active = true;
        StartCoroutine(DragOrbit());
    }

    private void OnDisable()
    {
        active = false;
        StopCoroutine(DragOrbit());
    }
    
    IEnumerator DragOrbit()
    {
        RaycastHit hit;
        while (active)
        {
            if (rayInteractorRight.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(colliderPlaneOrbit))
            {
                SetOrbitToHitPoint(hit);
            }
            else if (rayInteractorLeft.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(colliderPlaneOrbit))
            {
                SetOrbitToHitPoint(hit);
            }
            yield return null;
        }

    }

    /// <summary>
    /// Changes the orbit progress and the position of the orbiting object based on the hit point of a Raycast with the orbit plane collider.
    /// </summary>
    /// <param name="hit">The RaycastHit containing all infos on the raycast collision.</param>
    private void SetOrbitToHitPoint(RaycastHit hit)
    {
        // Calculates the local position of the collision point based on the transform of the orbit plane's collider.
        Vector3 hitPoint = hit.point;
        Vector3 orbitPos = colliderPlaneOrbit.transform.InverseTransformPoint(hitPoint);
        
        // Determines new orbit progress and update value
        float newProgress = orbit.orbitPath.FindProgress(orbitPos.x, orbitPos.z);
        orbit.orbitProgress = newProgress;

        // Changes the position of the orbiting object
        orbit.SetOrbitingObjectPosition();
        
    }
    
}
