using System;

public interface IQuestionCorrector<out QType> where QType: Question
{
    
    public QType GetQuestion();
    public bool correct { get; set; }
    public DateTime startTime { get; set; }
    
    public abstract void VerifyCorrect();
    public abstract void ShowCorrection();
    
    public void Correct()
    {
        VerifyCorrect();
        ShowCorrection();
    }
    
    

}
