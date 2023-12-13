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


    private void Start()
    {
        generateQuestion();
    }
    private void Update()
    {
        if (slider.textSlider)
        {
            position.orbitActive = true;
            slider.SliderAuto();
            orbit.orbitProgress = slider.textSlider.value;
            orbit.SetOrbitingObjectPosition();
        }
       
            position.orbitActive = false;
            slider.SliderDrag();
            
        
    }

    public void suivant()
    {  
        // Sélectionnez un élément de la liste (supposons que ce soit le premier élément)
        if (QnA.Count != 0)
        {
            generateQuestion();
        }
        else
        {
            Debug.Log("Fin du quizz");
        }

    }

    
    private void Answer()
    {
        
        // Utilisez un index valide pour accéder à un élément spécifique de la liste
        int index = Random.Range(0, QnA.Count);
        
        // Accédez à la propriété AnswerValue de l'élément sélectionné
            QnA[index].AnswerValue = slider.textSlider.value;
    
        if (QnA[index].AnswerValue >= QnA[index].CorrectAnswer1 && QnA[index].AnswerValue <= QnA[index].CorrectAnswer2 )
        {
            CorrectAnswer.text = QnA[index].CorrectAnswerText;
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
            QuestionTxt.text = QnA[currentQuestion].Question;
            Answer();
        }
        else
        {
            // Ajoutez une logique pour gérer la fin du quiz
            Debug.Log("Fin du quiz !");
        }
    }
}
