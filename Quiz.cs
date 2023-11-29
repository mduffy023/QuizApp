[Serializable]
public class Quiz 
{
    /// <summary>
    /// Defines the maximum number of choices allowed.
    /// </summary>
    public const int ChoiceLimit = 3;

    /// <summary>
    /// A list to store the questions.
    /// </summary>
    public List<Question> Questions { get; set; } = new List<Question>();

    /// <summary>
    /// Adds a new question to the list of questions.
    /// </summary>
    /// <param name="question">The question to be added.</param>
    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }
}
