using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Test2 : MonoBehaviour
{

    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Slider _slider;

    public GameObject pointerOver;

    // Start is called before the first frame update
    void Start()
    {
        pointerOver = _eventSystem.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_eventSystem.IsPointerOverGameObject())
        {
            Debug.Log("Pointer Over GameObject");
        }
        if (_eventSystem.currentSelectedGameObject != null)
        {
            Debug.Log("Selected object");
            // Debug.Log(_eventSystem.currentSelectedGameObject);
            
            Debug.Log(_slider.gameObject);
            Debug.Log("Hit ? " + _slider.gameObject.Equals(_eventSystem.currentSelectedGameObject));
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Mouse down");
        // }

        pointerOver = _eventSystem.currentSelectedGameObject;
    }
}
