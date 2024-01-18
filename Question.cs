[Serializable]
public class Question
{
    /// <summary>
    /// The main text or statement of the question.
    /// </summary>
    private string _query;

    public string Query
    {
        get { return _query; }
        set { _query = value; }
    }


    /// <summary>
    /// A list of potential choices or options associated with the question.
    /// </summary>
    public List<string> Choices{ get; set; } = new List<string>();

    /// <summary>
    /// A list of correct answers for the question. This can have one or more entries.
    /// </summary>
    public List<int> correctAnswers { get; set; } = new List<int>();

    /// <summary>
    /// Constructor for creating a new Question object with specified query, choices, and answers.
    /// </summary>
    /// <param name="query">The main text of the question.</param>
    /// <param name="choices">A list of choices related to the question.</param>
    /// <param name="answers">A list of correct answers for the question.</param>
    public Question(string query, List<string> choices, List<int> answers)
    {
        _query = query;
        Choices = choices ?? new List<string>(); // Ensure choices is not null
        correctAnswers = answers ?? new List<int>(); // Ensure answers is not null
    }

    public Question()
    {

    }
}

