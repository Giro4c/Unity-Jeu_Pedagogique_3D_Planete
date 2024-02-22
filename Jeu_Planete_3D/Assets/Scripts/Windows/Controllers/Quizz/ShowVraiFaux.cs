using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowVraiFaux : MonoBehaviour
{
    public TextMeshProUGUI QuestionTxt;
    public Orbit orbit;
    public RotationCycle rotation;
    public CorrectorQCU corrector;
    public RotationOrOrbitDetector manager;
    
public void showQuestion(string jsonData)
    {
        QuestionDataVraiFaux questionDataVraiFaux = JsonUtility.FromJson<QuestionDataVraiFaux>(jsonData);

        // Manage possible interactions
        manager.ActivateAll();
        corrector.ResetChoiceSelection();

        // Get question ID and Reset Corrector
        corrector.NewCorrector(questionDataVraiFaux.Num_Ques);

        // Get question text
        QuestionTxt.text = questionDataVraiFaux.Enoncer;

        // Get correct answer
        corrector.correctAnswer = questionDataVraiFaux.BonneRep;

        // Deactivation OrbitMotion and OrbitDrag
        manager.DeactivateDetector();
        manager.DeactivateAllScriptsOrbit();
        // Change Orbit
        if (questionDataVraiFaux.Valeur_orbit != 0f)
        {
            orbit.orbitProgress = questionDataVraiFaux.Valeur_orbit;
            orbit.SetOrbitingObjectPosition();
        }

        // Deactivation RotationAuto and RotationDrag
        manager.DeactivateDetector();
        manager.DeactivateAllScriptsRotation();
        // Change Rotation
        if (questionDataVraiFaux.Valeur_rotation != 0f)
        {
            rotation.rotateProgress = questionDataVraiFaux.Valeur_rotation;
            rotation.SetRotation();
        }
    }
}

[System.Serializable]
public class QuestionDataVraiFaux
{
    public int Num_Ques;
    public string Enoncer;
    public string BonneRep;
    public float Valeur_orbit;
    public float Valeur_rotation;
}