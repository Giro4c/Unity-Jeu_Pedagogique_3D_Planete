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
    public float orbitMargin = 0;
    public float rotationMargin = 0;
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
            Debug.Log("Upper Bound orbit : " + (correctOrbit + orbitMargin));
            Debug.Log("Lower Bound orbit : " + (correctOrbit - orbitMargin));
            Debug.Log("Orbit actuel : " + orbit.orbitProgress);
            if (correctOrbit + orbitMargin > 1 || correctOrbit - orbitMargin < 0)
            {
                Debug.Log("Case OU pour intervalle Orbit");
                Debug.Log("" + (correctOrbit - orbitMargin)%1f + " < orbit || orbit < " + (correctOrbit + orbitMargin)%1f);
                orbitCorrect = orbit.orbitProgress < (correctOrbit + orbitMargin)%1f ||
                               orbit.orbitProgress > (correctOrbit - orbitMargin)%1f;
            }
            else
            {
                Debug.Log("Case ET pour intervalle Orbit");
                Debug.Log("" + (correctOrbit - orbitMargin) + " < orbit && orbit < " + (correctOrbit + orbitMargin)%1f);
                orbitCorrect = orbit.orbitProgress < (correctOrbit + orbitMargin) &&
                               orbit.orbitProgress > (correctOrbit - orbitMargin);
            }
            
        }
        Debug.Log("Orbit correcte ? " + orbitCorrect);
        
        // Vérifier si dans cas correctOrbit proche de 0 si intervalle est bon
        bool rotaCorrect = true;
        if (verifyRotation)
        {
            // Special case, require specific time (sun progress) but no particular orbit, must take current orbit into account
            if (!verifyOrbit)
            {
                Debug.Log("Special case rotation : only time matters");
                // Recalculate correct rotation based on actual orbit and correct value for orbit progress 0 (aka correct sun progress).
                correctRotation += orbit.orbitProgress;
                correctRotation %= 1f;
                Debug.Log("Special case correct rotation : rotation=" + correctRotation +"  --  orbit=" + orbit.orbitProgress);
            }
            Debug.Log("Upper Bound rotation : " + (correctRotation + rotationMargin));
            Debug.Log("Lower Bound rotation : " + (correctRotation - rotationMargin));
            Debug.Log("Rotation actuelle : " + rotation.rotateProgress);
            if (correctRotation + rotationMargin > 1 || correctRotation - rotationMargin < 0)
            {
                Debug.Log("Case OU pour intervalle Rotation");
                Debug.Log("" + (correctRotation - rotationMargin)%1f + " < rotation || rotation < " + (correctRotation + rotationMargin)%1f);
                rotaCorrect = rotation.rotateProgress < (correctRotation + rotationMargin)%1f ||
                              rotation.rotateProgress > (correctRotation - rotationMargin)%1f;
            }
            else
            {
                Debug.Log("Case ET pour intervalle Rotation");
                Debug.Log("" + (correctRotation - rotationMargin) + " < rotation && rotation < " + (correctRotation + rotationMargin)%1f);
                rotaCorrect = rotation.rotateProgress < (correctRotation + rotationMargin) &&
                              rotation.rotateProgress > (correctRotation - rotationMargin);
            }
        }
        Debug.Log("Rotation correcte ? " + rotaCorrect);
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
