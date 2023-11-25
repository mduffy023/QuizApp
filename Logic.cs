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
    /// 
    /// </summary>
    /// <param name="start"></param>
    public Logic(Quiz start)
    {
        quiz = start;
        score = 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="question"></param>
    public void AddQuestion(Question question)
    {
        quiz.AddQuestion(question);
    }

    /// <summary>
    ///  Remove a qustion from the quiz at the specified index 
    /// </summary>
    /// <param name="questionIndex">the index of the question to be removed. Indexing starts at 0, so the first question has an index of 0, the second has an index of 1, ect</param>
    public void RemoveQuestion(int questionIndex)
    {
        if(questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            quiz.Questions.RemoveAt(questionIndex);
        }
    }

    public List<Question> GetAllQuestions()
    {
        return quiz.Questions;
    }

    public void DisplayScore(int score)
    {
        Console.WriteLine($"Total Score: {score}");
    }

    //will call SaveQuiz(string path) in FileOperations Class
    public void SaveQuiz(string filePath)
    {
        fileOperations.SaveQuiz(quiz, filePath);
    }

    //will call SaveQuiz(string path) in FileOperations Class
    public void LoadQuiz()
    {
        //fileOperations.LoadQuiz();
    }
}
