using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuaternions : MonoBehaviour
{
    public RevolutionSelf revolutionSelf;
    [Range(0, 1)] public float progress = 0f;
    public float angle;
    Quaternion rotaQuaterInit;
    Quaternion rotaQuaterAdd;
    Quaternion rotaQuaterResult;
    
    // Start is called before the first frame update
    void Start()
    {
        //revolutionSelf = new RevolutionSelf();
        setRota();
    }

    private void setRota()
    {
        angle = progress * 360;
        rotaQuaterInit = Quaternion.Euler(revolutionSelf.initialRotation);
        rotaQuaterAdd = Quaternion.AngleAxis(angle, Vector3.up);
        rotaQuaterResult = rotaQuaterInit * rotaQuaterAdd;
        transform.rotation = rotaQuaterResult;
    }

    private void Update()
    {
        setRota();
    }
}
