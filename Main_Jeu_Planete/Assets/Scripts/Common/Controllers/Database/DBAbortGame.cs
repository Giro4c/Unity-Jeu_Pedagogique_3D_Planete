using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBAbortGame : MonoBehaviour
{
    public Button buttonEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonEnd.onClick.AddListener(delegate { StartCoroutine(AbortGamePhp()); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
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
