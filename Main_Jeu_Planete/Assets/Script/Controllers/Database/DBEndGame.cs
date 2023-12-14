using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBEndGame : MonoBehaviour
{
    public Button buttonEndGame;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonEndGame.onClick.AddListener(delegate { StartCoroutine(EndGamePhp()); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EndGamePhp()
    {
        string url = "jeupedagogique.alwaysdata.net/views/endGame.php";
        Debug.Log(url);
        
        UnityWebRequest wwwEndGame = UnityWebRequest.Get(url);
        yield return wwwEndGame.SendWebRequest();
        if (wwwEndGame.error != null)
        {
            Debug.LogError(wwwEndGame.error);
        }
        
    }
    
}
