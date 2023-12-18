using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QcmVraiFaux : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int elements;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;
    public ListQuestions question;
    public Answer Vraie;
    public Answer Faux;
    private Color originalColor;
    public  ListQuestions showQuestion;
    [SerializeField] GameObject panelToShow;
    [SerializeField] GameObject panelToHide;
    

    private void Start()
    {
        generateQuestion();
        elements = 10;
    }

    public void ActiveScript()
    {
        GetComponent<QcmVraiFaux>().enabled = true;
        
    }

    public void DesactiveScript()
    {
        GetComponent<QcmVraiFaux>().enabled = false;
    }

    public void correct()
    {
        if (elements!= 0)
        {
            generateQuestion();
            elements-=1;
            Debug.Log(elements);
        }
        else
        {
            // Ajoutez une logique pour gérer la fin du quiz
            if (panelToHide != null)
            {
                // Désactivez le panneau actuel.
                panelToHide.SetActive(false);
            }
            if (panelToShow != null)
            {
                // Activez le nouveau panneau.
                panelToShow.SetActive(true);
            }
                Debug.Log("Fin du quiz !");
        }
          
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }
    public void generateQuestion()
    {
        //currentQuestion = Random.Range(0, QnA.Count);
        //QuestionTxt.text = QnA[currentQuestion].Question; 
        //question.GetQuestions();
        QuestionTxt.text = question.questionString;
        SetAnswers();
        Image buttonImageV = Vraie.myButton.GetComponent<Image>();
        Image buttonImageF = Faux.myButton.GetComponent<Image>();
        originalColor = new Color(1.0f,1.0f,1.0f,1.0f);
        buttonImageV.color = originalColor;
        buttonImageF.color = originalColor;
    }
}
