using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAuto : MonoBehaviour
{
    [SerializeField] private RotationCycle rotationCycleScript;
    private bool autoRotate = true;
    [SerializeField] private Renderer render;
    [SerializeField] private MaterialPropertyBlock mpb;

    private void Start()
    {
        if (rotationCycleScript == null)
        {
            rotationCycleScript = gameObject.GetComponent<RotationCycle>();
            if (rotationCycleScript == null)
            {
                autoRotate = false;
                enabled = false;
            }
        }
        
    }

    IEnumerator AutoRotation()
    {
        float rotatorSpeed = 1f / rotationCycleScript.rotatePeriod;
        while (autoRotate)
        {
            // Update progress
            rotationCycleScript.rotateProgress += Time.deltaTime * rotatorSpeed;
            rotationCycleScript.rotateProgress %= 1f;
            
            render.GetPropertyBlock (mpb);
            mpb.SetFloat("_RotationPeriod", rotationCycleScript.rotatePeriod);
            mpb.SetFloat ("_RotationProgress", rotationCycleScript.rotateProgress);
            GetComponent<Renderer>().SetPropertyBlock (mpb);
            
            yield return null;
        }
        yield return null;
    }

    private void OnDisable()
    {
        autoRotate = false;
        StopCoroutine(AutoRotation());
    }

    private void OnEnable()
    {
        render = GetComponent<Renderer> ();
        mpb = new MaterialPropertyBlock ();
        if (rotationCycleScript == null)
        {
            autoRotate = false;
            enabled = false;
            return;
        }
        autoRotate = true;
        StartCoroutine(AutoRotation());
    }
}