using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionPlaneteQCM : MonoBehaviour
{
    public List<QuestionAndAnswerInterraction> QnA;
    public TextMeshProUGUI QuestionTxt;
    public CurrentMonth slider;
    public TextMeshProUGUI CorrectAnswer;
    public Orbit orbit;
    public OrbitMotion position;
    public GameObject Correct;
    private int element;
    private int currentQuestion;


    private void Start()
    {
        generateQuestion();
        element = QnA.Count;
    }
    private void Update()
    {
        if (slider.textSlider)
        {
            //position.orbitActive = true;
            orbit.orbitProgress = slider.textSlider.value;
            orbit.SetOrbitingObjectPosition();
        }
            position.orbitActive = false;
            slider.SliderDrag();
    }


    public void suivant()
    {  
        // Sélectionnez un élément de la liste (tant que la liste ne vaut pas 0)
        if (element!= 0)
        {
            generateQuestion();
            element-=1;
        }
        else
        {
            Debug.Log("Fin du quizz");
        }

    }

    
    public void Answer()
    {
    
        // Accédez à la propriété AnswerValue de l'élément sélectionné
            QnA[currentQuestion].AnswerValue = slider.textSlider.value;
    
        if (QnA[currentQuestion].AnswerValue >= QnA[currentQuestion].CorrectAnswer1 && QnA[currentQuestion].AnswerValue <= QnA[currentQuestion].CorrectAnswer2 )
        {
            CorrectAnswer.text = QnA[currentQuestion].CorrectAnswerText;
            Correct.SetActive(true);
            Debug.Log("Bonne réponse");
        }
        else
        {
            CorrectAnswer.text = QnA[currentQuestion].CorrectAnswerText;
            Correct.SetActive(true);
            Debug.Log("Mauvaise réponse");
        }
    }

    private void generateQuestion()
    {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            Answer();
            Debug.Log(QnA.Count);
            Correct.SetActive(false);
            
    }
}
