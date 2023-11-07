[Serializable]
public class Quiz : FileOperations
{
    public const int ChoiceLimit = 3; 

    public List<Question> Questions { get; set; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }
}
