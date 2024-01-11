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
    /// Initiates the quiz-taking process by iterating over each question in the provided quiz.
    /// For each question, it prompts the user for an answer and checks if it is correct.
    /// If the user's answer is correct, an appropriate message is displayed and the score is incremented.
    /// If the answer is incorrect, a different message indicating the correct answer is displayed.
    /// </summary>
    /// <param name="quiz">The Quiz object containing the questions to be answered.</param>
    /// <returns>The total score achieved by the user after answering all questions.</returns>
    public static int StartQuiz(Quiz quiz)
    {
        int score = 0;
        foreach (var question in quiz.Questions)
        {
            string userAnswer = UIMethods.GetAnswerFromUser(question);
            if (question.Answers.Contains(userAnswer, StringComparer.InvariantCultureIgnoreCase))
            {
                UIMethods.OutputRightAnswerMessage();
                score++;
            }
            else
            {
                UIMethods.OutputWrongAnswerMessage(question);
            }
        }
        return score;
    }
}
