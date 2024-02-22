using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    
    public bool orbitActive = true;
    [SerializeField] private Orbit orbit;
    
    private void Start()
    {
        if (orbit == null)
        {
            orbit = gameObject.GetComponent<Orbit>();
            if (orbit == null)
            {
                orbitActive = false;
                enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        if (orbit == null || orbit.orbitingObject == null)
        {
            orbitActive = false;
            enabled = false;
            return;
        }
        orbitActive = true;
        orbit.SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    private void OnDisable()
    {
        orbitActive = false;
        StopCoroutine(AnimateOrbit());
    }

    IEnumerator AnimateOrbit()
    {
        if (orbit.orbitPeriod < 0.1f)
        {
            orbit.orbitPeriod = 0.1f;
        }
        
        while (orbitActive)
        {
            float orbitSpeed = 1f / orbit.orbitPeriod;
            orbit.orbitProgress += Time.deltaTime * orbitSpeed;
            orbit.orbitProgress %= 1f;
            orbit.SetOrbitingObjectPosition();
            yield return null;
        }
    }
    
}
