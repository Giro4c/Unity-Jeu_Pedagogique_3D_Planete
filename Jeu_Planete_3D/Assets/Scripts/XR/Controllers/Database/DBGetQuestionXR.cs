using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetQuestionXR : MonoBehaviour
{

    public ShowQCMXR ShowQcm;
    public ShowInteracXR ShowInterac;
    public ShowVraiFauxXR ShowVraiFaux;

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
        // Created var to store the html content shower will have to parse through
        string webPage = "";
        // Checks if error
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
            /* In case of emergency if its impossible to connect to the host since the start,
             read the expected html page content for a known question and store the value for later used*/
            TextAsset questionTextAsset = Resources.Load<TextAsset>("WebEmergency/Questions/" + qid);
            webPage = questionTextAsset.text;
        }
        else // No error, Web Page is loaded
        {
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            webPage = wwwInteract.downloadHandler.text;
        }

        // Init du parser
        StringHTMLParser htmlParser = new StringHTMLParser(webPage);
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

    public void HideAllPanels()
    {
        panelVraiFaux.SetActive(false);
        panelQcm.SetActive(false);
        panelInterac.SetActive(false);
    }
    
}
