using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TestSelect : MonoBehaviour
{
    public TextMeshProUGUI text;
    private UnityEngine.XR.InputDevice _device;
    private bool _triggerValue = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _device = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out _triggerValue) && _triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
            text.text = "Trigger button is pressed.";
        }
    }
    
    public void HasBeenSelected(){
        print("Object sélectionné...");
        text.text = "Sélection en cours...";
    }
    
    public void NoLongerSelected(){
        print("Object libéré...");
        text.text = "Pas de sélection en cours...";
    }

    public void HasBeenActivated()
    {
        text.text = "Activé...";
    }
    
    public void HasBeenDeactivated()
    {
        text.text = "Désactivé...";
    }
    
}
