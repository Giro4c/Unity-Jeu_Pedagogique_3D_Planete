/*
using System;
using UnityEngine;
using UnityEngine.UI;

public class CorrectorQCU_Old : QuestionCorrector_Old
{

    // For Verifications
    public string correctAnswer;
    // For answer and show Correction
    public GameObject[] choices;
    // For showing correction
    
    
    public override void VerifyCorrect()
    {
        // Calculate the duration of the question
        DateTime endTime = DateTime.Now;
        SetDuration(endTime - GetStartTime());
        
        bool correct = false;
        bool incorrect = false;
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            if (choices[indexChoice].GetComponent<Selected>().IsSelected())
            {
                if (! choices[indexChoice].GetComponent<Selected>().GetStringValue().Equals(correctAnswer))
                {
                    // Wrong answer
                    incorrect = true;
                    break;
                }
                // else right answer
                correct = true;
            }
        }
        // Condition for true right answer : selected the correct answer (correct) and no wrong answer selected (!incorrect)
        SetCorrect(correct && !incorrect);
    }
    
    public override void ShowCorrection()
    {
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            choices[indexChoice].GetComponent<Button>().interactable = false;
            if (!choices[indexChoice].GetComponent<Selected>().GetStringValue().Equals(correctAnswer))
            {
                // Only indicate that choice is wrong if it was selected
                if (choices[indexChoice].GetComponent<Selected>().IsSelected())
                {
                    // Wrong answer
                    choices[indexChoice].GetComponent<Selected>().ChangeColorImage(Color.red);
                }
            }
            else
            {
                // Right answer
                choices[indexChoice].GetComponent<Selected>().ChangeColorImage(Color.green);
            }
        }
    }

    public void ResetChoiceSelection()
    {
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            choices[indexChoice].GetComponent<Button>().interactable = true;
            choices[indexChoice].GetComponent<Selected>().SetSelected(false);
        }
    }
    
}
*/
