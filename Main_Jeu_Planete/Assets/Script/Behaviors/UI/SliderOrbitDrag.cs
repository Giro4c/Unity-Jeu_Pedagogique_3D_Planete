using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderOrbitDrag : MonoBehaviour
{
    private EventSystem _eventSys;
    public Orbit sliderValue;
    public OrbitMotion orbitAutoChanger;
    private SliderSyncOrbit _sliderAutoChanger;
    private Slider _slider;

    
    // Start is called before the first frame update
    void Start()
    {
        _eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _slider = gameObject.GetComponent<Slider>();
        _sliderAutoChanger = gameObject.GetComponent<SliderSyncOrbit>();
        if (sliderValue == null || orbitAutoChanger == null || _eventSys == null || _slider == null || _sliderAutoChanger == null)
        {
            enabled = false;
        }
        // Start background task that detect if slider is clicked then released to update orbit and deactivate/reactivate orbit automatic changer (OrbitMotion)
        Debug.Log("Start Coroutine ControlDrag");
        StartCoroutine(ControlDrag());
    }
    
    private IEnumerator ControlDrag()
    {
        while (true)
        {
            print("No action on slider orbit");
            // There is no action on the slider
            while (! (Input.GetMouseButton(0) && _eventSys.IsPointerOverGameObject() &&
                      _slider.gameObject.Equals(_eventSys.currentSelectedGameObject)))
            {
                yield return null;
            }
            print("Slider orbit is changed, there is action (Drag)");
            // Deactivating OrbitMotion (orbit auto changer) and SliderSyncOrbit (slider auto changer)
            orbitAutoChanger.enabled = false;
            print("OrbitMotion disabled");
            _sliderAutoChanger.enabled = false;
            print("SliderSyncOrbit disabled");
            // There is an action on the slider (Drag) but waiting for the end of the action : release slider to get last changed value.
            while (! Input.GetMouseButtonUp(0))
            {
                sliderValue.orbitProgress = _slider.value;
                sliderValue.SetOrbitingObjectPosition();
                yield return null;
            }
            print("Slider Orbit is released");
            // Reactivating OrbitMotion (orbit auto changer) and SliderSyncOrbit (slider auto changer)
            orbitAutoChanger.enabled = true;
            print("OrbitMotion enabled");
            _sliderAutoChanger.enabled = true;
            print("SliderSyncOrbit enabled");
            
        }
    }
}
