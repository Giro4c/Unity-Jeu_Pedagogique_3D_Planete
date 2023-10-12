using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float rotateSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
}
