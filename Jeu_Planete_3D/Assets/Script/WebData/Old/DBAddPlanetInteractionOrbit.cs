/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBAddPlanetInteractionOrbit : MonoBehaviour
{
    public string type = "DragOrbit";
    public Orbit orbit;
    public Collider planetCollider;
    private IsEvaluation _isEvaluation;
    
    private Camera camMain;
    
    // Start is called before the first frame update
    void Start()
    {
        camMain = Camera.main;
        _isEvaluation = gameObject.GetComponent<IsEvaluation>();
        StartCoroutine(ControlLoad());
    }
    
    private IEnumerator ControlLoad()
    {
        while (true)
        {
            print("No action on orbit planet");
            // There is no action on the slider
            RaycastHit hit;
            while (! (Input.GetMouseButton(1) && planetCollider.Raycast(camMain.ScreenPointToRay(Input.mousePosition), out hit, 100)))
            {
                yield return null;
            }
            print("Planet orbit is changed, there is action (Drag Right)");
            // There is an action on the planet (Drag Right) but waiting for the end of the action : release planet to get last changed value.
            while (! Input.GetMouseButtonUp(1))
            {
                yield return null;
            }
            print("Planet is released");
            // The mouse button is released, retrieving value of planet orbitProgress
            StartCoroutine(AddInteractionPhp());
        }
    }
    
    private IEnumerator AddInteractionPhp()
    {
        string strVarURLGet = "";
        strVarURLGet = "type=" + type + "&value=" + orbit.orbitProgress.ToString().Replace(',', '.');
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
