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

    public void showQuestion(string html)
    {
        // Manage possible interactions
        manager.ActivateAll();
        corrector.ResetChoiceSelection();

        //debug.text = html;
        StringHTMLParser parser = new StringHTMLParser(html);
        string valExtrater = "";
        
        // Get question ID and Reset Corrector
        valExtrater = parser.getHTMLContainerContent("p", null, "Num_Ques");
        corrector.NewCorrector(int.Parse(valExtrater));
        
        
        // Get question text
        QuestionTxt.text = parser.getHTMLContainerContent("p", null, "Enoncer");
        
        // Get correct answer
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRep");
        corrector.correctAnswer = valExtrater;
        
        // Get Possible Answers
        Rep1.text = parser.getHTMLContainerContent("p", null, "Rep1");
        Rep2.text = parser.getHTMLContainerContent("p", null, "Rep2");
        Rep3.text = parser.getHTMLContainerContent("p", null, "Rep3");
        Rep4.text = parser.getHTMLContainerContent("p", null, "Rep4");
        
    }
    
}
