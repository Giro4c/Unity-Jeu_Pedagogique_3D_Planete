using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] public Vector3 rotation; 
    [SerializeField] public int speed; 
    private bool button = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            button = true;
        }
        if(Input.GetKey("right"))
        {
            button = false;
        }
        
        if (button == true)
        {
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {

    }
}
