using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QcmVraiFaux : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;
    public Answer Vraie;
    public Answer Faux;
    private Color originalColor;
    private bool validationMode = false;
    [SerializeField] GameObject panelToShow;
    [SerializeField] GameObject panelToHide;

    private void Start()
    {
        generateQuestion();
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
        if (QnA.Count != 0)
        {
            // Activer le mode validation
            validationMode = true;

            // Obtenir la réponse correcte
            int correctAnswerIndex = QnA[currentQuestion].CorrectAnswer - 1;

            // Mettre en vert la réponse correcte
            Image correctButtonImage = options[correctAnswerIndex].GetComponent<Answer>().myButton.GetComponent<Image>();
            correctButtonImage.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);

            // Désactiver les boutons de réponse
            foreach (var option in options)
            {
                option.GetComponent<Button>().interactable = false;
            }

            // Ajouter une logique pour afficher la nouvelle question
            // Par exemple, vous pourriez utiliser une coroutine pour afficher la nouvelle question après quelques secondes
            StartCoroutine(ShowNextQuestion());
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

    IEnumerator ShowNextQuestion()
    {
        yield return new WaitForSeconds(3f); // Attendre 3 secondes avant de montrer la nouvelle question

        // Réinitialiser les couleurs des boutons de réponse
        foreach (var option in options)
        {
            Image buttonImage = option.GetComponent<Answer>().myButton.GetComponent<Image>();
            originalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            buttonImage.color = originalColor;
            option.GetComponent<Button>().interactable = true;
        }

        // Passer à la prochaine question
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

        // Désactiver le mode validation
        validationMode = false;
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
    
}
