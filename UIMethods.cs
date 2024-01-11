using System.Net;
using static Menu;

public class UIMethods
{
    public const int CHOICELIMIT = 4;
    public const char YES = 'Y';
    public const char NO = 'N';

    //private Logic logic;
    Quiz quiz = new Quiz();

    /// <summary>
    /// the method is used to 
    /// allow UIMethods class use the 
    /// functionalities provided by Logic class 
    /// </summary>
    /// <param name="logic">allows this class access to Logic class</param>
    //  public UIMethods(Logic logic)
    // {
    //    this.logic = logic;
    // }

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
                Console.Clear();
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
        List<string> allQuestion = quiz.DisplayAllQuizQuestions().Select(question => question.Query).ToList();

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
            if (isNumber && index >= 0 && index < quiz.DisplayAllQuizQuestions().Count)
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
    public static void DisplayAllQuizQuestions(Quiz quiz)
    {
        List<Question> questions = quiz.DisplayAllQuizQuestions();
        foreach (Question question in questions)
        {
            Console.WriteLine(question.Query);
        }
    }

    /// <summary>
    /// Prompts the user with a question and its possible choices, then reads the user's answer from the console.
    /// </summary>
    /// <param name="question">The Question object containing the query and choices to present to the user.</param>
    /// <returns>The answer provided by the user as a string.</returns>
    public static string GetAnswerFromUser(Question question)
    {
        Console.WriteLine(question.Query);
       for (int i = 0; i < question.Choices.Count; i++)
       {
            Console.WriteLine($"{i + 1}. {question.Choices[i]}");
       }
        Console.WriteLine("Enter your answer: ");
        return Console.ReadLine();
    }

    /// <summary>
    /// Displays a message to the user indicating that the provided answer is correct.
    /// </summary>
    public static void OutputRightAnswerMessage()
    {
      Console.WriteLine("That is correct!");
    }

    /// <summary>
    /// Displays a message to the user indicating that the provided answer is incorrect and shows the correct answer(s).
    /// </summary>
    /// <param name="question">The Question object containing the correct answer(s) to display to the user.</param>
    public static void OutputWrongAnswerMessage(Question question)
    {
      Console.WriteLine($"Incorrect. The correct answer is: {string.Join(", ", question.Answers)}");
    }
    
    /// <summary>
    /// gets the users choice for the question 
    /// </summary>
    /// <param name="question">choice of the question</param>
    public static List<string> GetUserChoices(Question question)
    {
        Console.WriteLine(question.Query);
        for (int i = 0; i < question.Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {question.Choices[i]}");
        }

        Console.WriteLine("Pick your choices. if more than one separat with , ");
        string input = Console.ReadLine();

        List<string> userChoices = new List<string>();
        userChoices = Console.ReadLine().Split(',').Select(chocie => chocie.Trim()).ToList();

        return userChoices;

    }

    /// <summary>
    /// Prompts the user to decide whether to save a quiz 
    /// and handles the saving process.
    /// </summary>
    public static void SaveQuizPrompt(Quiz quiz)
    {

        char userPromt;
        bool answer = false;
        do
        {
            Console.WriteLine("would you like to save quiz? Y or N?");
            userPromt = Console.ReadKey().KeyChar;
            switch (userPromt)
            {
                case  YES:
                    answer = true;
                    break;
                case   NO:
                    answer = false;
                    break;
                default:
                    Console.WriteLine("Invaild input, Please only answer with Y or N");
     
                    break;
            }
        }
        while (answer == false && userPromt != NO);

        if (answer)
        {
            Console.WriteLine("Enter the file path for saving the quiz:");
            string filePath = Console.ReadLine();
            try
            {
                FileOperations.SaveQuiz(quiz, filePath);
                Console.WriteLine("quiz has been saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"quiz was not saved due to an error:{ex.Message}");
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
    /// </summary>
    public static Quiz LoadQuizPrompt()
    {
        char userPromt;
        bool answer = false;
        Console.WriteLine("would you like to load quiz? Y or N?");
        userPromt = Console.ReadKey().KeyChar;
        do
        {
            switch (userPromt)
            {
                case YES:
                    answer = true;
                    break;
                case  NO:
                    answer = false;
                    break;
                default:
                    Console.WriteLine("Invaild input, Please only answer with Y or N");
                    break;
            }
        }
        while (answer == false && userPromt != NO);

        if (answer)
        {
            Console.WriteLine("Enter the file path for loading the quiz:");
            string filePath = Console.ReadLine();
            try
            {
                Quiz loadedQuiz = FileOperations.LoadQuiz(filePath);
                Console.WriteLine("quiz has been loaded");
                return loadedQuiz;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"quiz not loaded due to an error{ex.Message}");
                return null;
            }
        }
        else
        {
            Console.WriteLine(" quiz have not been loaded");
            return null;
        }
    }
}
