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
    public ListQuestions showQuestion;
    public int element;
    public int currentQuestion;
    [SerializeField] GameObject panelToShow;
    [SerializeField] GameObject panelToHide;

    private void Start()
    {
        GenerateQuestion();
        element = 10;
    }

    private void Update()
    {
        if (slider.textSlider)
        {
            orbit.orbitProgress = slider.textSlider.value;
            orbit.SetOrbitingObjectPosition();
        }
        position.orbitActive = false;
        slider.SliderDrag();
    }

    public void Suivant()
    {
        if (element != 0)
        {
            GenerateQuestion();
            element -= 1;
        }
        else
        {
            HandleEndOfQuiz();
        }
    }

    public void Answer()
    {
        QnA[currentQuestion].AnswerValue = slider.textSlider.value;

        if (IsAnswerCorrect())
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

    private void GenerateQuestion()
    {
        currentQuestion = Random.Range(0, showQuestion.questionStringInter.Length);
        QuestionTxt.text = showQuestion.questionStringInter[currentQuestion];
        //Debug.Log(showQuestion.questionStringInter.Length)
        Answer();
        Correct.SetActive(false);
    }

    private bool IsAnswerCorrect()
    {
        return QnA[currentQuestion].AnswerValue >= QnA[currentQuestion].CorrectAnswer1 &&
               QnA[currentQuestion].AnswerValue <= QnA[currentQuestion].CorrectAnswer2;
    }

    private void HandleEndOfQuiz()
    {
        if (panelToHide != null)
        {
            panelToHide.SetActive(false);
        }
        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
        }
        Debug.Log("Fin du quizz");
    }
}
