using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetQuestion : MonoBehaviour
{

    public ShowQCM ShowQcm;
    public ShowInterac ShowInterac;
    public ShowVraiFaux ShowVraiFaux;

    public GameObject panelQcm;
    public GameObject panelInterac;
    public GameObject panelVraiFaux;

    public IEnumerator GetQuestion(int qid)
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
            // Hide all panels
            HideAllPanels();
            // Retrieve type of question
            string type = htmlParser.getHTMLContainerContent("p", null, "Type");
            if (type.Equals("QCM"))
            {
                panelQcm.SetActive(true);
                ShowQcm.showQuestion(htmlParser.GetHTML());
            }
            else if (type.Equals("QUESINTERAC"))
            {
                panelInterac.SetActive(true);
                ShowInterac.showQuestion(htmlParser.GetHTML());
            }
            else if (type.Equals("VRAIFAUX"))
            {
                panelVraiFaux.SetActive(true);
                ShowVraiFaux.showQuestion(htmlParser.GetHTML());
            }

        }
    }

    private void HideAllPanels()
    {
        panelVraiFaux.SetActive(false);
        panelQcm.SetActive(false);
        panelInterac.SetActive(false);
    }
    
}
