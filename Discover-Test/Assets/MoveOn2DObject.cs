using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOn2DObject : MonoBehaviour
{
    /**
     * Is the collider of an object the gameObject must be moved on.
     */
    public Collider collider2DObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        FollowCursor();
    }
    
    private void FollowCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (collider2DObject.Raycast(ray, out hit, 200))
        {
            Vector3 point = ray.GetPoint(hit.distance);
            point.y = transform.localScale.y / 2;
            transform.position = point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
