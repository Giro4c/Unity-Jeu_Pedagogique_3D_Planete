using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestRotationDrag : MonoBehaviour
{
    [SerializeField] private RotationCycle cycleInfo;
    [SerializeField] private TextMeshProUGUI textShowDebug1;
    [SerializeField] private TextMeshProUGUI textShowDebug2;
    [SerializeField] private TextMeshProUGUI textShowDebug3;

    [SerializeField] private Transform pTransform;

    [SerializeField] private ActionBasedController actionBasedController;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textShowDebug1.text = "Rotation progress : " + cycleInfo.rotateProgress;
        textShowDebug3.text = pTransform.eulerAngles.ToString();
        
        if (actionBasedController.selectAction.action.WasReleasedThisFrame())
        {
            textShowDebug2.text = "Grab / Select released";
        }
        if (actionBasedController.selectAction.action.IsInProgress())
        {
            textShowDebug2.text = "Grab / Select in progress";
        }
        if (actionBasedController.selectAction.action.IsPressed())
        {
            textShowDebug2.text = "Grab / Select pressed";
        }
        
        
        
    }
}
