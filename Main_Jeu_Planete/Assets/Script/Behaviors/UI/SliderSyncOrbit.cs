using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSyncOrbit : MonoBehaviour
{
    public Orbit sliderValue;
    private Slider _slider;

    
    // Start is called before the first frame update
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        if (! canBeEnabled())
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Slider is not clicked on -> Sync value with orbit
        _slider.value = sliderValue.orbitProgress;
    }

    private void OnEnable()
    {
        enabled = canBeEnabled();
    }

    private bool canBeEnabled()
    {
        return sliderValue != null || _slider != null;
    }
}
