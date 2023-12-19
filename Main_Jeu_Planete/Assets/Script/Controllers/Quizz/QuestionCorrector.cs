using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class QuestionCorrector : MonoBehaviour
{

    private int qid;
    private bool correct = false;
    private DateTime startTime;
    private TimeSpan duration;
    
    public void Correct()
    {
        VerifyCorrect();
        ShowCorrection();
        StartCoroutine(AddQuestionAnswer());
    }

    public int GetQid()
    {
        return qid;
    }
    
    public bool IsCorrect()
    {
        return correct;
    }
    
    public void SetCorrect(bool val)
    {
        correct = val;
    }
    
    public DateTime GetStartTime()
    {
        return startTime;
    }
    
    public TimeSpan GetDuration()
    {
        return duration;
    }
    
    public void SetDuration(TimeSpan val)
    {
        duration = val;
    }

    public abstract void VerifyCorrect();
    public abstract void ShowCorrection();

    public IEnumerator AddQuestionAnswer()
    {
        string strVarURLGet = "";
        strVarURLGet = "qid=" + qid + "&duration=" + Math.Ceiling(duration.TotalSeconds) + "&correct=";
        if (correct)
        {
            strVarURLGet += "1";
        }
        else
        {
            strVarURLGet += "0";
        }
        string url = "jeupedagogique.alwaysdata.net/views/addQuestionAnswer.php?" + strVarURLGet;
        Debug.Log(url);
        
        UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
        yield return wwwInteract.SendWebRequest();
        if (wwwInteract.error != null)
        {
            Debug.LogError(wwwInteract.error);
        }
        else // Pas d'erreur, la page est chargée
        {
            Debug.Log(wwwInteract.downloadHandler.text);
        }
        yield return null;
    }

    public void NewCorrector(int qidNew)
    {
        qid = qidNew;
        correct = false;
        startTime = DateTime.Now;
        duration = TimeSpan.Zero;
        
    }

}
