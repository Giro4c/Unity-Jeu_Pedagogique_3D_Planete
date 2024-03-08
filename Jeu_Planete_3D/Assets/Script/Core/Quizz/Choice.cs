public class Choice
{
    
    public string value { get; set; }
    
    public bool correct { get; set; }

    public Choice(string value, bool correct)
    {
        this.value = value;
        this.correct = correct;
    }
}
