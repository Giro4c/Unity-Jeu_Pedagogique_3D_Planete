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

    public void showQuestion(string jsonString)
    {
        // Deserialize JSON string into QuestionDataInterac object
        QuestionDataInterac questionDataInterac = JsonUtility.FromJson<QuestionDataInterac>(jsonString);

        // Manage possible 
        manager.ActivateDetector();
        manager.DeactivateAutoMotion();

        // Get question ID and Reset Corrector
        corrector.NewCorrector(questionDataInterac.numQuestion);

        // Get question text
        QuestionTxt.text = questionDataInterac.enoncer;

        // Set correct answer for orbit
        if (!string.IsNullOrEmpty(questionDataInterac.bonneRepValeur_orbit))
        {
            corrector.correctOrbit = float.Parse(questionDataInterac.bonneRepValeur_orbit);
            corrector.correctOrbit %= 1f;
            corrector.verifyOrbit = true;
        }
        else
        {
            corrector.verifyOrbit = false;
        }

        // Set correct answer for rotation
        if (!string.IsNullOrEmpty(questionDataInterac.bonneRepValeur_rotation))
        {
            corrector.correctRotation = float.Parse(questionDataInterac.bonneRepValeur_rotation);
            corrector.correctRotation %= 1f;
            corrector.verifyRotation = true;
        }
        else
        {
            corrector.verifyRotation = false;
        }

        // Get margins
        if (!string.IsNullOrEmpty(questionDataInterac.marge_Orbit))
        {
            corrector.orbitMargin = float.Parse(questionDataInterac.marge_Orbit);
            if (corrector.orbitMargin > 0.5f)
            {
                corrector.orbitMargin %= 0.5f;
            }
        }
        if (!string.IsNullOrEmpty(questionDataInterac.marge_Rotation))
        {
            corrector.rotationMargin = float.Parse(questionDataInterac.marge_Rotation);
            if (corrector.rotationMargin > 0.5f)
            {
                corrector.rotationMargin %= 0.5f;
            }
        }
    }
}

[System.Serializable]
public class QuestionDataInterac
{
    public int numQuestion;
    public string enoncer;
    public string bonneRepValeur_orbit;
    public string bonneRepValeur_rotation;
    public string marge_Orbit;
    public string marge_Rotation;
}