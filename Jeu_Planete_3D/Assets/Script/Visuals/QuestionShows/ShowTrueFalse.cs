using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowTrueFalse : ShowQCU
{
    [SerializeField] protected Cycle orbit;
    [SerializeField] protected Cycle rotation;

    public override void ShowTheQuestion(Question question)
    {
        base.ShowTheQuestion(question);
        QuestionTrueFalse questionTrueFalse = (QuestionTrueFalse) question;
        if (questionTrueFalse.IsOrbitFixed())
        {
            orbit.SetProgress(questionTrueFalse.fixedOrbit);
            orbit.SetPositionAndRotationInCycle();
        }

        if (questionTrueFalse.IsRotationFixed())
        {
            rotation.SetProgress(questionTrueFalse.fixedRotation);
            rotation.SetPositionAndRotationInCycle();
        }
    }
    
}
