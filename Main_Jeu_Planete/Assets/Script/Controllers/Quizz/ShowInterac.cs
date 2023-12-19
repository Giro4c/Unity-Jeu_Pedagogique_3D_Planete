using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInterac : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    private Color originalColor;
    public CorrectorInterac corrector;
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
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_orbit");
        if (valExtrater != null && !valExtrater.Equals("NULL"))
        {
            corrector.correctOrbit = float.Parse(valExtrater);
            corrector.verifyOrbit = true;
        }
        else
        {
            corrector.verifyOrbit = false;
        }
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_rotation");
        if (valExtrater != null && !valExtrater.Equals("NULL"))
        {
            corrector.correctRotation = float.Parse(valExtrater);
            corrector.verifyRotation = true;
        }
        else
        {
            corrector.verifyRotation = false;
        }
        
    }
    
}
