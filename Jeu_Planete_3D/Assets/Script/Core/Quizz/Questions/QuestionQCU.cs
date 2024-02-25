    

using Script.Core.Quizz.Questions;
using UnityEngine;

public class QuestionQCU : Question
{
    
    public Choice[] choices { get; private set; }

    public QuestionQCU(int id, QuestionType type, string header, Choice[] choices) : base(id, type, header)
    {
        this.choices = choices;
        // Debug.Log("Choices of question " + id);
        // foreach (Choice choice in choices)
        // {
        //     Debug.Log("Value : " + choice.value + " --- Correct ? " + choice.correct);
        // }
    }
}
