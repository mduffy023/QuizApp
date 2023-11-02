[Serializable]
public class Quiz : FileOperations
{
    public const int ChoiceLimit = 3; 

    public List<Question> Questions { get; set; } = new List<Question>();

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    public Question GetQuestionFromUser()
    {
        Console.WriteLine("Enter a question :");
        string userQueestion = Console.ReadLine();

        Question question = new Question { Query = userQueestion };

        for (int i = 0; 1 < ChoiceLimit; i++) 
        {
          Console.WriteLine($"Enter choice {i + 1}: ");
            question.Choices.Add(Console.ReadLine());
        }


        Console.WriteLine("Enter the correct Answer or Answers. if more than one Answer separate with a comma ");
        string[] correctAnswers = Console.ReadLine().Split(',');
        foreach (string userAnswer in correctAnswers)
        {
            question.Answers.Add(userAnswer.Trim());
        }

        return question;
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
