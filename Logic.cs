
using System;

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
        foreach (Question question in quiz.Questions)
        {
            // Get the user's answers as a list of indices (as integers)
            List<int> userAnswersIndices = UIMethods.GetUserAnswersIndices(question);

            // Convert the indices to the actual answers for comparison
            List<string> userAnswers = userAnswersIndices.Select(index => question.Choices[index]).ToList();

            // Convert correct answer indices to the actual answers for comparison
            List<string> correctAnswers = question.correctAnswers.Select(index => question.Choices[index]).ToList();

            // SetEquals to compare the sets of answers
            HashSet<string> correctAnswersSet = new HashSet<string>(correctAnswers, StringComparer.InvariantCultureIgnoreCase);
            HashSet<string> userAnswersSet = new HashSet<string>(userAnswers, StringComparer.InvariantCultureIgnoreCase);

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

    /// <summary>
    /// Randomizes the order of questions in a given list.
    /// </summary>
    /// <param name="questions">A list of Question objects to be randomized.</param>
    /// <returns>A List of Question objects in a randomized order.</returns>

    public static List<Question> RandomizeQuestions(List<Question> questions)
    {
        Random range = new Random();
        int question = questions.Count;
        while (question > 1)
        {
            question--;
            int rngQuestion = range.Next(question + 1);
            Question value = questions[rngQuestion];
            questions[rngQuestion] = questions[question];
            questions[question] = value;
        }
        return questions;
    }
}
