
public static class Logic
{
    /// <summary>
    /// Executes the quiz, iterating through each question and validating the user's answers.
    /// </summary>
    /// <param name="quiz">The Quiz object containing all questions.</param>
    /// <returns>The total score obtained by the user.</returns>
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
