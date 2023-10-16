using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbit))]
public class OrbitDrag : MonoBehaviour
{

    public bool active = true;
    //public float orbitSpeed = 11f;
    private Orbit orbit;
    
    private void OnEnable()
    {
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
            yield return null;
        }

        yield return null;
    }

    private void updateProgress()
    {
        
    }
    
}
