public class Logic
{
    private Quiz quiz;

    /// <summary>
    /// Initializes a new instance 
    /// of the Logic class with a specified quiz.
    /// </summary>
    /// <param name="start">The Quiz object that will be used by this instance of Logic.</param>
    public Logic(Quiz start)
    {
        quiz = start;
    }

    /// <summary>
    /// Displays the total score on the console.
    /// </summary>
    /// <param name="score">The score value to be displayed.</param>
    public void DisplayScore(int score)
    {
        Console.WriteLine($"Total Score: {score}");
    }

    ///// <summary>
    ///// Saves the current quiz to a specified file path.
    ///// </summary>
    ///// <param name="filePath">The file path where the quiz will be saved.</param>
    //public static void SaveQuiz(Quiz quiz, string filePath)
    //{
    //    FileOperations.SaveQuiz(quiz, filePath);
    //}

    ///// <summary>
    ///// Loads a quiz from the specified file path.
    ///// </summary>
    ///// <param name="filePath">The file path from which the quiz will be loaded.</param>
    //public static Quiz LoadQuiz(string filePath)
    //{
    //   return FileOperations.LoadQuiz(filePath);
    //}
}
