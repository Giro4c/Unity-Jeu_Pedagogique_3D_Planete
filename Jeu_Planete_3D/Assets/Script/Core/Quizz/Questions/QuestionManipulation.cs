    


using Script.Core.Quizz.Questions;

public class QuestionManipulation : Question
{

    public float correctOrbit { get; set; }
    public float correctRotation { get; set; }

    public float marginOrbit { get; private set; }
    public float marginRotation { get; private set; }

    public QuestionManipulation(int id, QuestionType type, string header, float correctOrbit, float correctRotation, float marginOrbit, float marginRotation) : base(id, type, header)
    {
        this.correctOrbit = correctOrbit;
        this.correctRotation = correctRotation;
        this.marginOrbit = marginOrbit;
        this.marginRotation = marginRotation;
    }

    public bool MustVerifyOrbit()
    {
        return !(correctOrbit < 0);
    }
    
    public bool MustVerifyRotation()
    {
        return !(correctRotation < 0);
    }
    
    /*public float GetCorrectOrbit()
    {
        return correctOrbit;
    }
    
    public float GetCorrectRotation()
    {
        return correctRotation;
    }

    public float GetMarginOrbit()
    {
        return marginOrbit;
    }

    public float GetMarginRotation()
    {
        return marginRotation;
    }*/

}
