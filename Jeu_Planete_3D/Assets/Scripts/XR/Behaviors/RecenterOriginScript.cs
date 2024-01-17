using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RecenterOriginScript : MonoBehaviour
{
    //public Transform head;
    private Transform _origin;
    [SerializeField] private Transform target;
    
    public InputActionProperty recenterButtonR;
    public InputActionProperty recenterButtonL;
    

    private void Start()
    {
        _origin = transform;
        if (target == null)
        {
            enabled = false;
        }
    }

    private void Recenter()
    {
        /*Vector3 offset = head.position - origin.position;
        offset.y = 0;
        origin.position = target.position - offset;

        Vector3 targetForward = target.forward;
        targetForward.y = 0;
        Vector3 cameraForward = head.forward;
        cameraForward.y = 0;

        float angle = Vector3.SignedAngle(cameraForward, targetForward, Vector3.up);

        origin.RotateAround(head.position, Vector3.up, angle);*/

        _origin.position = target.position;
        _origin.rotation = target.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (recenterButtonR.action.WasPressedThisFrame())
        {
            Recenter();
        }

        if (recenterButtonL.action.WasPressedThisFrame())
        {
            Recenter();
        }
    }
}
