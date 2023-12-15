using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetQuestion : MonoBehaviour
{
    public ListQuestions questions;
    public DBGetRandomQuestions id;
    public int qid;
    public int [] idQuestion;

    // Start is called before the first frame update
    void Start()
    {
        print("Starting coroutine for calling web page");
        StartCoroutine(GetQuestions());
    }

     public IEnumerator GetQuestions()
    {
        id.GetRandomQuestions();
        idQuestion = questions.questionsIDs;
        string strVarURLGet = "";
        strVarURLGet = "qid="+qid;
        string url = "jeupedagogique.alwaysdata.net/views/question.php?" + strVarURLGet;
        Debug.Log(url);
        
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
        }
        else // Pas d'erreur, la page est chargée
        {
            string test;
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            // Init du parser
            StringHTMLParser htmlParser = new StringHTMLParser(wwwInteract.downloadHandler.text);
            Debug.Log(qid);
            questions.questionString=wwwInteract.downloadHandler.text;
            test = wwwInteract.downloadHandler.text;

        }
    }
}