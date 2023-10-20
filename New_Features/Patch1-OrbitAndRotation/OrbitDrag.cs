using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbit))]
public class OrbitDrag : MonoBehaviour
{

    public bool active = true;
    /**
     * Is the collider of the object model of the orbiting object.
     */
    public Collider colliderPlaneOrbit;
    //public float orbitSpeed = 11f;
    private Orbit orbit;
    private Camera mainCam;
    
    private void OnEnable()
    {
        mainCam = Camera.main;
        orbit = gameObject.GetComponent<Orbit>();
        if (orbit.orbitingObject == null)
        {
            active = false;
            return;
        }
        else
        {
            active = true;
        }
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
                Vector3 point = ray.GetPoint(hit.distance);
                Vector2 orbitPos = new Vector2(point.x - transform.position.x, point.z - transform.position.z);
                float newProgress = orbit.orbitPath.FindProgress(orbitPos.x, orbitPos.y);
                
                orbit.orbitProgress = newProgress;
                orbit.SetOrbitingObjectPosition();
            }
            yield return null;
        }

        yield return null;
    }
    
    
}
