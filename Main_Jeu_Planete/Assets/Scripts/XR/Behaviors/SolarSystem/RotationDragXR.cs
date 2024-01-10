using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(RotationCycle))]
public class RotationDragXR : MonoBehaviour
{

    private RotationCycle rotationCycleScript;
    public float speedRotation = 11f;
    private bool active = true;
   
    private void OnEnable()
    {
        rotationCycleScript = gameObject.GetComponent<RotationCycle>();
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
            // Calculate newProgress
            float newProgress = rotationCycleScript.revolutionSelf.FindProgress(transform.rotation);
            
            rotationCycleScript.rotateProgress = newProgress;
        
            // Not Change object's rotation : already changed by grabbing
            //rotationCycleScript.SetRotation();
        
            yield return null;
            
        }
        yield return null;
    }
    
    
}
