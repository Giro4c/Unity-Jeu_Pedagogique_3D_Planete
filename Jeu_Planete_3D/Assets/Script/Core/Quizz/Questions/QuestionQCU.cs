    

using Script.Core.Quizz.Questions;

public class QuestionQCU : Question
{
    
    public Choice[] choices { get; private set; }

    public QuestionQCU(int id, QuestionType type, string header, Choice[] choices) : base(id, type, header)
    {
        this.choices = choices;
    }
}
