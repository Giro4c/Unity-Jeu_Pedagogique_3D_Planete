using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class ShowQCM : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    private Color originalColor;
    public TextMeshProUGUI Rep1;
    public TextMeshProUGUI Rep2;
    public TextMeshProUGUI Rep3;
    public TextMeshProUGUI Rep4;
    public CorrectorQCU corrector;
    public RotationOrOrbitDetector manager;

    public void showQuestion(string json)
    { 
        
        QuestionDataQCM questionDataQCM = JsonUtility.FromJson<QuestionDataQCM>(json);

        // Manage possible interactions
        manager.ActivateAll();
        corrector.ResetChoiceSelection();
        
        // Get question ID and Reset Corrector
        corrector.NewCorrector(questionDataQCM.Num_Ques);
        
        // Get question text
        QuestionTxt.text = questionDataQCM.Enoncer;
        
        // Get correct answer
        corrector.correctAnswer = questionDataQCM.BonneRep;
        
        // Get Possible Answers
        Rep1.text = questionDataQCM.Rep1;
        Rep2.text = questionDataQCM.Rep2;
        Rep3.text = questionDataQCM.Rep3;
        Rep4.text = questionDataQCM.Rep4;
        
    }
    
}

[System.Serializable]
public class QuestionDataQCM
{
    public int Num_Ques; // ID de la question
    public string Enoncer; // Texte de la question
    public string BonneRep; // Bonne réponse
    public string Rep1; // Réponse 1
    public string Rep2; // Réponse 2
    public string Rep3; // Réponse 3
    public string Rep4; // Réponse 4
}