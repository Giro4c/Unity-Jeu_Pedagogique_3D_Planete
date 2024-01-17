using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDrag : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Orbit orbit;
    
    /// <summary>
    /// Is the collider of the object model of the orbiting object.
    /// </summary>
    [SerializeField] private Collider colliderPlaneOrbit;

    
    private bool active = true;

    private void Start()
    {
        if (!mainCam)
        {
            mainCam = Camera.main;
        }
        
        if (orbit == null)
        {
            orbit = gameObject.GetComponent<Orbit>();
            if (orbit == null || orbit.orbitingObject == null)
            {
                active = false;
                enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        if (orbit == null || orbit.orbitingObject == null)
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
        while (active)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (colliderPlaneOrbit.Raycast(ray, out hit, 200))
            {
                // Calculates the local position of the collision point based on the transform of the orbit plane's collider.
                Vector3 hitPoint = hit.point;
                Vector3 orbitPos = colliderPlaneOrbit.transform.InverseTransformPoint(hitPoint);
        
                // Determines new orbit progress and update value
                float newProgress = orbit.orbitPath.FindProgress(orbitPos.x, orbitPos.z);
                
                orbit.orbitProgress = newProgress;
                orbit.SetOrbitingObjectPosition();
            }
            yield return null;
        }

        yield return null;
    }
    
    
}
