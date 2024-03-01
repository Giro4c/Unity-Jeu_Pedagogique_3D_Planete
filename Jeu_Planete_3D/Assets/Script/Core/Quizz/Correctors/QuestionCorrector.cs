using System;

public abstract class QuestionCorrector<QType> : IQuestionCorrector<QType> where QType: Question
{

    protected QType question;
    public bool correct { get; set; }
    public DateTime startTime { get; set; }
    
    
    public QuestionCorrector(QType question)
    {
        this.question = question;
        correct = false;
        startTime = DateTime.Now;
    }
    
    public QType GetQuestion()
    {
        return question;
    }

    public abstract void VerifyCorrect();
    public abstract void ShowCorrection();
    
    // public void Correct()
    // {
    //     VerifyCorrect();
    //     ShowCorrection();
    // }
    
    

}
