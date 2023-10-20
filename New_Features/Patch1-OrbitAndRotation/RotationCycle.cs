using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCycle : MonoBehaviour
{
    public Vector3 initialRotation = new Vector3(0, 0, 23);
    private Quaternion initialQuaternion;
    public Vector3 rotateAxis = new Vector3(0, 23, 0);
    public float rotatePeriod = 3f;
    [Range(0f, 1f)] public float rotateProgress = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = initialRotation;
        initialQuaternion = transform.localRotation;
    }
    
    public void SetRotation()
    {
        transform.eulerAngles = initialRotation;
        float angle = rotateProgress * 360;
        transform.Rotate(rotateAxis, angle);
    }

    public float FindProgress()
    {
        float angle = Quaternion.Angle(transform.localRotation, initialQuaternion);
        //Debug.Log("Angle : " + angle);
        float newProgress = angle / 360;
        return newProgress%1;
    }
    
}
