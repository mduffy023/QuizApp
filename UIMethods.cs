using static Menu;

public class UIMethods
{
    public const int CHOICELIMIT = 4;
    private Logic logic;
    Quiz quiz = new Quiz();

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
    /// feature to be added  
    /// -----------------------------
    /// need to add a way that handles 
    /// wrong input type could use a TryParse 
    /// with a if statement that >= 1 || <= 6
    /// somthing along those lines 
    /// </summary>
    /// <returns>user input</returns>
    public static MenuOptions DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Add a New Question");
            Console.WriteLine("2. Play Quiz");
            Console.WriteLine("3. Save the quiz");
            Console.WriteLine("4. Load the Quiz");
            Console.WriteLine("5. Remove A question");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Please enter from 1 or 6 ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 6)
            {
                return (MenuOptions)choice;
            }
            else
            {
                Console.WriteLine("Invaild input. Please enter a number between 1 or 6 ");
            }
        }
    }

    /// <summary>
    /// Displays the total score on the console.
    /// </summary>
    /// <param name="score">The score value to be displayed.</param>
    public static void DisplayScore(int score)
    {
        Console.WriteLine($"Total Score: {score}");
    }


    /// <summary>
    /// allows the user to make a new question
    /// will ask them the question they like to enter 
    /// the choice and the correct answer can be more than one
    ///  feature to be added  
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
    ///  feature to be added  
    /// -----------------------------
    /// should add a display to show the index of each qustion#
    /// for the user to make it more readable
    /// </summary>
    public static int RemoveQuestionFromQuiz(Quiz quiz)
    {
        List<string> allQuestion = quiz.GetAllQuestions().Select(question => question.Query).ToList();

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
            if (isNumber && index >= 0 && index < quiz.GetAllQuestions().Count)
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
    ///  gets all qustions
    /// </summary>
    public static void GetAllQuizQuestions(Quiz quiz)
    {
       List<Question> questions = quiz.GetAllQuestions();
        foreach(Question question in questions)
        {
            Console.WriteLine(question.Query);         
        }
    }

    /// <summary>
    ///  method used to play the quiz 
    ///  get each question and displays 
    ///  it to the user for them to answer 
    ///   features to be added  
    /// -----------------------------
    /// 
    /// </summary>
    /// <param name="quiz">get the quiz that is loaded</param>
    public static int PlayQuiz(Quiz quiz)
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
        return score;
    }

    /// <summary>
    /// gets the users choice for the question 
    ///   features to be added  
    /// -----------------------------
    /// 
    /// </summary>
    /// <param name="question">choice of the question</param>
    public void GetUserChoices(Question question)
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
    /// Prompts the user to decide whether to save a quiz 
    /// and handles the saving process.
    /// features to be added  
    /// -----------------------------
    /// 
    /// </summary>
    public static void SaveQuizPrompt(Quiz quiz)
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
            try
            {
                Console.WriteLine("quiz has been saved");
                FileOperations.SaveQuiz(quiz, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"quiz not saved due to an error:{ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Okay quiz wont be saved");
        }
    }

    /// <summary>
    /// Prompts the user to decide whether to load 
    /// a quiz and handles the loading process.
    ///  features to be added  
    /// -----------------------------
    /// 
    /// </summary>
    public static Quiz LoadQuizPrompt()
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
            Quiz loadedQuiz = FileOperations.LoadQuiz(filePath);
            Console.WriteLine("quiz has been loaded");
            return loadedQuiz;
        }
        else
        {
            Console.WriteLine(" quiz have not been loaded");
            return null;
        }
    }
}
