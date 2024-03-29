﻿using static Menu;

public static class UIMethods
{
    public const int CHOICELIMIT = 4;
    public const char YES = 'Y';
    public const char NO = 'N';

    /// <summary>
    /// display a welcome message to the user 
    /// </summary>
    public static void DisplayIntro()
    {
        Console.WriteLine("Welcome to the Quiz Maker! ");
    }
    public static void DisplayHowToCreateQuestions()
    {
        Console.WriteLine("enter a question e.g In Ancient Rome, how many days of the week were there?");
        Console.WriteLine("then enter the Choices, it will be between 4 choices,e.g Five Six Eight Ten");
        Console.WriteLine("then enter the choice of the answer  ");
        Console.WriteLine("e.g answer is Eight. So what ever choie you place it in e.g choice 2 then put 2");
        Console.WriteLine("if the question has more than one answer then do 1,2");
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
    /// <summary>
    /// Displays the user's score in relation to the total number of questions.
    /// </summary>
    /// <param name="score">The score achieved by the user.</param>
    /// <param name="totalQuestions">The total number of questions in the quiz.</param>
    public static void OutputScore(int score, int totalQuestions)
    {
        Console.WriteLine($"Your Score: {score}/{totalQuestions}");
    }

    /// <summary>
    /// waits for the user to initiate by pressing the Enter key
    /// retruns to main menu 
    /// </summary>
    public static void WaitForKeyPress()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to return to main menu");
        Console.WriteLine();
        Console.ReadKey(true);
        Console.Clear();
    }

    /// <summary>
    /// Prompts the user for their answers to a given question, expects numeric input corresponding to choices.
    /// </summary>
    /// <param name="question">The Question object containing the query and choices.</param>
    /// <returns>A list of indices representing the user's answer choices.</returns>
    public static List<int> GetUserAnswersIndices(Question question)
    {
        Console.WriteLine(question.Query);
        for (int i = 0; i < question.Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Choices[i]}");
        }
        Console.WriteLine("Enter the numbers corresponding to your answers, separated by commas (e.g., 1,4):");
        string input = Console.ReadLine();
        List<int> indices = input.Split(',').Select(s => s.Trim()).Where(s => int.TryParse(s, out int index) && index > 0 && index <= question.Choices.Count).Select(s => int.Parse(s) - 1).ToList();

        return indices;
    }


    /// <summary>
    /// Creates a new question by gathering input for the question text, choices, and correct answers.
    /// </summary>
    /// <returns>A new Question object with the provided details.</returns>
    public static void GetNewQuestion(Action<Question> addQuestionCallback)
    {
        DisplayHowToCreateQuestions();

        string questionText = GetQuestionText();
        if (!string.IsNullOrWhiteSpace(questionText))
        {
            List<string> choices = GetQuestionChoices();
            List<int> correctAnswerIndices = GetCorrectAnswerIndices(choices.Count);

            Question newQuestion = new Question(questionText, choices, correctAnswerIndices);
            addQuestionCallback(newQuestion);
            Console.WriteLine("Question added successfully.");
        }
        else
        {
            Console.WriteLine("Question creation cancelled.");
        }
    }

    /// <summary>
    /// Prompts the user to enter the text for a question and ensures it is not empty.
    /// </summary>
    /// <returns>The question text entered by the user.</returns>
    private static string GetQuestionText()
    {
        string usersQuestion;
        do
        {
            usersQuestion = PromptForNonEmptyInput("Enter the Question:");
            if (string.IsNullOrWhiteSpace(usersQuestion))
            {
                Console.WriteLine("The question cannot be empty. Please enter a valid question.");
            }
        } while (string.IsNullOrWhiteSpace(usersQuestion));

        return usersQuestion;
    }

    /// <summary>
    /// Collects a predetermined number of choices from the user for a question.
    /// </summary>
    /// <returns>A list of choices for the question.</returns>
    private static List<string> GetQuestionChoices()
    {
        List<string> userChoices = new List<string>();
        for (int i = 0; i < CHOICELIMIT; i++)
        {
            string choice = PromptForNonEmptyInput($"Enter Choice {i + 1}:");
            userChoices.Add(choice);
        }
        return userChoices;
    }

    /// <summary>
    /// Prompts the user to enter the indices of the correct answers and validates them.
    /// </summary>
    /// <param name="choicesCount">The number of choices available for the question.</param>
    private static List<int> GetCorrectAnswerIndices(int choicesCount)
    {
        string correctAnswersIndicesInput = PromptForNonEmptyInput("Enter the number(s) of the correct answer(s), separated by comma, if multiple (e.g., 1,4):");
        return correctAnswersIndicesInput.Split(',').Select(a => int.Parse(a.Trim()) - 1).Where(index => index >= 0 && index < choicesCount).Distinct().ToList();
    }


    /// <summary>
    /// Repeatedly prompts the user for input until a valid string is provided. 
    /// This method is designed to prevent the user from proceeding without input, except when entering a question.
    /// If the prompt is specifically for entering a question ("Enter the Question:"),
    /// this method allows an empty input, enabling the user to return to the main menu by pressing Enter without typing anything.
    /// In all other cases, the method will insist on a non-empty and non-whitespace string to ensure that valid input is provided.
    /// </summary>
    /// <param name="prompt">The message displayed to the user, instructing them what to input.</param>
    /// <returns>
    /// A valid string input by the user. If the prompt is for the question and the input is empty, 
    /// the method returns an empty string to indicate the user's intention to return to the main menu.
    /// </returns>
    private static string PromptForNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            // Check if the prompt is for the question and allow an empty response in this case.
            if (prompt == "Enter the Question:" && string.IsNullOrEmpty(input))
            {
                return input; // Will allow the empty string to be returned.
            }

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
        Console.WriteLine($"Incorrect. The correct answer is: {string.Join(", ", question.correctAnswers)}");
    }

    /// <summary>
    /// displays no quiz loaded or is empty 
    /// </summary>
    public static void noQuizLoaded()
    {
        Console.WriteLine("No quiz loaded or quiz is empty. Load or add questions to a quiz first.");
        Console.WriteLine("Press any key to return to the menu...");
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
    public static void SaveQuizPrompt(Quiz quiz)
    {
        Console.WriteLine($"Would you like to save a quiz? {YES} or {NO}?");
        char userPrompt = Console.ReadKey().KeyChar;
        userPrompt = char.ToUpper(userPrompt);

        if (userPrompt == YES)
        {
            string filePath = SaveFilePathFromUser();
            FileOperations.CheckAndSaveQuiz(quiz, filePath);
        }
   
        else if (userPrompt == NO)
        {
            Console.WriteLine("\nQuiz saving cancelled.");
        }  
        else
            {
                Console.WriteLine($"\nInvalid input, please only answer with {YES} or {NO}");
            }
    }

    /// <summary>
    /// Prompts the user to enter the file path where they intend to save a quiz.
    /// This method ensures any surrounding quotation marks are removed from the input path.
    /// </summary>
    /// <returns>A string representing the file path input by the user without surrounding quotation marks.</returns>
    public static string SaveFilePathFromUser()
    {
        Console.WriteLine("\nEnter the file path for loading the quiz:");
        string filePath = Console.ReadLine();
        return filePath.Trim('"'); // Removes quotation marks from the start and end of the string
    }

    /// <summary>
    /// Prompts the user to decide whether to load a quiz and then handles the loading process.
    /// This method first asks the user if they wish to load a quiz. If the user responds YES ('Y'),
    /// it then prompts for the file path, validates the file's existence, and loads the quiz from the file.
    /// If the file doesn't exist, it notifies the user and returns null. 
    /// If the user responds NO ('N'), it cancels the loading process and returns null.
    /// The method also handles invalid inputs by asking the user to retry.
    /// </summary>
    /// <returns>
    /// The loaded Quiz object if the file exists and the user opts to load the quiz; otherwise, null.
    /// </returns>
    public static void LoadQuizPrompt(Quiz quiz)
    {
        Console.WriteLine($"Would you like to load a quiz? {YES} or {NO}?");
        char userPrompt = Console.ReadKey().KeyChar;
        userPrompt = char.ToUpper(userPrompt);

        if (userPrompt == YES)
        {
            string filePath = GetFilePathFromUser();
            FileOperations.CheckAndLoadQuiz(quiz, filePath);
        }
        else if (userPrompt == NO)
        {
            Console.WriteLine("\nQuiz loading cancelled.");
        }
        else
        {
            Console.WriteLine($"\nInvalid input, please only answer with {YES} or {NO}");
        }
    }

    /// <summary>
    /// Prompts the user to enter the file path where they intend to save a quiz.
    /// This method ensures any surrounding quotation marks are removed from the input path.
    /// </summary>
    /// <returns>A string representing the file path input by the user without surrounding quotation marks.</returns>
    public static string GetFilePathFromUser()
    {
        Console.WriteLine("\nEnter the file path for loading the quiz:");
        string filePath = Console.ReadLine();
        return filePath.Trim('"'); // Removes quotation marks from the start and end of the string
    }
}
