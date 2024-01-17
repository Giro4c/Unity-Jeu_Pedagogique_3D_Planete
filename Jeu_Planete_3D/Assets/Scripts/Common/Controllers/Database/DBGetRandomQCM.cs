using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetRandomQCM : MonoBehaviour
{
    public ListQuestions questions;
    public int nbQCM = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        print("Starting coroutine for calling web page");
        StartCoroutine(GetRandomQCM());
    }
    
    public IEnumerator GetRandomQCM()
    {
        string strVarURLGet = "";
        strVarURLGet = "qcm=" + nbQCM;
        string url = "jeupedagogique.alwaysdata.net/views/randomQuestions.php?" + strVarURLGet;
        Debug.Log(url);
        
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
        }
        else // Pas d'erreur, la page est chargée
        {
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            // Init du parser
            StringHTMLParser htmlParser = new StringHTMLParser(wwwInteract.downloadHandler.text);
            int totCount = nbQCM;
            string extratedVal;
            int[] list = new int[totCount];
            print("Parsing html source");
            for (int count = 0; count < totCount; ++count)
            {
                extratedVal = htmlParser.getHTMLContainerContent("li", null, count.ToString());
                print(extratedVal);
                list[count] = int.Parse(extratedVal);
                
            }
            
            questions.questionsIDsMult = list;

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}