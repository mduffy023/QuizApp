public class QuizLogic
{
    private Quiz quiz;
    private FileOperations fileOperations;

    /// <summary>
    /// Initializes a new Instance of the Quizlogic Class 
    /// </summary>
    /// <param name="quiz">the quiz to manage</param>
    /// <param name="fileHandler">the file handler for saving and loading the quiz</param>
    public QuizLogic(Quiz quiz, FileOperations fileOperations)
    {
        this.quiz = quiz;
        this.fileOperations = fileOperations;
    }

}
