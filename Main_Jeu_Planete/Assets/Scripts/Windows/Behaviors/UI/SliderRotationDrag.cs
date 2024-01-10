using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderRotationDrag : MonoBehaviour
{
    private EventSystem _eventSys;
    public RotationCycle sliderValue;
    public RotationAuto rotaAutoChanger;
    private bool automotionActivated = true;
    private SliderSyncRotation _sliderAutoChanger;
    private Slider _slider;

    private Coroutine _currentRoutine;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _slider = gameObject.GetComponent<Slider>();
        _sliderAutoChanger = gameObject.GetComponent<SliderSyncRotation>();
        if (sliderValue == null || rotaAutoChanger == null || _eventSys == null || _slider == null || _sliderAutoChanger == null)
        {
            enabled = false;
        }
        // Start background task that detect if slider is clicked then released to update orbit and deactivate/reactivate orbit automatic changer (RotationAuto)
        //Debug.Log("Start Coroutine ControlDrag");
        //StartCoroutine(ControlDrag());
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
            print("Slider rotation is changed, there is action (Drag)");
            // Deactivating RotationAuto (rota auto changer) and SliderSyncRotation (slider auto changer)
            rotaAutoChanger.enabled = false;
            print("RotationAuto disabled");
            _sliderAutoChanger.enabled = false;
            print("SliderSyncRotation disabled");
            // There is an action on the slider (Drag) but waiting for the end of the action : release slider to get last changed value.
            while (! Input.GetMouseButtonUp(0))
            {
                sliderValue.rotateProgress = _slider.value;
                sliderValue.SetRotation();
                yield return null;
            }
            print("Slider Rotation is released");
            // Reactivating RotationAuto (rota auto changer) and SliderSyncRotation (slider auto changer)
            if (automotionActivated)
            {
                rotaAutoChanger.enabled = true;
                print("RotationAuto enabled");
            }
            _sliderAutoChanger.enabled = true;
            print("SliderSyncRotation enabled");
            
        }
    }
    
    private void OnEnable()
    {
        // Start background task that detect if slider is clicked then released to update orbit and deactivate/reactivate orbit automatic changer (RotationAuto)
        Debug.Log("SliderRotationDrag enabled, Starting coroutine");
        _currentRoutine = StartCoroutine(ControlDrag());
    }

    private void OnDisable()
    {
        Debug.Log("SliderRotationDrag disabled, Stopping coroutine");
        StopCoroutine(_currentRoutine);
        Debug.Log("Coroutine stopped");
        print("enabled = " + enabled);
    }
    
    public bool IsAutoMotionActivated()
    {
        return automotionActivated;
    }
    public void SetAutoMotion(bool val)
    {
        automotionActivated = val;
    }
}
