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

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
   
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
            Debug.Log("New progress : " + (rotationCycleScript.rotateProgress + (xRotate / 360)));
            rotationCycleScript.rotateProgress += xRotate / 360;
            rotationCycleScript.rotateProgress %= 1;
            
            rotationCycleScript.SetRotation();
            
            yield return null;
        }
        yield return null;
    }
    
    private IEnumerator DragAndRotateOld()
    {
        while (active)
        {
            float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);
            //float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);

            //float yRotate = Input.GetAxis("Mouse Y") * speedRotation;
        
            rotationCycleScript.AddAngleToRotation(xRotate);
            //transform.Rotate(Vector3.right, yRotate);
            yield return null;
        }
        yield return null;
    }
    
    

    
}
