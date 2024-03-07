using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{

    [SerializeField]
    private InputActionProperty _actionProperty;

    // private Test testing = new Test();
    
    public Vector3 positionMouse;

    // private void Awake()
    // {
        // Test testing = new Test();
    // }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_actionProperty.action.bindings.Count);
        for (int i = 0; i < _actionProperty.action.bindings.Count; ++i)
        {
            Debug.Log(_actionProperty.action.bindings[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionProperty.action.triggered)
        {
            Debug.Log("Action triggered");
            Debug.Log(_actionProperty.action);
        }
        if (_actionProperty.action.IsPressed())
        {
            Debug.Log("Action pressed");
            Debug.Log(_actionProperty.action);
        }
        if (_actionProperty.action.IsInProgress())
        {
            Debug.Log("Action in progress");
            Debug.Log(_actionProperty.action);
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Mouse down");
        //     // Debug.Log(_actionProperty.action.ReadValue<bool>());
        //     Debug.Log(_actionProperty.action);
        // }

        positionMouse = Input.mousePosition;
    }
}
