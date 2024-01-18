
public static class Logic
{
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
            // Get the user's answers as a list of indices (as integers)
            List<int> userAnswersIndices = UIMethods.GetUserAnswersIndices(question);

            // Convert the indices to the actual answers for comparison
            List<string> userAnswers = userAnswersIndices.Select(index => question.Choices[index]).ToList();

            // Convert correct answer indices to the actual answers for comparison
            List<string> correctAnswers = question.correctAnswers.Select(index => question.Choices[index]).ToList();

            // Now use SetEquals to compare the sets of answers
            var correctAnswersSet = new HashSet<string>(correctAnswers, StringComparer.InvariantCultureIgnoreCase);
            var userAnswersSet = new HashSet<string>(userAnswers, StringComparer.InvariantCultureIgnoreCase);

            if (correctAnswersSet.SetEquals(userAnswersSet))
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
