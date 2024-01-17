using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetRandomQuestions : MonoBehaviour
{
    public ListQuestions_Old questions;
    public int nbVF = 0;
    public int nbQCM = 0;
    public int nbInterac = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        print("Starting coroutine for calling web page");
        StartCoroutine(GetRandomQuestions());
    }
    
    private IEnumerator GetRandomQuestions()
    {
        string strVarURLGet = "";
        strVarURLGet = "qcm=" + nbQCM + "&interaction=" + nbInterac + "&vraifaux=" + nbVF;
        string url = "jeupedagogique.alwaysdata.net/views/randomQuestions.php?" + strVarURLGet;
        Debug.Log(url);
        
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        
        yield return wwwInteract.SendWebRequest();
        
        string webPage = "";
        // Checks if error
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
            /* In case of emergency if its impossible to connect to the host since the start,
             read the expected html page content for a known question and store the value for later used*/
            TextAsset questionTextAsset = Resources.Load<TextAsset>("WebEmergency/initQuizz");
            webPage = questionTextAsset.text;
        }
        else // No error, Web Page is loaded
        {
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            webPage = wwwInteract.downloadHandler.text;
        }
        
        StringHTMLParser htmlParser = new StringHTMLParser(webPage);
        int totCount = nbQCM + nbInterac + nbVF;
        string extratedVal;
        int[] list = new int[totCount];
        print("Parsing html source");
        for (int count = 0; count < totCount; ++count)
        {
            extratedVal = htmlParser.getHTMLContainerContent("li", null, count.ToString());
            print(extratedVal);
            list[count] = int.Parse(extratedVal);
        }

        questions.questionsIDs = list;
        
    }
    
}
