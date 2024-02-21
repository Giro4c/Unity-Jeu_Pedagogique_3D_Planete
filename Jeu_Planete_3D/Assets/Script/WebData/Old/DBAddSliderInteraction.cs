/*
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using Slider = UnityEngine.UI.Slider;

public class DBAddSliderInteraction : MonoBehaviour
{
    public string type;
    public Slider slider;
    private IsEvaluation _isEvaluation;
    private EventSystem eventSys;
    //private int checkpoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        _isEvaluation = gameObject.GetComponent<IsEvaluation>();
        StartCoroutine(ControlLoad());
        //slider.onValueChanged.AddListener(delegate { SetIntermediateCheckpoint(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ControlLoad()
    {
        while (true)
        {
            print("No action on slider");
            // There is no action on the slider
            while (! (Input.GetMouseButton(0) && eventSys.IsPointerOverGameObject() &&
                      slider.gameObject.Equals(eventSys.currentSelectedGameObject)))
            {
                yield return null;
            }
            print("Slider is changed, there is action (Drag)");
            // There is an action on the slider (Drag) but waiting for the end of the action : release slider to get last changed value.
            while (! Input.GetMouseButtonUp(0))
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
*/
