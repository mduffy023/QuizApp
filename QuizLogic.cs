public class QuizLogic
{
    private Quiz quiz;
    private FileOperations fileHandler;

    /// <summary>
    /// Initializes a new Instance of the Quizlogic Class 
    /// </summary>
    /// <param name="quiz">the quiz to manage</param>
    /// <param name="fileHandler">the file handler for saving and loading the quiz</param>
    public QuizLogic(Quiz quiz, FileOperations fileHandler)
    {
        this.quiz = quiz;
        this.fileHandler = fileHandler;
    }

}
