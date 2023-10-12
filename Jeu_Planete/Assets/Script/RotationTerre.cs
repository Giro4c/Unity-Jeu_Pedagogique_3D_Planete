using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTerre : MonoBehaviour
{
    [SerializeField] public Vector3 rotation; 
    [SerializeField] public int speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
