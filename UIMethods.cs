using System.Linq;

public class UIMethods
{
    public const int CHOICELIMIT = 4;
    private Logic logic;

    /// <summary>
    /// the method is used to 
    /// allow UIMethods class use the 
    /// functionalities provided by Logic class 
    /// </summary>
    /// <param name="logic">allows this class access to Logic class</param>
    public UIMethods(Logic logic)
    {
        this.logic = logic;
    }

    /// <summary>
    /// display a welcome message to the user 
    /// </summary>
    public static void DisplayIntro()
    {
        Console.WriteLine("Welcome to the Quiz Maker! ");
    }

    /// <summary>
    /// displays a menu for the user 
    /// that can be inracted with 
    /// by enter a integer when prompted
    /// added feature to be added  
    /// -----------------------------
    /// need to add a way that handles 
    /// wrong input type could use a TryParse 
    /// with a if statement that >= 1 || <= 6
    /// somthing along those lines 
    /// </summary>
    /// <returns>user input</returns>
    public static int DisplayMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Add a New Question");
        Console.WriteLine("2. Play Quiz");
        Console.WriteLine("3. Save the quiz");
        Console.WriteLine("4. Load the Quiz");
        Console.WriteLine("5. Reomve A question");
        Console.WriteLine("6. Exit");
        Console.WriteLine("Please enter from 1 or 6 ");
        return int.Parse(Console.ReadLine());
    }

    /// <summary>
    /// allows the user to make a new question
    /// will ask them the question they like to enter 
    /// the choice and the correct answer can be more than one
    ///  added feature to be added  
    /// -----------------------------
    /// need to impelment some data handleing 
    /// so if a question has been written then it 
    /// shouldn't be allow to be written again 
    /// probably needd to add a are you sure 
    /// would you like to review your inputs 
    /// </summary>
    /// <returns>stores the user question </returns>
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
    ///  allows the user to remove questions
    ///  will display all questions
    ///  user removes the question by enter the index
    ///  if there are no question then a message will prompt 
    ///  the user to let them now
    ///  added feature to be added  
    /// -----------------------------
    /// should add a display to show the index of each qustion#
    /// for the user to make it more readable
    /// </summary>
    public int RemoveQuestionFromQuiz()
    {
        List<string> allQuestion = logic.GetAllQuestions().Select(question => question.Query).ToList();

        if (allQuestion.Count == 0)
        {
            Console.WriteLine("there are no question to remove");
            return 0;
        }

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
    ///  added feature to be added  
    /// -----------------------------
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

    /// <summary>
    ///  
    ///  added feature to be added  
    /// -----------------------------
    /// 
    /// </summary>
    /// <param name="quiz"></param>
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
    ///  added feature to be added  
    /// -----------------------------
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


    /// <summary>
    /// 
    ///  added feature to be added  
    /// -----------------------------
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    ///  added feature to be added  
    /// -----------------------------
    /// 
    /// </summary>
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
