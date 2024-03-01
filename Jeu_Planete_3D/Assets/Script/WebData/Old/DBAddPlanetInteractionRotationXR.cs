/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class DBAddPlanetInteractionRotationXR : MonoBehaviour
{
    public string type = "DragRotation";
    public RotationCycle rotationCycle;
    public Collider planetCollider;
    private IsEvaluation _isEvaluation;
    
    [Header("Right Hand")]
    [SerializeField] private ActionBasedController controllerRight;
    [SerializeField] private XRRayInteractor rayInteractorRight;
    
    [Header("Left Hand")]
    [SerializeField] private ActionBasedController controllerLeft;
    [SerializeField] private XRRayInteractor rayInteractorLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        _isEvaluation = gameObject.GetComponent<IsEvaluation>();
        StartCoroutine(ControlLoad(controllerRight, rayInteractorRight));
        StartCoroutine(ControlLoad(controllerLeft, rayInteractorLeft));
    }
    
    private IEnumerator ControlLoad(ActionBasedController controller, XRRayInteractor rayInteractor)
    {
        RaycastHit hit;
        while (true)
        {
            print("No action on rotation planet");
            // There is no action on the slider
            while (! (controller.selectAction.action.IsPressed() && rayInteractor.TryGetCurrent3DRaycastHit(out hit) && hit.collider.Equals(planetCollider)))
            {
                yield return null;
            }
            print("Planet rotation is changed, there is action (Drag Left)");
            // There is an action on the planet (Drag Left) but waiting for the end of the action : release planet to get last changed value.
            while (controller.selectAction.action.IsPressed())
            {
                yield return null;
            }
            print("Planet is released");
            // The mouse button is released, retrieving value of planet rotateProgress
            StartCoroutine(AddInteractionPhp());
        }
    }
    
    private IEnumerator AddInteractionPhp()
    {
        string strVarURLGet = "";
        strVarURLGet = "type=" + type + "&value=" + rotationCycle.rotateProgress.ToString().Replace(',', '.');
        string url = "jeupedagogique.alwaysdata.net/views/addInteraction.php?" + strVarURLGet + "&isEval=" + _isEvaluation.IsEvalInt();
        Debug.Log(url);
        
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
        }
        else
        {
            Debug.Log("Page Interaction " + type + " Loaded");
            Debug.Log(wwwInteract.downloadHandler.text);
        }
        
    }
    
}
*/
