using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CorrectorInterac : QuestionCorrector
{
    // For Verifications
    public float correctOrbit = 0;
    public float correctRotation = 0;
    public bool verifyOrbit = false;
    public bool verifyRotation = false;
    private float orbitMargin = (1f / 24f);
    private float rotationMargin = (1f / 24f);
    // For answer and show Correction
    public Orbit orbit;
    public RotationCycle rotation;
    // For showing correction
    public TextMeshProUGUI correctionText;
    public RotationOrOrbitDetector manager;
    
    public override void VerifyCorrect()
    {
        // Calculate the duration of the question
        DateTime endTime = DateTime.Now;
        SetDuration(endTime - GetStartTime());
        
        // Vérifier si dans cas correctOrbit proche de 0 si intervalle est bon
        bool orbitCorrect = true;
        if (verifyOrbit)
        {
            orbitCorrect = orbit.orbitProgress < (correctOrbit + orbitMargin) &&
                           orbit.orbitProgress > (correctOrbit - orbitMargin);
        }
        
        // Vérifier si dans cas correctOrbit proche de 0 si intervalle est bon
        bool rotaCorrect = true;
        if (verifyRotation)
        {
            rotaCorrect = rotation.rotateProgress < (correctRotation + rotationMargin) &&
                          rotation.rotateProgress > (correctRotation - rotationMargin);
        }
        // Change value of correct
        SetCorrect(orbitCorrect && rotaCorrect);
        
    }
    
    public override void ShowCorrection()
    {
        // Manage possible interactions after correction
        manager.DeactivateAll();
        
        // Show correction
        if (IsCorrect())
        {
            correctionText.text = "Bonne réponse";
        }
        else
        {
            correctionText.text = "Mauvaise réponse";
            // Show correct orbit
            if (verifyOrbit)
            {
                orbit.orbitProgress = correctOrbit;
                orbit.SetOrbitingObjectPosition();
            }
            // Show correct rotation
            if (verifyRotation)
            {
                rotation.rotateProgress = correctRotation;
                rotation.SetRotation();
            }
            
        }
    }
    
}
