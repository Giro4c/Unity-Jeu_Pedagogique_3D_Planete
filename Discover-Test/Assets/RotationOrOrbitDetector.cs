using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class RotationOrOrbitDetector : MonoBehaviour
{
    private RotationDrag rotationDragScript;
    private RotationAuto rotationAutoScript;
    private OrbitMotion orbitMotionScript;
    //private OrbitDrag orbitDragScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationDragScript = gameObject.GetComponent<RotationDrag>();
        rotationDragScript.enabled = false;
        rotationAutoScript = gameObject.GetComponent<RotationAuto>();
        rotationAutoScript.enabled = true;
        orbitMotionScript = gameObject.GetComponentInParent<OrbitMotion>();
        orbitMotionScript.enabled = true;
        //orbitDragScript = gameObject.GetComponentInParent<OrbitDrag>();
        //orbitDragScript.enabled = false;
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
        else if (Input.GetMouseButton(1))
        {
            //Debug.Log("Mouse Clic Right");
            //orbitDragScript.enabled = true;
            orbitMotionScript.enabled = false;
        }
        
        // On Mouse Up
        if (Input.GetMouseButtonUp(0) && rotationDragScript.enabled)
        {
            //Debug.Log("Mouse Drop Left: deactivate RotationDrag");
            rotationDragScript.enabled = false;
            rotationAutoScript.enabled = true;
        }
        else if (Input.GetMouseButtonUp(1) && !orbitMotionScript.enabled)
        {
            //Debug.Log("Mouse Drop Right: activate OrbitMotion");
            //orbitDragScript.enabled = false;
            orbitMotionScript.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (rotationDragScript)
        {
            rotationDragScript.enabled = false;
        }
        /*if (orbitDragScript)
        {
            orbitDragScript.enabled = false;
        }*/

        if (!rotationAutoScript)
        {
            rotationAutoScript.enabled = true;
        }
        if (!orbitMotionScript)
        {
            orbitMotionScript.enabled = true;
        }
        
    }
}
