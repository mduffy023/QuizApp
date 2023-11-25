using System.Linq;

public class UIMethods
{
    public const int CHOICELIMIT = 4;
    private Logic logic;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logic"></param>
    public UIMethods(Logic logic)
    {
        this.logic = logic;
    }

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
        for (int i = 0; i < CHOICELIMIT; i++)
        {
            Console.WriteLine($"Enter Choice {i + 1}");
            userChoices.Add(Console.ReadLine());
        }

        Console.WriteLine("enter the Correct answer, separet by comma, if multiple: ");
        List<string> correctAnwers = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

        return new Question(usersQuestion, userChoices, correctAnwers);
    }

    /// <summary>
    /// 
    /// </summary>
    public int RemoveQuestionFromQuiz()
    {
        GetAllQuizQuestions();
        while (true)
        {
            Console.WriteLine("Enter the index of the question you would like to get rid of?");
            int index;
            bool isNumber = int.TryParse(Console.ReadLine(), out index);
            if (isNumber && index >= 0 && index < logic.GetAllQuestions().Count)
            {
                return index;
            }
            else
            {
                Console.WriteLine("Invalid index. Please enter a number within the specified range.");
            }
        }
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

    public static void PlayQuiz(Quiz quiz)
    {
        int score = 0;

        foreach (Question question in quiz.Questions)
        {
            Console.WriteLine(question);
            Console.WriteLine("enter your answer: ");
            string userAnswer = Console.ReadLine();
            if (question.Answers.Contains(userAnswer))
            {
                Console.WriteLine("that is correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"incorrect the Answer is {question.Answers}");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="question"></param>
    public void GetUserAnswer(Question question)
    {
        Console.WriteLine(question.Query);

        foreach(string chocie in question.Choices)
        {
            Console.WriteLine(chocie);

            Console.WriteLine("pick you choices. if more than one separat with , ");
            List<string> userChocies = new List<string>();
            userChocies = Console.ReadLine().Split (',').Select(chocie => chocie.Trim()).ToList();
        }
    }

    public void SaveQuizPrompt()
    {

        string userPromt = "";
        bool answer = false;
        Console.WriteLine("would you like to save quiz? Yes or No?");
        userPromt = Console.ReadLine();
        do
        {
            switch (userPromt)
            {
                case "yes":
                    answer = true;
                    break;
                case "no":
                    answer = false;
                    break;
                default:
                    Console.WriteLine("can only answer with Yes or No");
                    userPromt = "";
                    break;
            }
        }
        while (userPromt == "");
    
        if (answer)
        {
            Console.WriteLine("Enter the file path for saving the quiz:");
            string filePath = Console.ReadLine();
            Console.WriteLine("quiz has been saved");
            logic.SaveQuiz(filePath);
        }
        else
        {
            Console.WriteLine("Okay quiz wont be saved");
        }
    }

    public void LoadQuizPrompt()
    {
        string userPromt = "";
        bool answer = false;
        Console.WriteLine("would you like to load quiz? Yes or No?");
        userPromt = Console.ReadLine();
        do
        {
            switch (userPromt)
            {
                case "yes":
                    answer = true;
                    break;
                case "no":
                    answer = false;
                    break;
                default:
                    Console.WriteLine("can only answer with Yes or No");
                    userPromt = "";
                    break;
            }
        }
        while (userPromt == "");

        if (answer)
        {
            Console.WriteLine("Enter the file path for loading the quiz:");
            string filePath = Console.ReadLine();
            Console.WriteLine("quiz has been loaded");
            logic.LoadQuiz();
        }
        else
        {
            Console.WriteLine(" quiz have not been loaded");
        }
    }
}
