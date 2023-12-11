using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBNewGame : MonoBehaviour
{
    public Button buttonStart;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonStart.onClick.AddListener(delegate { StartCoroutine(NewGamePhp()); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
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
