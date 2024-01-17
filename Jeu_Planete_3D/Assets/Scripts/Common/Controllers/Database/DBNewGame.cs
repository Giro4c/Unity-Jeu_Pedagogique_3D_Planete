using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBNewGame : MonoBehaviour
{
    public Button buttonStart;
    [SerializeField] public string plateforme = "";
    //[SerializeField] private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Application.streamingAssetsPath);
        //StartCoroutine(NewGamePhp());
        buttonStart.onClick.AddListener(delegate { StartCoroutine(NewGamePhp()); });
    }

    private IEnumerator NewGamePhp()
    {
        string url = "https://jeupedagogique.alwaysdata.net/views/addNewGame.php?plateforme=" + plateforme;
        Debug.Log(url);
        
        UnityWebRequest wwwNewGame = UnityWebRequest.Get(url);
        yield return wwwNewGame.SendWebRequest();
        if (wwwNewGame.error != null)
        {
            Debug.LogError(wwwNewGame.error);
            //text.text = wwwNewGame.error;
        }
        else
        {
            Debug.Log("Page New Game Loaded");
            Debug.Log(wwwNewGame.downloadHandler.text);
            //text.text = wwwNewGame.downloadHandler.text;

        }
        
    }
    
    
}
