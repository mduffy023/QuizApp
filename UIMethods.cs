using System.Diagnostics.Metrics;
using static Menu;

public class UIMethods
{
    public const int CHOICELIMIT = 4;
    public const char YES = 'Y';
    public const char NO = 'N';

    //private Logic logic;
    Quiz quiz = new Quiz();

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
    /// need to impelment some data handleing 
    /// so if a question has been written then it 
    /// shouldn't be allow to be written again 
    /// probably needd to add a are you sure 
    /// would you like to review your inputs 
    /// </summary>
    /// <returns>stores the user question </returns>
    public static Question GetNewQuestion()
    {
        string usersQuestion = PromptForNonEmptyInput("Enter the Question:");

        List<string> userChoices = new List<string>();
        for (int i = 0; i < CHOICELIMIT; i++)
        {
            string choice = PromptForNonEmptyInput($"Enter Choice { i + 1}:");
            userChoices.Add(choice);
        }
        string correctAnswersInput = PromptForNonEmptyInput("Enter the Correct answer, separated by comma, if multiple:");
        List<string> correctAnswers = correctAnswersInput.Split(',').Select(a => a.Trim()).ToList();

        return new Question(usersQuestion, userChoices, correctAnswers);
    }

    /// <summary>
    /// Repeatedly prompts the user for input until a non-empty and non-whitespace string is provided.
    /// This method ensures that the user cannot proceed without providing valid input.
    /// </summary>
    /// <param name="prompt">The message displayed to the user, instructing them what to input.</param>
    /// <returns>A non-empty string input by the user.</returns>
    private static string PromptForNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
              Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    /// <summary>
    ///  allows the user to remove questions
    ///  will display all questions
    ///  user removes the question by enter the index
    ///  if there are no question then a message will prompt 
    ///  the user to let them now
    /// should add a display to show the index of each qustion#
    /// for the user to make it more readable
    /// </summary>
    public static int RemoveQuestionFromQuiz(Quiz quiz)
    {
        List<string> allQuestions = quiz.DisplayAllQuizQuestions().Select(question => question.Query).ToList();

        if (allQuestions.Count == 0)
        {
            Console.WriteLine("There are no questions to remove. Press any key to return to the main menu...");
            Console.ReadKey();
            return -1; // Return -1 to indicate no removal will take place.
        }

        Console.WriteLine("Enter the index of the question you would like to get rid of, or just press Enter to back out without removing any questions:");

        while (true)
        {
            string input = Console.ReadLine(); // Get user input after the prompt.

            // Check if the user wants to cancel the operation by pressing Enter.
            if (string.IsNullOrWhiteSpace(input))
            {
                return -1; // Return -1 to indicate cancellation.
            }

            // Attempt to parse the input as an index number.
            bool isNumber = int.TryParse(input, out int index);
            if (isNumber && index >= 0 && index < allQuestions.Count)
            {
                return index; // Return the valid
            }
            else
            {
                // Prompt again only if the input was invalid
                Console.WriteLine("Invalid index. Please enter a number within the specified range or just press Enter to back out:");
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
        Console.WriteLine("Enter your answers, separated by commas (e.g., 'answers, answers2'):");
        return Console.ReadLine();
    }

    /// <summary>
    /// Prompts the user to decide whether to save a quiz 
    /// and handles the saving process.
    /// </summary>
    public static bool SaveQuizPrompt()
    {
        char userPrompt;
        Console.WriteLine("Would you like to save a quiz? Y or N?");

        do
        {
            userPrompt = Console.ReadKey().KeyChar;
            userPrompt = char.ToUpper(userPrompt);

            if (userPrompt == YES || userPrompt == NO)
            {
                return userPrompt == YES;
            }
            else
            {
                Console.WriteLine("\nInvalid input, please only answer with Y or N");
            }
        }
        while (true);
    }

    /// <summary>
    /// Prompts the user to enter the file path where they intend to save a quiz.
    /// This method ensures any surrounding quotation marks are removed from the input path.
    /// </summary>
    /// <returns>A string representing the file path input by the user without surrounding quotation marks.</returns>
    public static string SaveFilePathFromUser()
    {
        Console.WriteLine("Enter the file path for loading the quiz:");
        string filePath = Console.ReadLine();
        return filePath.Trim('"'); // Removes quotation marks from the start and end of the string
    }

    /// <summary>
    /// Prompts the user to decide whether to load 
    /// a quiz and handles the loading process.
    /// </summary>
    public static bool LoadQuizPrompt()
    {
        char userPrompt;
        Console.WriteLine("Would you like to load a quiz? Y or N?");

        do
        {
            userPrompt = Console.ReadKey().KeyChar;
            userPrompt = char.ToUpper(userPrompt);
            
            if(userPrompt == YES || userPrompt == NO)
            {
                return userPrompt == YES;
            }else
            {
                Console.WriteLine("\nInvalid input, please only answer with Y or N"); 
            }
        }
        while (true);
    }

    /// <summary>
    /// Prompts the user to enter the file path where they intend to save a quiz.
    /// This method ensures any surrounding quotation marks are removed from the input path.
    /// </summary>
    /// <returns>A string representing the file path input by the user without surrounding quotation marks.</returns>
    public static string GetFilePathFromUser()
    {
        Console.WriteLine("Enter the file path for loading the quiz:");
        string filePath = Console.ReadLine();
        return filePath.Trim('"'); // Removes quotation marks from the start and end of the string
    }
}
