using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        string strVarURLGet = "qid=" + qid;
        string url = "jeupedagogique.alwaysdata.net/views/question.php?" + strVarURLGet;
        Debug.Log(url);

        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
 
        // Checks if error
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
            /* In case of emergency if its impossible to connect to the host since the start,
             read the expected html page content for a known question and store the value for later used*/
            TextAsset questionTextAsset = Resources.Load<TextAsset>("WebEmergency/Questions/" + qid);
            jsonString = questionTextAsset.text;
        }
        else // No error, Web Page is loaded
        {
            Debug.Log(wwwInteract.downloadHandler.text); // le texte de la page
            string jsonString = wwwInteract.downloadHandler.text;
            QuestionData questionData = JsonUtility.FromJson<QuestionData>(jsonString);
        }

        // Hide all panels
        HideAllPanels();
        // Retrieve type of question
        string type = questionData.type;
        if (type.Equals("QCM"))
        {
            panelQcm.SetActive(true);
            ShowQcm.showQuestion(questionData.html);
        }
        else if (type.Equals("QUESINTERAC"))
        {
            panelInterac.SetActive(true);
            ShowInterac.showQuestion(questionData.html);
        }
        else if (type.Equals("VRAIFAUX"))
        {
            panelVraiFaux.SetActive(true);
            ShowVraiFaux.showQuestion(questionData.html);
        }

    }

    public void HideAllPanels()
    {
        panelVraiFaux.SetActive(false);
        panelQcm.SetActive(false);
        panelInterac.SetActive(false);
    }
    
}

[System.Serializable]
public class QuestionData
{
    public string type;
    public string html;
}