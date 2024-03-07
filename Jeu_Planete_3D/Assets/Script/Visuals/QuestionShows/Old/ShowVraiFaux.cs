/*
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowVraiFaux_Old : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    public Orbit orbit;
    public RotationCycle rotation;
    public CorrectorQCU corrector;
    public RotationOrOrbitDetector manager;
    
    public void showQuestion(string html)
    {
        // Manage possible interactions
        manager.ActivateAll();
        corrector.ResetChoiceSelection();
        
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
        
        // Change Culture info for String to float conversions
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        // Get Val Orbit
        valExtrater = parser.getHTMLContainerContent("p", null, "Valeur_orbit");
        Debug.Log("Valeur extraite orbit -" + valExtrater + "-");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            // Deactivation OrbitMotion and OrbitDrag
            manager.DeactivateDetector();
            manager.DeactivateAllScriptsOrbit();
            // Change Orbit
            Debug.Log("Fixed orbit : " + valExtrater);
            orbit.orbitProgress = float.Parse(valExtrater, NumberStyles.Any, ci);
            Debug.Log("New orbit : " + orbit.orbitProgress);
            orbit.SetOrbitingObjectPosition();
            
        }
        
        // Get Val Rotation
        valExtrater = parser.getHTMLContainerContent("p", null, "Valeur_rotation");
        Debug.Log("Valeur extraite rota -" + valExtrater + "-");
        if (valExtrater != null && !valExtrater.Equals(""))
        {
            // Deactivation RotationAuto and RotationDrag
            manager.DeactivateDetector();
            manager.DeactivateAllScriptsRotation();
            // Change Rotation
            Debug.Log("Fixed rotation : " + valExtrater);
            rotation.rotateProgress = float.Parse(valExtrater, NumberStyles.Any, ci);
            rotation.SetRotation();

        }
        
    }
    
}
*/
