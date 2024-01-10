using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR;

public class DBNewGame : MonoBehaviour
{
    public Button buttonStart;
    [SerializeField] public string plateforme = "Windows";
    
    // Start is called before the first frame update
    void Start()
    {
        buttonStart.onClick.AddListener(delegate { StartCoroutine(NewGamePhp()); });

        // Vérifier si la réalité virtuelle est activée
        if (XRSettings.enabled)
        {
            plateforme = "XR";
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator NewGamePhp()
    {
        string url = "jeupedagogique.alwaysdata.net/views/addNewGame.php?plateforme=" + plateforme;
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
