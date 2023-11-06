using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class DBAbortGame : MonoBehaviour
{
    private EventSystem eventSys;
    public Button buttonEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        // When button is clicked, activate load of php page.
        buttonEnd.clicked += () =>
        {
            Debug.Log("Button End Game was pressed!");
            StartCoroutine(AbortGamePhp());
        };
    }

    private IEnumerator AbortGamePhp()
    {
        string url = "jeupedagogique.alwaysdata.net/views/abortOnGoingGame.php";
        Debug.Log(url);
        
        UnityWebRequest wwwAbortGame = UnityWebRequest.Get(url);
        yield return wwwAbortGame.SendWebRequest();
        if (wwwAbortGame.error != null)
        {
            Debug.LogError(wwwAbortGame.error);
        }
        else
        {
            Debug.Log("Page Abort Game Loaded");
            Debug.Log(wwwAbortGame.downloadHandler.text);
        }
        
    }
    
    
}
