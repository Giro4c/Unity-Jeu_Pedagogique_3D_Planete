using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetQuestion : MonoBehaviour
{

    public ShowQCM ShowQcm;
    public ShowInterac ShowInterac;
    public ShowVraiFaux ShowVraiFaux;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator GetRandomQuestions(int qid)
    {
        string strVarURLGet = "";
        strVarURLGet = "qid=" + qid;
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
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            // Init du parser
            StringHTMLParser htmlParser = new StringHTMLParser(wwwInteract.downloadHandler.text);
            string type = htmlParser.getHTMLContainerContent("p", null, "Type");
            if (type.Equals("QCM"))
            {
                
            }
            else if (type.Equals("QUESINTERAC"))
            {
                
            }
            else if (type.Equals("VRAIFAUX"))
            {
                
            }

        }
    }
}
