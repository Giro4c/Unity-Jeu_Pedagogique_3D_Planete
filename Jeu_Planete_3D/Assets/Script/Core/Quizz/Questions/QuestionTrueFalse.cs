    

using Script.Core.Quizz.Questions;

public class QuestionTrueFalse : QuestionQCU
{

    public float fixedOrbit { get; private set; }
    public float fixedRotation { get; private set; }

    public QuestionTrueFalse(int id, QuestionType type, string header, Choice[] choices, float fixedOrbit, float fixedRotation) : base(id, type, header, choices)
    {
        this.fixedOrbit = fixedOrbit;
        this.fixedRotation = fixedRotation;
    }

    public bool IsOrbitFixed()
    {
        return !(fixedOrbit < 0);
    }
    
    public bool IsRotationFixed()
    {
        return !(fixedRotation < 0);
    }
    
}
