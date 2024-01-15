using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TestCustomGrab : MonoBehaviour
{
    public TextMeshProUGUI text;
    private UnityEngine.XR.InputDevice _device;
    private bool _triggerValue = false;
    [SerializeField] private XRRayInteractor _rayInteractor;
    [SerializeField] private ActionBasedController _actionBasedController;
    private RaycastHit _hit;
    private int _isHit = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _device = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out _triggerValue) && _triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
            text.text = "Trigger button is pressed.";
        }*/

        Vector3 pos;
        Vector3 norm;
        int index;
        bool valid;
        if (_actionBasedController.uiPressAction.action.IsPressed())
        {
            Debug.Log("Trigger button is pressed.");
            text.text = "Trigger button is pressed. (UI Press)";
            /*_rayInteractor.TryGetHitInfo(out pos, out norm, out index, out valid);
            text.text = pos.ToString();*/
            if (_rayInteractor.TryGetCurrent3DRaycastHit(out _hit))
            {
                text.text = "Impact : Hit -- " + _hit.collider.gameObject.name;
                
            }
        }
    }
}
