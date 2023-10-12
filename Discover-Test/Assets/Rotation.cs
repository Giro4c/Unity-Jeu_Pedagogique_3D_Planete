using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 rotateAxis = new Vector3(0, 23, 0);
    private float rotateSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
        }
        
    }
}
