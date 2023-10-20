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
            float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);
            
            rotationCycleScript.rotateProgress += xRotate / 360;
            rotationCycleScript.rotateProgress %= 1;
            
            rotationCycleScript.SetRotation();
            
            yield return null;
        }
        yield return null;
    }
    
    
}
