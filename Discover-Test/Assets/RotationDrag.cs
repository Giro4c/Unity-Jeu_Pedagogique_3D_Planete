using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDrag : MonoBehaviour
{

    public Vector3 rotateAxis = new Vector3(0, 23, 0);
    public float speedRotation = 11f;
    private bool active = true;

    private void OnEnable()
    {
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
            //float yRotate = Input.GetAxis("Mouse Y") * speedRotation;
        
            transform.Rotate(rotateAxis, xRotate);
            //transform.Rotate(Vector3.right, yRotate);
            yield return null;
        }
        yield return null;
    }
    
    

    
}
