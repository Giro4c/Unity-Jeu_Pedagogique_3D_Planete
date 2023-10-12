using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotation; 
    public int speed; 
    private bool button = false;

    void Start()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("SoleilLum");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.white;
        lightComp.range = 20;
        lightComp.intensity = 30;
        lightComp.type= LightType.Point;

        // Set the position (or any transform property)
        lightGameObject.transform.position = new Vector3(-7, -4, 11);
    }
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
