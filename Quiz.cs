using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Quiz
{
    public List<Question> Questions { get; set; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }


}
