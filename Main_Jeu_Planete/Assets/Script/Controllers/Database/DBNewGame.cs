using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class DBNewGame : MonoBehaviour
{
    private EventSystem eventSys;
    public Button buttonStart;
    
    // Start is called before the first frame update
    void Start()
    {
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        // When button is clicked, activate load of php page.
        buttonStart.clicked += () =>
        {
            Debug.Log("Button Start was pressed!");
            StartCoroutine(NewGamePhp());
        };
    }

    private IEnumerator NewGamePhp()
    {
        string url = "jeupedagogique.alwaysdata.net/views/addNewGame.php";
        Debug.Log(url);
        
        UnityWebRequest wwwNewGame = UnityWebRequest.Get(url);
        yield return wwwNewGame.SendWebRequest();
        if (wwwNewGame.error != null)
        {
            Debug.LogError(wwwNewGame.error);
        }
        else
        {
            Debug.Log("Page New Game Loaded");
            Debug.Log(wwwNewGame.downloadHandler.text);
        }
        
    }
    
    
}
