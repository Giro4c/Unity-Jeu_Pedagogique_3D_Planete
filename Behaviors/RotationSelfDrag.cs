using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private Vector3 rotateAxis = new Vector3(0, -23, 0);
    private float speedRotation = 11f;

    private void OnMouseDrag()
    {
        float xRotate = Input.GetAxis("Mouse X") * speedRotation;
        //float yRotate = Input.GetAxis("Mouse Y") * speedRotation;
        
        transform.Rotate(rotateAxis, xRotate);
        //transform.Rotate(Vector3.right, yRotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
