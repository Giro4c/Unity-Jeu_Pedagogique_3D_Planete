using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !Physics.Raycast(transform.position, Input.mousePosition, 100))
        {
            transform.eulerAngles += speed * new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0);
        }
    }
}
