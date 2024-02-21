
using UnityEngine;

public class CorrectorQCU : QuestionCorrector<QuestionQCU>
{
    
    public ChoiceButton[] choices { get; protected set; }

    public CorrectorQCU(QuestionQCU question, ChoiceButton[] choices) : base(question)
    {
        this.choices = choices;
    }

    public override void VerifyCorrect()
    {
        correct = false;
        bool incorrect = false;
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            if (choices[indexChoice].selected)
            {
                if (! choices[indexChoice].choice.correct)
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
        correct = correct && !incorrect;
    }
    
    public override void ShowCorrection()
    {
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            choices[indexChoice].ActivationButton(false);
            if (! choices[indexChoice].choice.correct)
            {
                // Only indicate that choice is wrong if it was selected
                if (choices[indexChoice].selected)
                {
                    // Wrong answer
                    choices[indexChoice].ChangeColorImage(Color.red);
                }
            }
            else
            {
                // Right answer
                choices[indexChoice].ChangeColorImage(Color.green);
            }
        }
    }

    public void ResetChoiceSelection()
    {
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            choices[indexChoice].ActivationButton(true);
            choices[indexChoice].ResetSelection();
        }
    }
    
}
