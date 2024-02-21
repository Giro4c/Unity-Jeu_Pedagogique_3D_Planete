using TMPro;
using UnityEngine;

public class CorrectorManipulation : QuestionCorrector<QuestionManipulation>
{
    
    public Cycle orbit { get; protected set; }
    public Cycle rotation { get; protected set; }
    public TextMeshProUGUI correctionText { get; protected set; }

    public CorrectorManipulation(QuestionManipulation question, Cycle orbit, Cycle rotation, TextMeshProUGUI correctionText) : base(question)
    {
        this.orbit = orbit;
        this.rotation = rotation;
        this.correctionText = correctionText;
    }
    
    public override void VerifyCorrect()
    {
        
        // Vérifier si dans cas correctOrbit proche de 0 si intervalle est bon
        bool orbitCorrect = true;
        if (question.MustVerifyOrbit())
        {
            float upperBound = question.correctOrbit + question.marginOrbit;
            float lowerBound = question.correctOrbit - question.marginOrbit;
            Debug.Log("Upper Bound orbit : " + upperBound);
            Debug.Log("Lower Bound orbit : " + lowerBound);
            Debug.Log("Orbit actuel : " + orbit.GetProgress());
            if (upperBound > 1 || lowerBound < 0)
            {
                Debug.Log("Case OU pour intervalle Orbit");
                Debug.Log("" + lowerBound%1f + " < orbit || orbit < " + upperBound%1f);
                orbitCorrect = orbit.GetProgress() < upperBound%1f ||
                               orbit.GetProgress() > lowerBound%1f;
            }
            else
            {
                Debug.Log("Case ET pour intervalle Orbit");
                Debug.Log("" + lowerBound + " < orbit && orbit < " + upperBound%1f);
                orbitCorrect = orbit.GetProgress() < upperBound &&
                               orbit.GetProgress() > lowerBound;
            }
            
        }
        Debug.Log("Orbit correcte ? " + orbitCorrect);
        
        // Vérifier si dans cas correctOrbit proche de 0 si intervalle est bon
        bool rotaCorrect = true;
        if (question.MustVerifyRotation())
        {
            // Special case, require specific time (sun progress) but no particular orbit, must take current orbit into account
            if (!question.MustVerifyOrbit())
            {
                Debug.Log("Special case rotation : only time matters");
                // Recalculate correct rotation based on actual orbit and correct value for orbit progress 0 (aka correct sun progress).
                question.correctRotation += orbit.GetProgress();
                question.correctRotation %= 1f;
                Debug.Log("Special case correct rotation : rotation=" + question.correctRotation +"  --  orbit=" + orbit.GetProgress());
            }
            
            float upperBound = question.correctRotation + question.marginRotation;
            float lowerBound = question.correctRotation - question.marginRotation;
            Debug.Log("Upper Bound rotation : " + upperBound);
            Debug.Log("Lower Bound rotation : " + lowerBound);
            Debug.Log("Rotation actuelle : " + rotation.GetProgress());
            if (upperBound > 1 || lowerBound < 0)
            {
                Debug.Log("Case OU pour intervalle Rotation");
                Debug.Log("" + lowerBound%1f + " < rotation || rotation < " + upperBound%1f);
                rotaCorrect = rotation.GetProgress() < upperBound%1f ||
                              rotation.GetProgress() > lowerBound%1f;
            }
            else
            {
                Debug.Log("Case ET pour intervalle Rotation");
                Debug.Log("" + lowerBound + " < rotation && rotation < " + upperBound%1f);
                rotaCorrect = rotation.GetProgress() < upperBound &&
                              rotation.GetProgress() > lowerBound;
            }
        }
        Debug.Log("Rotation correcte ? " + rotaCorrect);
        // Change value of correct
        correct = orbitCorrect && rotaCorrect;
        
    }
    
    public override void ShowCorrection()
    {
        
        // Show correction
        if (correct)
        {
            correctionText.text = "Bonne réponse";
        }
        else
        {
            correctionText.text = "Mauvaise réponse";
            // Show correct orbit
            if (question.MustVerifyOrbit())
            {
                orbit.SetProgress(question.correctOrbit);
                orbit.SetOrbitingObjectInCycle();
            }
            // Show correct rotation
            if (question.MustVerifyRotation())
            {
                rotation.SetProgress(question.correctRotation);
                rotation.SetOrbitingObjectInCycle();
            }
            
        }
    }
    
}
