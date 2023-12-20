using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowVraiFaux : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    private Color originalColor;
    public bool trueIsCorrectAnswer;
    public Orbit orbit;
    public RotationOrOrbitDetector manager;
    public RotationCycle rotation;
    
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
        StringHTMLParser parser = new StringHTMLParser(html);
        QuestionTxt.text = parser.getHTMLContainerContent("p", null, "Enoncer");
        string valExtrater = "";
        
        // Get correct answer
        valExtrater = parser.getHTMLContainerContent("p", null, "BonneRep");
        if (valExtrater.Equals("VRAI"))
        {
            trueIsCorrectAnswer = true;
        }
        else
        {
            trueIsCorrectAnswer = false;
        }
        
        // Change Culture info for String to float conversions
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        // Get Val Orbit
        valExtrater = parser.getHTMLContainerContent("p", null, "Valeur_orbit");
        if (valExtrater != null)
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
        if (valExtrater != null)
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
