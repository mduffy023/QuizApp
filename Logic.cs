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
    /// Adds a new question to the current quiz.
    /// </summary>
    /// <param name="question">The Question object to be added to the quiz.</param>
    public void AddQuestion(Question question)
    {
        quiz.AddQuestion(question);
    }

    /// <summary>
    ///  Remove a qustion from the quiz at the specified index 
    /// </summary>
    /// <param name="questionIndex">the index of the question to be removed. Indexing starts at 0, 
    /// so the first question has an index of 0, the second has an index of 1, ect</param>
    public void RemoveQuestion(int questionIndex)
    {
        if(questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            quiz.Questions.RemoveAt(questionIndex);
        }
    }

    /// <summary>
    /// Retrieves all questions from the current quiz.
    /// </summary>
    /// <returns>A List of Question objects representing 
    /// all the questions in the quiz.</returns>
    public List<Question> GetAllQuestions()
    {
        return quiz.Questions;
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
