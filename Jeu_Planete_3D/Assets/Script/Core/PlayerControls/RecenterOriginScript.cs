using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class RecenterOriginScript : PlayerControl
{
    [Tooltip("The object whose location will be changed")] 
    [SerializeField] private Transform target;
    [Tooltip("The target reset position for the teleportation")] 
    [SerializeField] private Transform resetPosition;

    protected override void ProcessingInput()
    {
        target.position = resetPosition.position;
        target.rotation = resetPosition.rotation;
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
