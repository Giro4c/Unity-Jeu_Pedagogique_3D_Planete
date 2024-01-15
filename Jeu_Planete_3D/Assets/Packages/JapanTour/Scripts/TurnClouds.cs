using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnClouds : MonoBehaviour
{
    public float speed = 1;
    public Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}