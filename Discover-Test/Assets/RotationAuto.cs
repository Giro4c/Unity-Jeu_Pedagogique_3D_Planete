using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAuto : MonoBehaviour
{
    public Vector3 rotateAxis = new Vector3(0, 23, 0);
    public float rotatePeriod = 3f;
    public bool autoRotate = true;
    [Range(0f, 1f)] public float rotateProgress = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        SetRotation();
        StartCoroutine(AutoRotation());
    }

    private void SetRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, 23);
        float angle = rotateProgress * 360;
        transform.Rotate(rotateAxis, angle);
    }
    
    IEnumerator AutoRotation()
    {
        float rotatorSpeed = 1f / rotatePeriod;
        float angleAdded;
        while (autoRotate)
        {
            rotateProgress += Time.deltaTime * rotatorSpeed;
            rotateProgress %= 1f;
            angleAdded = Time.deltaTime * rotatorSpeed * 360;
            transform.Rotate(rotateAxis, angleAdded);
            //SetRotation();
            yield return null;
        }
        yield return null;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        autoRotate = false;
        StopCoroutine(AutoRotation());
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        autoRotate = true;
        StartCoroutine(AutoRotation());
    }
}
