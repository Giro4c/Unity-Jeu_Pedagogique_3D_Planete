using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Orbit))]
public class OrbitMotion : MonoBehaviour
{
    /*
     public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)] public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    */
    public bool orbitActive = true;
    private Orbit orbit;
    
    // Start is called before the first frame update
    /*void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }*/

    private void OnEnable()
    {
        orbit = gameObject.GetComponent<Orbit>();
        if (orbit.orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        else
        {
            orbitActive = true;
        }
        orbit.SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    private void OnDisable()
    {
        orbitActive = false;
        StopCoroutine(AnimateOrbit());
    }

    /*private void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }*/

    IEnumerator AnimateOrbit()
    {
        if (orbit.orbitPeriod < 0.1f)
        {
            orbit.orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbit.orbitPeriod;
        while (orbitActive)
        {
            orbit.orbitProgress += Time.deltaTime * orbitSpeed;
            orbit.orbitProgress %= 1f;
            orbit.SetOrbitingObjectPosition();
            yield return null;
        }
    }
    
}
