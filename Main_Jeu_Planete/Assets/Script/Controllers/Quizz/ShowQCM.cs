using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowQCM : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    private Color originalColor;
    public TextMeshProUGUI Rep1;
    public TextMeshProUGUI Rep2;
    public TextMeshProUGUI Rep3;
    public TextMeshProUGUI Rep4;
    public string correctAnswer;
    public RotationOrOrbitDetector manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void showQuestion(string html)
    {
        manager.ActivateDetector();
        StringHTMLParser parser = new StringHTMLParser(html);
        QuestionTxt.text = parser.getHTMLContainerContent("p", null, "Enoncer");
        string valExtrater = "";
        
        // Get correct answer
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRep");
        correctAnswer = valExtrater;
        
        // Get Possible Answers
        Rep1.text = parser.getHTMLContainerContent("p", null, "Rep1");
        Rep2.text = parser.getHTMLContainerContent("p", null, "Rep2");
        Rep3.text = parser.getHTMLContainerContent("p", null, "Rep3");
        Rep4.text = parser.getHTMLContainerContent("p", null, "Rep4");
        
    }
    
}
