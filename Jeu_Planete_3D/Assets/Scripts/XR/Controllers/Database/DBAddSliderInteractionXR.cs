using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;
using Slider = UnityEngine.UI.Slider;

public class DBAddSliderInteractionXR : MonoBehaviour
{
    public string type;
    public Slider slider;
    private IsEvaluation _isEvaluation;
    private EventSystem eventSys;

    [Header("Action Based Controllers")] 
    [SerializeField] private ActionBasedController controllerRight;
    [SerializeField] private ActionBasedController controllerLeft;

    
    // Start is called before the first frame update
    void Start()
    {
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _isEvaluation = gameObject.GetComponent<IsEvaluation>();
        StartCoroutine(ControlLoad(controllerRight));
        StartCoroutine(ControlLoad(controllerLeft));
    }

    private IEnumerator ControlLoad(ActionBasedController controller)
    {
        while (true)
        {
            print("No action on slider");
            // There is no action on the slider
            while (! (controller.uiPressAction.action.IsPressed() && eventSys.IsPointerOverGameObject() &&
                      slider.gameObject.Equals(eventSys.currentSelectedGameObject)))
            {
                yield return null;
            }
            print("Slider is changed, there is action (Drag)");
            // There is an action on the slider (Drag) but waiting for the end of the action : release slider to get last changed value.
            while (controller.uiPressAction.action.IsPressed())
            {
                yield return null;
            }
            print("Slider is released");
            // The mouse button is released, retrieving value of slider
            StartCoroutine(AddInteractionPhp());
        }
    }

    private IEnumerator AddInteractionPhp()
    {
        string floatValStr = "&value=" + slider.value;
        floatValStr = floatValStr.Replace(',', '.');
        string url = "jeupedagogique.alwaysdata.net/views/addInteraction.php?type=Slider" + type + floatValStr + "&isEval=" + _isEvaluation.IsEvalInt();
        Debug.Log(url);
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
        }
        else
        {
            Debug.Log("Page Interaction Loaded");
            Debug.Log(wwwInteract.downloadHandler.text);
        }
        
    }
    
}
