using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzXR : MonoBehaviour
{
    public ListQuestions_Old listQuestions;
    private int indexQuestionCurrent = 0;
    public DBGetQuestionXR getterQuestions;
    public GameObject startPanel;
    public GameObject endPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
    }

    public void StartQuiz()
    {
        // Get and show first question
        startPanel.SetActive(false);
        StartCoroutine(getterQuestions.GetQuestion(GetCurrentQuestionID()));
    }

    public int GetCurrentQuestionID()
    {
        if (indexQuestionCurrent >= listQuestions.questionsIDs.Length || indexQuestionCurrent < 0) return -1;
        return listQuestions.questionsIDs[indexQuestionCurrent];
    }

    public void Next()
    {
        ++indexQuestionCurrent;
        if (indexQuestionCurrent < listQuestions.questionsIDs.Length)
        {
            StartCoroutine(getterQuestions.GetQuestion(GetCurrentQuestionID()));
        }
        else
        {
            End();
        }
    }

    public void End()
    {
        getterQuestions.HideAllPanels();
        endPanel.SetActive(true);
    }
    
}
