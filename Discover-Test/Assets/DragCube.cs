using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Newer Version : DragAndDrop
 */
public class DragCube : MonoBehaviour
{

    private Camera mainCamera;
    private Vector3 offset;

    private Vector3 GetMouseWorldPos()
    {
        // Pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;
        
        // z coordinates of game object on screen
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;

        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
    }
    
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        
    }
    
}
