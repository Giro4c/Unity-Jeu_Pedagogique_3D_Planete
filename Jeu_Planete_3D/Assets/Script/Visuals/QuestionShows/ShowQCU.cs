using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class ShowQCU : ShowQuestion
{

    protected ChoiceButton[] choices;
    
    public override void ShowTheQuestion(Question question)
    {
        base.ShowTheQuestion(question);
        QuestionQCU questionQcu = (QuestionQCU) question;
        for (int i = 0; i < questionQcu.choices.Length; ++i)
        {
            choices[i].GetText().text = questionQcu.choices[i].value;
        }
        
    }

    public ChoiceButton[] GetChoices()
    {
        return choices;
    }

}
