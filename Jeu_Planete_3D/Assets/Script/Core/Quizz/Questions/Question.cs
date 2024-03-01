    

using Script.Core.Quizz.Questions;

public class Question
{

    public int id { get; private set; }
    public QuestionType type { get; private set; }
    public string header { get; private set; }

    public Question(int id, QuestionType type, string header)
    {
        this.id = id;
        this.type = type;
        this.header = header;
    }

    /*public int GetId()
    {
        return id;
    }

    public string GetQType()
    {
        return type;
    }

    public string GetHeader()
    {
        return header;
    }*/
    
}
