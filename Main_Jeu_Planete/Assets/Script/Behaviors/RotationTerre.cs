using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTerre : MonoBehaviour
{
    [SerializeField] public Vector3 rotation; 
    [SerializeField] public int speed;
    public Orbite ellipse ;


    // Update is called once per frame
    void Update()
    {
        if (ellipse.orbitProgress >= 0.8f)
        {
            transform.Rotate(rotation * speed * Time.deltaTime);
            print("07");
        }
        else if (ellipse.orbitProgress <= 0.2f)
        {
            transform.Rotate(rotation * (speed-1)* Time.deltaTime);
            print("03");
        }
        else if (ellipse.orbitProgress >= 0.3f && ellipse.orbitProgress <= 0.7f)
        {
            transform.Rotate(rotation * (speed - 3) * Time.deltaTime);
            print("06");
        }
        else
        {
            transform.Rotate(rotation * (speed - 3) * Time.deltaTime);
            print("05");
        }
                
    }
}
