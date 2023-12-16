using System.ComponentModel;
using System.IO;
using System.IO.Enumeration;
using System.Security.AccessControl;

public class Logic
{

    private Quiz quiz;
    private int score;
    private FileOperations fileOperations;

    /// <summary>
    /// Initializes a new instance 
    /// of the Logic class with a specified quiz.
    /// </summary>
    /// <param name="start">The Quiz object that will be used by this instance of Logic.</param>
    public Logic(Quiz start)
    {
        quiz = start;
        score = 0;
    }

    /// <summary>
    /// Displays the total score on the console.
    /// </summary>
    /// <param name="score">The score value to be displayed.</param>
    public void DisplayScore(int score)
    {
        Console.WriteLine($"Total Score: {score}");
    }

    /// <summary>
    /// Saves the current quiz to a specified file path.
    /// </summary>
    /// <param name="filePath">The file path where the quiz will be saved.</param>
    public void SaveQuiz(string filePath)
    {
        fileOperations.SaveQuiz(quiz, filePath);
    }

    /// <summary>
    /// Loads a quiz from the specified file path.
    /// </summary>
    /// <param name="filePath">The file path from which the quiz will be loaded.</param>
    public void LoadQuiz(string filePath)
    {
        fileOperations.LoadQuiz(filePath);
    }
}
