using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class RotationDetector : MonoBehaviour
{
    private RotationDrag rotationDragScript;
    private RotationAuto rotationAutoScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationDragScript = gameObject.GetComponent<RotationDrag>();
        rotationDragScript.enabled = false;
        rotationAutoScript = gameObject.GetComponent<RotationAuto>();
        rotationAutoScript.enabled = true;
    }

    private void OnMouseOver()
    {
        // On Mouse Down
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Mouse Clic Left");
            rotationDragScript.enabled = true;
            rotationAutoScript.enabled = false;
        }
        
        // On Mouse Up
        if (Input.GetMouseButtonUp(0) && rotationDragScript.enabled)
        {
            //Debug.Log("Mouse Drop Left: deactivate RotationDrag");
            rotationDragScript.enabled = false;
            rotationAutoScript.enabled = true;
        }
        
    }

    private void OnMouseExit()
    {
        if (rotationDragScript)
        {
            rotationDragScript.enabled = false;
        }

        if (!rotationAutoScript)
        {
            rotationAutoScript.enabled = true;
        }
        
    }
}
