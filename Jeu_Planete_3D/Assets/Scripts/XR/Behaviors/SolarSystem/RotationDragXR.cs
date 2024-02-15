using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationDragXR : MonoBehaviour
{

    [SerializeField] private RotationCycle rotationCycleScript;
    private bool active = true;
    [SerializeField] private Renderer render;
    [SerializeField] private MaterialPropertyBlock mpb;
    private void Start()
    {
        if (rotationCycleScript == null)
        {
            rotationCycleScript = gameObject.GetComponent<RotationCycle>();
            if (rotationCycleScript == null)
            {
                active = false;
                enabled = false;
            }
        }
    }

    private void OnEnable()
    {
        render = GetComponent<Renderer> ();
        mpb = new MaterialPropertyBlock ();
        if (rotationCycleScript == null)
        {
            active = false;
            enabled = false;
            return;
        }
        active = true;
        StartCoroutine(DragAndRotate());
    }

    private void OnDisable()
    {
        active = false;
        StopCoroutine(DragAndRotate());
    }

   
    private IEnumerator DragAndRotate()
    {
        
        while (active)
        {
            // Test avec local position
            
            float newProgress = rotationCycleScript.revolutionSelf.FindProgress(transform.localRotation);
            rotationCycleScript.rotateProgress = newProgress;
            // Change object's rotation
            render.GetPropertyBlock (mpb);
            
            mpb.SetFloat ("_RotationProgress", rotationCycleScript.rotateProgress);
            GetComponent<Renderer>().SetPropertyBlock (mpb);
            
            yield return null;
            
        }
        
    }
    
    
}
