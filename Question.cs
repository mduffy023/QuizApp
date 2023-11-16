[Serializable]
public class Question
{
    private string Query { get; set; }
    public List<string> Choices{ get; set; } = new List<string>();
    public List<string> Answers { get; set; } = new List<string>();


    public Question(string query, List<string> choices, List<string> answers)
    {
        Query = query;
        Choices = choices;
        Answers = answers;
    }
}

