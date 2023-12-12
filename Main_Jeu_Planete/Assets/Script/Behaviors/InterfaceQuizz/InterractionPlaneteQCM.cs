using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterractionPlaneteQCM : MonoBehaviour
{
    public List<QuestionAndAnswerInterraction> QnA;
    public TextMeshProUGUI QuestionTxt;
    public CurrentMonth slider;
    public OrbitMotion position;

    private void Start()
    {
        generateQuestion();
    }
    private void Update()
    {
        position.orbitActive = false;
        slider.SliderDrag();
    }

    public void ActiveScript()
    {
        GetComponent<QcmVraiFaux>().enabled = true;
    }

    public void DesactiveScript()
    {
        GetComponent<QcmVraiFaux>().enabled = false;
    }

    private void Valeur()
    {  
        // Sélectionnez un élément de la liste (supposons que ce soit le premier élément)
        if (QnA.Count > 0)
        {
            QuestionAndAnswerInterraction selectedQuestion = QnA[0];
        }

    }

    
    public void Answer()
    {
        
        // Utilisez un index valide pour accéder à un élément spécifique de la liste
        int index = Random.Range(0, QnA.Count);
        
        // Accédez à la propriété AnswerValue de l'élément sélectionné
            QnA[index].AnswerValue = slider.textSlider.value;
        
        if (QnA[index].AnswerValue >= QnA[index].CorrectAnswer1 && QnA[index].AnswerValue <= QnA[index].CorrectAnswer2 )
        {
            Debug.Log("Bonne réponse");
        }
        else
        {
            Debug.Log("Mauvaise réponse");
        }
    }

    public void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            int currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[0].Question;
        }
        else
        {
            // Ajoutez une logique pour gérer la fin du quiz
            Debug.Log("Fin du quiz !");
        }
    }
}
