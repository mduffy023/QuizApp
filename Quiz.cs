[Serializable]
public class Quiz : FileOperations
{
    public List<Question> Questions { get; set; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    public void SelectQuiz()
    {
        int score = 0; 
        foreach (Question question in Questions)
        {
            Console.WriteLine(question.Query);
            for (int i = 0; i < question.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Choices[i]}");
            }

            Console.WriteLine("Your Answer: ");
            string userAnswer = Console.ReadLine();

            if (question.Answers.Contains(userAnswer))
            {
                score++;
            }
        }
        Console.WriteLine($"Your score: {score}/{Questions.Count}");
    }
}
