using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowInterac : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    public CorrectorInterac corrector;
    public RotationOrOrbitDetector manager;
    
    public void showQuestion(string html)
    {
        // Manage possible 
        manager.ActivateDetector();
        manager.DeactivateAutoMotion();
        
        StringHTMLParser parser = new StringHTMLParser(html);
        string valExtrater = "";
        
        // Get question ID and Reset Corrector
        valExtrater = parser.getHTMLContainerContent("p", null, "Num_Ques");
        corrector.NewCorrector(int.Parse(valExtrater));
        
        // Get question text
        QuestionTxt.text = parser.getHTMLContainerContent("p", null, "Enoncer");
        
        // Change Culture info for String to float conversions
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        // Get correct answer
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_orbit");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            corrector.correctOrbit = float.Parse(valExtrater, NumberStyles.Any, ci);
            corrector.correctOrbit %= 1f;
            corrector.verifyOrbit = true;
        }
        else
        {
            corrector.verifyOrbit = false;
        }
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRepValeur_rotation");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            corrector.correctRotation = float.Parse(valExtrater, NumberStyles.Any, ci);
            corrector.correctRotation %= 1f;
            corrector.verifyRotation = true;
        }
        else
        {
            corrector.verifyRotation = false;
        }
        
        // Get margins
        valExtrater = parser.getHTMLContainerContent("p", null, "Marge_Orbit");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            corrector.orbitMargin = float.Parse(valExtrater, NumberStyles.Any, ci);
            if (corrector.orbitMargin > 0.5f)
            {
                corrector.orbitMargin %= 0.5f;
            }
        }
        valExtrater = parser.getHTMLContainerContent("p", null, "Marge_Rotation");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            corrector.rotationMargin = float.Parse(valExtrater, NumberStyles.Any, ci);
            if (corrector.rotationMargin > 0.5f)
            {
                corrector.rotationMargin %= 0.5f;
            }
        }
        
        
    }
    
}
