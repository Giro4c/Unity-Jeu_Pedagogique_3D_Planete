using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotationCycle))]
public class RotationDrag : MonoBehaviour
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
            // Find angle to add to the rotation
            float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);
            xRotate %= 360f;
            
            // Calculate newProgress
            float newProgress = rotationCycleScript.rotateProgress + xRotate / 360f;
            
            if (newProgress < 0)
            {
                newProgress += 1;
            }
            else if (newProgress >= 1)
            {
                newProgress %= 1f;
            }
            rotationCycleScript.rotateProgress = newProgress;
            
            // Change object's rotation
            rotationCycleScript.SetRotation();
            
            yield return null;
        }
        yield return null;
    }
    
    
}
