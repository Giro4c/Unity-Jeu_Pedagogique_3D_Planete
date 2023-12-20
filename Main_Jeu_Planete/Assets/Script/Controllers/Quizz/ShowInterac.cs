using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        // Manage possible interactions
        manager.ActivateDetector();
        manager.DeactivateAutoMotion();
        
        StringHTMLParser parser = new StringHTMLParser(html);
        string valExtrater = "";
        
        // Get question ID
        valExtrater = parser.getHTMLContainerContent("p", null, "Num_Ques");
        
        // Get question text
        QuestionTxt.text = parser.getHTMLContainerContent("p", null, "Enoncer");
        
        // Change Culture info for String to float conversions
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        // Get correct answer
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_orbit");
        if (valExtrater != null && !valExtrater.Equals("NULL"))
        {
            corrector.correctOrbit = float.Parse(valExtrater, NumberStyles.Any, ci);
            corrector.verifyOrbit = true;
        }
        else
        {
            corrector.verifyOrbit = false;
        }
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_rotation");
        if (valExtrater != null && !valExtrater.Equals("NULL"))
        {
            corrector.correctRotation = float.Parse(valExtrater, NumberStyles.Any, ci);
            corrector.verifyRotation = true;
        }
        else
        {
            corrector.verifyRotation = false;
        }
        
    }
    
}
