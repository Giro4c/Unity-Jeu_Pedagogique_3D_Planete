using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAuto : MonoBehaviour
{
    [SerializeField] private RotationCycle rotationCycleScript;
    public bool autoRotate = true;

    private void Start()
    {
        if (rotationCycleScript == null)
        {
            rotationCycleScript = gameObject.GetComponent<RotationCycle>();
        }
        else
        {
            enabled = false;
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
            
            // Update Rotation
            rotationCycleScript.SetRotation();
            
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
