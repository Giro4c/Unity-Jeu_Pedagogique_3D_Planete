using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCycle : MonoBehaviour
{
    public Transform rotatingObject;
    public RevolutionSelf revolutionSelf;
    public float rotatePeriod = 3f;
    [Range(0f, 1f)] public float rotateProgress = 0f;
    
    public void SetRotation()
    {
        rotatingObject.localRotation = revolutionSelf.Evaluate(rotateProgress);
    }
    
    
}
