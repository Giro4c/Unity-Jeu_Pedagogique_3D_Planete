using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowTrueFalse : ShowQCU
{
    protected Cycle orbit;
    protected Cycle rotation;

    public override void ShowTheQuestion(Question question)
    {
        base.ShowTheQuestion(question);
        QuestionTrueFalse questionTrueFalse = (QuestionTrueFalse) question;
        if (questionTrueFalse.IsOrbitFixed())
        {
            orbit.SetProgress(questionTrueFalse.fixedOrbit);
            orbit.SetOrbitingObjectInCycle();
        }

        if (questionTrueFalse.IsRotationFixed())
        {
            rotation.SetProgress(questionTrueFalse.fixedRotation);
            rotation.SetOrbitingObjectInCycle();
        }
    }
    
}
