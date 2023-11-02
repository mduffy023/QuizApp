[Serializable]
public class Question
{
    public string Query { get; set; }
    public List<string> Choices{ get; set; } = new List<string>();
    public List<string> Answers { get; set; } = new List<string>();
}

