
using UnityEngine;

public class CorrectorQCU : QuestionCorrector<QuestionQCU>
{
    
    public ChoiceButton[] choices { get; protected set; }

    public CorrectorQCU(QuestionQCU question, ChoiceButton[] choices) : base(question)
    {
        this.choices = choices;
        // DebugChoicesButtons();
        ResetChoiceSelection();
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
        // DebugChoicesButtons();

    }

    private void DebugChoicesButtons()
    {
        Debug.Log("Start Debug correction QCU");
        Debug.Log("Verify choices array : Length = " + choices.Length);
        foreach (ChoiceButton choice in choices)
        {
            Debug.Log("Value : " + choice.choice.value + " --- Correct ? " + choice.choice.correct + " --- Selected ? " + choice.selected);
            Debug.Log("Button : " + choice.GetButton());
        }
        Debug.Log("End Debug correction QCU");

    }

    public void ResetChoiceSelection()
    {
        for (int indexChoice = 0; indexChoice < choices.Length; ++indexChoice)
        {
            choices[indexChoice].ActivationButton(true);
            choices[indexChoice].ResetSelection();
        }
    }
    
    public static void ResetChoicesSelection(ChoiceButton[] choiceButtons)
    {
        for (int indexChoice = 0; indexChoice < choiceButtons.Length; ++indexChoice)
        {
            choiceButtons[indexChoice].ActivationButton(true);
            choiceButtons[indexChoice].ResetSelection();
        }
    }
    
}
