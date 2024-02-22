using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RecenterOriginScript : PlayerControl
{
    [SerializeField] private Transform _origin;
    [SerializeField] private Transform target;

    protected override void ProcessingInput()
    {
        _origin.position = target.position;
        _origin.rotation = target.rotation;
    }

    // public override bool IsTriggered()
    // {
    //     return base.IsTriggered();
    // }
    
    
    // public override bool IsControlActive()
    // {
    //     throw new System.NotImplementedException();
    // }

}
