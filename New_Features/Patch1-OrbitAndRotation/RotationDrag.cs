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
        rotationCycleScript = gameObject.GetComponent<RotationCycle>();
    }
    
   
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
            //Quaternion rotaB = transform.localRotation;
            /*if (xRotate != 0)
            {
                Debug.Log("Rotation angle = " + xRotate);
                Debug.Log("Euler angles Before : " + transform.eulerAngles);
                Debug.Log("Quaternion Before : " + rotaB);
            }*/
            
            transform.Rotate(rotationCycleScript.rotateAxis, xRotate);
            rotationCycleScript.rotateProgress = rotationCycleScript.FindProgress();
            //float angle = Quaternion.Angle(rotaB, transform.localRotation);
            /*if (xRotate != 0)
            {
                Debug.Log("Euler angles After : " + transform.eulerAngles);
                Debug.Log("Quaternion After : " + transform.localRotation);
                Debug.Log("Angle found : " + angle);
            }*/

            
            yield return null;
        }
        yield return null;
    }
    
    private IEnumerator DragAndRotateOld()
    {
        while (active)
        {
            float xRotate = Input.GetAxis("Mouse X") * speedRotation * (-1);
            //float yRotate = Input.GetAxis("Mouse Y") * speedRotation;
        
            transform.Rotate(rotationCycleScript.rotateAxis, xRotate);
            //transform.Rotate(Vector3.right, yRotate);
            yield return null;
        }
        yield return null;
    }
    
    

    
}
