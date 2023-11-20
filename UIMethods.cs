public class UIMethods
{

    private Logic logic;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logic"></param>
    public UIMethods(Logic logic)
    {
        this.logic = logic;
    }

    public const int choiceLimit = 4;

    /// <summary>
    /// 
    /// </summary>
    public static void DisplayIntro()
    {
        Console.WriteLine("Welcome to the Quiz Maker! ");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int DisplayMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Add a New Question");
        Console.WriteLine("2. Play Quiz");
        Console.WriteLine("3. Save the quiz");
        Console.WriteLine("4. Load the Quiz");
        Console.WriteLine("5. Reomve A question");
        Console.WriteLine("6. Exit");
        return int.Parse(Console.ReadLine());
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Question GetNewQuestion()
    {
        Console.WriteLine("Enter the Question:");
        string usersQuestion = Console.ReadLine();

        List<string> userChoices = new List<string>();
        for (int i = 0; i < choiceLimit; i++)
        {
            Console.WriteLine($"Enter Choice {i + 1}");
            userChoices.Add(Console.ReadLine());
        }

        Console.WriteLine("enter the Correct answeer, separet by comm, if multiple: ");
        List<string> correctAnwers = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

        return new Question(usersQuestion, userChoices, correctAnwers);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RemoveQuestionFromQuiz()
    {
        GetAllQuizQuestions();
        Console.WriteLine("Enter the index of the question you would like to get rid of?");
        int index = int.Parse(Console.ReadLine());

        logic.RemoveQuestion(index);

    }

    /// <summary>
    /// 
    /// </summary>
    public void GetAllQuizQuestions()
    {
       List<Question> questions = logic.GetAllQuestions();
        foreach(Question question in questions)
        {
            Console.WriteLine(question.Query);
        }
    }

  

 
}
